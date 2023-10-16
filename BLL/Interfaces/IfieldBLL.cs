using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IfieldBLL
    {
        List<fieldsModel> GetAll();

        fieldsModel GetDatabyID(string fieldID);

        bool Create(fieldsModel model);

        bool Delete(string fieldID);
    }
}
