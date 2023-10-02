using BLL;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountBLL _accountBll;
        public AccountController(IAccountBLL accountBll)
        {
            _accountBll = accountBll;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult login([FromBody] AuthenticateModel model)
        {
            var user = _accountBll.Login(model.Username, model.Password);
            if(user == null)
            {
                return BadRequest(new { message = "Tài khoản hoặc mật khẩu không đúng!" });
            }
            return Ok(new { taikhoan = user.Username, Email = user.Email, token = user.token });
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
