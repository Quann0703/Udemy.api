using BLL;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private INotificationBLL _notificationtBll;
        public NotificationController(INotificationBLL notificationtBll)
        {
            _notificationtBll = notificationtBll;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var dt = _notificationtBll.GetAll().Select(x => new { x.NotifiID, x.titile, x.date, });
            return Ok(dt);
        }
        [Route("get-by-id/{NotifiID}")]
        [HttpGet]
        public IActionResult GetDatabyID(string NotifiID)
        {
            var dt = _notificationtBll.GetDatabyID(NotifiID);
            return Ok(dt);
        }

        [Route("create-Notification")]
        [HttpPost]
        public noificationModel CreateItem([FromBody] noificationModel model)
        {
            _notificationtBll.Create(model);
            return model;
        }

        [HttpDelete("delete-notification")]
        public IActionResult DeleteItem(string NotifiID)
        {
            _notificationtBll.Delete(NotifiID);
            return Ok(new { message = "xoa thanh cong" });
        }
    }
}
