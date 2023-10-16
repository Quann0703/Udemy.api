
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DAL;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class AccountBLL : IAccountBLL
    {
        public IAccountRepository _res;
        private string secret;
        public AccountBLL(IAccountRepository res , IConfiguration configuration)
        {
            _res = res;
            secret = configuration["AppSettings:Secret"];
        }
        public List<AccountModel> GetAll()
        {
            return _res.GetAll();
        }
        public AccountModel Login(string username, string password)
        {
            var user = _res.Login(username, password);
            if(user == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Username.ToString()),
                    new Claim(ClaimTypes.StreetAddress,user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.Aes128CbcHmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);
            return user;

        }
        public AccountModel GetDatabyID(string acountID)
        {
            return _res.GetDatabyID(acountID);
        }

        public bool Create(AccountModel model, string name)
        {
            return _res.Create(model,name);
        }

        public bool Update(AccountModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string acountID)
        {
            return _res.Delete(acountID);
        }
    }
}
