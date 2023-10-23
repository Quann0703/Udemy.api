using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ITeachBLL
    {
        List<teachModel> GetAll();

        teachModel GetDatabyID(string teachID);

        bool Create(teachModel model);

        bool Delete(string teachID);
    }
}
