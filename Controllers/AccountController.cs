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

        [Route("create-Account")]
        [HttpPost]
        public AccountModel CreateItem([FromBody] AccountModel model)
        {
            _accountBll.Create(model);
            return model;
        }

        [Route("update_Account")]
        [HttpPost]
        public AccountModel UpdateItem([FromBody] AccountModel model)
        {
            _accountBll.Update(model);
            return model;
        }

    }
}
