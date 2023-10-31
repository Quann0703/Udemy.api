using BLL;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class topicController : ControllerBase
    {
        private ItopicBLL _topicBll;
        public topicController(ItopicBLL topicBll)
        {
            _topicBll = topicBll;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var dt = _topicBll.GetAll().Select(x => new { x.topicID, x.topicName, x.decribe });
            return Ok(dt);
        }
        [Route("get-by-id/{topicID}")]
        [HttpGet]
        public IActionResult GetDatabyID(string topicID)
        {
            var dt = _topicBll.GetDatabyID(topicID);
            return Ok(dt);
        }

        [Route("create-topic")]
        [HttpPost]
        public topicModel CreateItem([FromBody] topicModel model)
        {
            _topicBll.Create(model);
            return model;
        }

        [HttpDelete("delete-topic")]
        public IActionResult DeleteItem(string topicID)
        {
            _topicBll.Delete(topicID);
            return Ok(new { message = "xoa thanh cong" });
        }
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> fromData)
        {
            try
            {
                var page = int.Parse(fromData["page"].ToString());
                var pageSize = int.Parse(fromData["pageSize"].ToString());
                string topicName = "";
                if (fromData.Keys.Contains("topicName") && !string.IsNullOrEmpty(Convert.ToString(fromData["topicName"])))
                {
                    topicName = Convert.ToString(fromData["topicName"]);
                }
                long total = 0;
                var data = _topicBll.Search(page, pageSize, out total, topicName);
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
