using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DataModel;
using Microsoft.Identity.Client;

namespace DAL
{
    public class AccountRepository : IAccountRepository
    {
        private IDatabaseHelper _dbHelper;
        
        public AccountRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public AccountModel Login(string username, string password)
        {
            string msgError = "";
            try
            {
                var data = _dbHelper.ExecuteSProcedureReturnDataTable(
                    out msgError,
                    "sp_login",
                    "@username", username,
                    "@password", password
                    );
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return data.ConvertTo<AccountModel>().FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<AccountModel> GetAll()
        {
            string msgError = "";
            try
            {
                var data = _dbHelper.ExecuteQuery("sp_Account_getAll");
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return data.ConvertTo<AccountModel>().ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public AccountModel GetDatabyID(string acountID)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Account_get_by_ID", "@acountID", acountID);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return dt.ConvertTo<AccountModel>().FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(AccountModel model,string name)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Account_create",
                "Username", model.Username,
                "Password", model.Password,
                "Email", model.Email,
                "FullName", model.FullName,
                "typeID", model.typeID,
                "nameUser" ,name
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(AccountModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_Account_Update",
                "acountID",model.acountID,
                "Username", model.Username,
                "Password", model.Password,
                "Email", model.Email,
                "N'FullName'", model.FullName,
                "typeID", model.typeID);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(string acountID)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_Account_delete",
                "@acountID", acountID);
                ;
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
    }
}
