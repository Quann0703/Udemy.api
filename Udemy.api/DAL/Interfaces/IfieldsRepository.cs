using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface  IfieldsRepository
    {
        List<fieldsModel> GetAll();
        fieldsModel GetDatabyID(string fieldID);
        bool Create(fieldsModel model);

        bool Delete(string fieldID);

        public List<fieldsModel> Search(int page, int pageSize, out long total, string Namefield);
    }
}
