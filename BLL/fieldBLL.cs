using BLL;
using DAL;
using DAL;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class fieldBLL:IfieldBLL
    {
        public IfieldsRepository _res;

        public fieldBLL(IfieldsRepository res)
        {
            _res = res;
        }
        public List<fieldsModel> GetAll()
        {
            return _res.GetAll();
        }
        public fieldsModel GetDatabyID(string fieldID)
        {
            return _res.GetDatabyID(fieldID);
        }

        public bool Create(fieldsModel model)
        {
            return _res.Create(model);
        }
        public bool Delete(string fieldID)
        {
            return _res.Delete(fieldID);
        }
    }
}
