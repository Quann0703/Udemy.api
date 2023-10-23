using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class categorysRepository:IcategorysRepository
    {
        private IDatabaseHelper _dbHelper;

        public categorysRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<categorysModel> GetAll()
        {
            string msgError = "";
            try
            {
                var data = _dbHelper.ExecuteQuery("sp_categorys_getAll");
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return data.ConvertTo<categorysModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public categorysModel GetDatabyID(string IDcategory)
        {
            string msgError = "";
            try
            {
                var data = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_categorys_get_by_ID", "@IDcategory", IDcategory);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return data.ConvertTo<categorysModel>().FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(categorysModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_categorys_create",
                "@IDcategory", model.IDcategory,
                "@categoryname", model.categoryname,
                "@decribe", model.decribe,
                "@fieldID",model.fieldID
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

        public bool Delete(string IDcategory)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_categorys_delete",
                "@IDcategory", IDcategory);
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
