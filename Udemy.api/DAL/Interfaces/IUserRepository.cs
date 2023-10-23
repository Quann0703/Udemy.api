using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface  IUserRepository
    {
        List<UserModel> GetAll();
        UserModel GetDatabyID(string userID);
       /* bool Create(UserModel user);*/

        bool Update(UserModel user);

        public List<UserModel> Search(int page, int pageSize ,out long total,string nameUser);
    }
}
