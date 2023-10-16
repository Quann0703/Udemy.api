using DAL;
using DataModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public  class NotificationBLL : INotificationBLL
    {
        public INotificationRepository _res;

        public NotificationBLL(INotificationRepository res)
        {
            _res = res;
        }
        public List<noificationModel> GetAll()
        {
            return _res.GetAll();
        }
        public noificationModel GetDatabyID(string NotifiID)
        {
            return _res.GetDatabyID(NotifiID);
        }

        public bool Create(noificationModel model)
        {
            return _res.Create(model);
        }
        public bool Delete(string NotifiID)
        {
            return _res.Delete(NotifiID);
        }
    }
}
