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

        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> fromData)
        {
            try
            {
                var page = int.Parse(fromData["page"].ToString());
                var pageSize = int.Parse(fromData["pageSize"].ToString());
                string title = "";
                if (fromData.Keys.Contains("title") && !string.IsNullOrEmpty(Convert.ToString(fromData["title"])))
                {
                    title = Convert.ToString(fromData["title"]);
                }
                long total = 0;
                var data = _courseBLL.Search(page, pageSize, out total, title);
                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        page = page,
                        PageSize = pageSize
                    }
                    );

            }
            catch (Exception ex) { throw ex; }
        }
    }
}
