using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class TeachRepository:ITeachRepository
    {
        private IDatabaseHelper _dbHelper;

        public TeachRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<teachModel> GetAll()
        {
            string msgError = "";
            try
            {
                var data = _dbHelper.ExecuteQuery("sp_teacher_getAll");
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return data.ConvertTo<teachModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public teachModel GetDataById(string teachID)
        {
            string msgError = "";
            try
            {
                var data = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_teacher_get_by_ID", "@teachID", teachID);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return data.ConvertTo<teachModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(teachModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_teacher_create",
                "@teachID", model.teachID,
                "@Tcname", model.Tcname,
                "@phonenumber", model.phonenumber,
                "@email", model.email,
                "@Evaluate",model.Evaluate,
                "@job",model.job,
                "@totalCouse",model.totalCouse,
                "@numberstudent",model.numberstudent,
                "@decribe",model.decribe
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
        }

        public bool Delete(string teachID)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_teacher_delete",
                "@teachID", teachID);
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
