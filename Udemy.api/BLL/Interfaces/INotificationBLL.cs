using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface INotificationBLL
    {
        List<noificationModel> GetAll();
        noificationModel GetDatabyID(string NotifiID);
        bool Create(noificationModel model);
        bool Delete(string NotifiID);
    }
}
