using BLL;
using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseBLL _courseBLL;
        public CourseController(ICourseBLL courseBLL)
        {
            _courseBLL = courseBLL;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var dt = _courseBLL.GetAll().Select(x => new { x.courseID, x.title, x.couresImg,x.feecoures,x.teachID ,x.Tcname});
            return Ok(dt);
        }

        [HttpGet("get-by-id")]
        public CourseModel GetDataById(string id) => _courseBLL.GetDataById(id);


        [HttpPost("create-course")]
        public CourseModel CreateItem([FromBody] CourseModel model)
        {
            _courseBLL.Create(model);
            return model;
        }

        [HttpPatch("update-course")]
        public CourseModel UpdateItem([FromBody] CourseModel model)
        {
            _courseBLL.Update(model);
            return model;
        }

        [HttpDelete("delete-course")]
        public IActionResult DeleteItem(string id)
        {
            _courseBLL.Delete(id);
            return Ok(new { message = "Xóa thành công" });
        }
    }
}
