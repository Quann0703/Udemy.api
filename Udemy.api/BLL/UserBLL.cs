using DAL;
using DataModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBLL : IUserBLL
    {
        public IUserRepository _res;
        public UserBLL(IUserRepository res)
        {
            _res = res; 
        }
        public List<UserModel> GetAll()
        {
            return _res.GetAll();
        }
        public UserModel GetDatabyID(string acountID)
        {
            return _res.GetDatabyID(acountID);
        }

        /*public bool Create(UserModel model)
        {
            return _res.Create(model);
        }*/

        public bool Update(UserModel model)
        {
            return _res.Update(model);
        }

        public List<UserModel> Search(int page, int pageSize, out long total, string nameUser)
        {
            return _res.Search(page, pageSize, out total, nameUser);
        }
    }
}
