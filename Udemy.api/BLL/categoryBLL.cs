using DAL;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class categorysBLL : IcategorysBLL
    {
        public IcategorysRepository _res;

        public categorysBLL(IcategorysRepository res)
        {
            _res = res;
        }
        public List<categorysModel> GetAll()
        {
            return _res.GetAll();
        }
        public categorysModel GetDatabyID(string IDcategory)
        {
            return _res.GetDatabyID(IDcategory);
        }

        public bool Create(categorysModel model)
        {
            return _res.Create(model);
        }
        public bool Delete(string IDcategory)
        {
            return _res.Delete(IDcategory);
        }
    }
}

