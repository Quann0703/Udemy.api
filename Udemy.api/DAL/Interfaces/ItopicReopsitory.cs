using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ItopicReopsitory
    {
        List<topicModel> GetAll();
        topicModel GetDatabyID(string topicID);
        bool Create(topicModel model);

        bool Delete(string topicID);
    }
}
