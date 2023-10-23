using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DAL
{
    public interface IAccountRepository
    {
        AccountModel Login(string username, string password);

        List<AccountModel> GetAll();
        AccountModel GetDatabyID(string acountID);
        bool Create(AccountModel account , string name);

        bool Update(AccountModel account);

        bool Delete(string acountID);

    }
}
