using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface INotificationRepository
    {
        List<noificationModel> GetAll();
        noificationModel GetDatabyID(string NotifiID);
        bool Create(noificationModel noification);

        bool Delete(string NotifiID);
    }
}
