using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IAccountBLL
    {
        List<AccountModel> GetAll();
        AccountModel Login(string username, string password);
        AccountModel GetDatabyID(string acountID);

        bool Create(AccountModel model,string name);

        bool Update(AccountModel model);

        bool Delete(string acountID);
    }
}
