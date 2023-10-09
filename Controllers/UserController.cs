using BLL;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBLL _userBll;
        public UserController(IUserBLL userBll)
        {
            _userBll = userBll;
        }
        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var dt = _userBll.GetAll().Select(x => new { x.userID, x.nameUser, x.phonenumber, });
            return Ok(dt);
        }
        [Route("get-by-id/{userID}")]
        [HttpGet]
        public IActionResult GetDatabyID(string userID)
        {
            var dt = _userBll.GetDatabyID(userID);
            return Ok(dt);
        }

        /*[Route("create-user")]
        [HttpPost]
        public UserModel CreateItem([FromBody] UserModel model)
        {
            _userBll.Create(model);
            return model;
        }*/

        [Route("update_Account")]
        [HttpPost]
        public UserModel UpdateItem([FromBody] UserModel model)
        {
            _userBll.Update(model);
            return model;
        }
    }
}
