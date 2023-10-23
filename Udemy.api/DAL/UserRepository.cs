using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepository:IUserRepository
    {
        private IDatabaseHelper _dbHelper;

        public UserRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<UserModel> GetAll()
        {
            string msgError = "";
            try
            {
                var data = _dbHelper.ExecuteQuery("sp_User_getAll");
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return data.ConvertTo<UserModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UserModel GetDatabyID(string userID)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Users_get_by_ID", "@userID", userID);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return dt.ConvertTo<UserModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*public bool Create(UserModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Users_create",
                "@userID", model.userID,
                "nameUser", model.nameUser,
                "avata", model.avarta,
                "adress", model.adress,
                "phonenumber", model.phonenumber,
                "bio", model.bio
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
        public bool Update(UserModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_User_Update",
                "@userID", model.userID,
                "@nameUser", model.nameUser,
                "@avarta", model.avarta,
                "@adress", model.adress,
                "@phonenumber", model.phonenumber,
                "@bio", model.bio);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserModel> Search(int page, int pageSize, out long total, string nameUser)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_search_user",
                    "@page_index" ,page,
                    "@page_size",pageSize,
                    "@nameUser",nameUser
                    );
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<UserModel>().ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
