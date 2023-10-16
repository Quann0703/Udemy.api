using DAL;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class topicBLL:ItopicBLL
    {
        public ItopicReopsitory _res;

        public topicBLL(ItopicReopsitory res)
        {
            _res = res;
        }
        public List<topicModel> GetAll()
        {
            return _res.GetAll();
        }
        public topicModel GetDatabyID(string topicID)
        {
            return _res.GetDatabyID(topicID);
        }

        public bool Create(topicModel model)
        {
            return _res.Create(model);
        }
        public bool Delete(string topicID)
        {
            return _res.Delete(topicID);
        }
    }
}
