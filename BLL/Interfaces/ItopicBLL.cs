using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ItopicBLL
    {
        List<topicModel> GetAll();

        topicModel GetDatabyID(string topicID);

        bool Create(topicModel model);

        bool Delete(string topicID);
    }
}
