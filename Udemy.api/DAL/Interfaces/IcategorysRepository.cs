using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IcategorysRepository
    {
        List<categorysModel> GetAll();
        categorysModel GetDatabyID(string IDcategory);
        bool Create(categorysModel model);

        bool Update(categorysModel model);

        bool Delete(string IDcategory);

        public List<categorysModel> Search(int page, int pageSize, out long total, string categoryname);
    }
}
