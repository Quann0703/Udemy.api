using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class topicRepository : ItopicReopsitory
    {
        private IDatabaseHelper _dbHelper;

        public topicRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<topicModel> GetAll()
        {
            string msgError = "";
            try
            {
                var data = _dbHelper.ExecuteQuery("sp_topicpopular_getAll");
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return data.ConvertTo<topicModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public topicModel GetDatabyID(string topicID)
        {
            string msgError = "";
            try
            {
                var data = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_topicpopular_get_by_ID", "@topicID", topicID);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return data.ConvertTo<topicModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(topicModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_topicpopular_create",
                "@topicID", model.topicID,
                "@topicName", model.topicName,
                "@decribe", model.decribe,
                "@IDcategory", model.IDcategory
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

        public bool Delete(string topicID)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_topicpopular_delete",
                "@topicID", topicID);
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

        public List<topicModel> Search(int page, int pageSize, out long total, string topicName)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_search_topic",
                    "@page_index", page,
                    "@page_size", pageSize,
                    "@topicName", topicName
                    );
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<topicModel >().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
