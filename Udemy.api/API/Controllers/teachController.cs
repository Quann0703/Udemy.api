using BLL;
using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class teachController : ControllerBase
    {
        private ITeachBLL teachBLL;
        public teachController(ITeachBLL teachBLL)
        {
            this.teachBLL = teachBLL;
        }
        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var dt = teachBLL.GetAll().Select(x => new { x.teachID, x.Tcname, x.job, x.Evaluate, x.email, x.decribe });
            return Ok(dt);
        }

        [HttpGet("get-by-id")]
        public teachModel GetDataById(string teachID) => teachBLL.GetDatabyID(teachID);


        [HttpPost("create-teach")]
        public teachModel CreateItem([FromBody] teachModel model)
        {
            teachBLL.Create(model);
            return model;
        }

        [HttpDelete("delete-teach")]
        public IActionResult DeleteItem(string teachID)
        {
            teachBLL.Delete(teachID);
            return Ok(new { message = "Xóa thành công" });
        }
    }
}
