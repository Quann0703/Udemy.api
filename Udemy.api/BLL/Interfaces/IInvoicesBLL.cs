using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IInvoicesBLL
    {
        InvoicesModel GetDataById(string invoicesId);
        bool Create(InvoicesModel model);
        bool Update(InvoicesModel model);
        bool Delete(string invoicesId);
    }
}
