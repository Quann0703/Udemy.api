using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IUserBLL
    {
        List<UserModel> GetAll();
        UserModel GetDatabyID(string acountID);

        /*bool Create(UserModel model);*/

        bool Update(UserModel model);

        public List<UserModel> Search(int page, int pageSize, out long total, string nameUser);
    }
}
