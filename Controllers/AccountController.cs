using BLL;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountBLL _accountBll;
        public AccountController(IAccountBLL accountBll)
        {
            _accountBll = accountBll;
        }

        [Route("get-by-id/{acountID}")]
        [HttpGet]
        public AccountModel GetDatabyID(string acountID)
        {
            return _accountBll.GetDatabyID(acountID);
        }
    }
}
