using DAL;
using DAL.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InvoicesBLL : IInvoicesBLL
    {
        private IInvoicesRepository _res;
        public InvoicesBLL(IInvoicesRepository res)
        {
            _res = res;
        }
        public InvoicesModel GetDataById(string invoicesId)
        {
            return _res.GetDataById(invoicesId);
        }

        public bool Create(InvoicesModel model)
        {
            return _res.Create(model);
        }

        public bool Update(InvoicesModel model)
        {
            return _res.Update(model);
        }

        public bool Delete(string invoicesId)
        {
            return _res.Delete(invoicesId);
        }
    }
}
