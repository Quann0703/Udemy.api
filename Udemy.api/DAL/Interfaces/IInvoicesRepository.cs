using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IInvoicesRepository
    {
        InvoicesModel GetDataById(string invoicesId);
        bool Create(InvoicesModel model);
        bool Update(InvoicesModel model);
        bool Delete(string invoicesId);

    }
}
