using DAL;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public  class TeachBLL:ITeachBLL
    {
        public ITeachRepository _res;

        public TeachBLL(ITeachRepository res)
        {
            _res = res;
        }
        public List<teachModel> GetAll()
        {
            return _res.GetAll();
        }
        public teachModel GetDatabyID(string teachID)
        {
            return _res.GetDataById(teachID);
        }

        public bool Create(teachModel model)
        {
            return _res.Create(model);
        }
        public bool Delete(string teachID)
        {
            return _res.Delete(teachID);
        }
    }
}
