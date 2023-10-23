using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IcategorysBLL
    {
        List<categorysModel> GetAll();

        categorysModel GetDatabyID(string IDcategory);

        bool Create(categorysModel model);

        bool Delete(string IDcategory);
    }
}
