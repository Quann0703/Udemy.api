using BLL;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class fieldsController : ControllerBase
    {
        private IfieldBLL _fieldBll;
        public fieldsController(IfieldBLL fieldBll)
        {
            _fieldBll = fieldBll;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var dt = _fieldBll.GetAll().Select(x => new { x.fieldID, x.Namefield, x.decribe});
            return Ok(dt);
        }
        [Route("get-by-id/{fieldID}")]
        [HttpGet]
        public IActionResult GetDatabyID(string fieldID)
        {
            var dt = _fieldBll.GetDatabyID(fieldID);
            return Ok(dt);
        }

        [Route("create-fields")]
        [HttpPost]
        public fieldsModel CreateItem([FromBody] fieldsModel model)
        {
            _fieldBll.Create(model);
            return model;
        }

        [HttpDelete("delete-fields")]
        public IActionResult DeleteItem(string fieldID)
        {
            _fieldBll.Delete(fieldID);
            return Ok(new { message = "xoa thanh cong" });
        }
    }
}
