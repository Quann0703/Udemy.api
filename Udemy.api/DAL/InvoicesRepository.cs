using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class InvoicesRepository :IInvoicesRepository
    {
        private IDatabaseHelper _db;
        public InvoicesRepository(IDatabaseHelper db)
        {
            _db = db;
        }

        
        public InvoicesModel GetDataById(string invoicesId)
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteSProcedureReturnDataTable(
                    out msgError,
                    "sp_Invoices_get_byid",
                    "@InvoicesId",
                    invoicesId);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return data.ConvertTo<InvoicesModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(InvoicesModel model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError,
                "sp_Invoices_create",
                "@userID", model.userID,
                "@createDate", model.createDate,
                "@condition", model.condition,
                "@list_json_InvoicesDetail", model.list_json_InvoicesDetail != null ? MessageConvert.SerializeObject(model.list_json_InvoicesDetail) : null);
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
        public bool Update(InvoicesModel model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_Invoices_update",
                "@invoicesId", model.invoicesId,
                "@userID", model.userID,
                "@createDate", model.createDate,
                "@condition", model.condition,
                "@list_json_InvoicesDetail", model.list_json_InvoicesDetail != null ? MessageConvert.SerializeObject(model.list_json_InvoicesDetail) : null);
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
        public bool Delete(string invoicesId)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_Invoices_delete",
                "@@invoicesId", invoicesId);
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
