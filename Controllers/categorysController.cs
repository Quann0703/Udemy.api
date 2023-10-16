using BLL;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class categorysController : ControllerBase
    {
        private IcategorysBLL _categorysBll;
        public categorysController(IcategorysBLL fieldBll)
        {
            _categorysBll = fieldBll;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var dt = _categorysBll.GetAll().Select(x => new { x.IDcategory, x.categoryname, x.decribe });
            return Ok(dt);
        }
        [Route("get-by-id/{IDcategory}")]
        [HttpGet]
        public IActionResult GetDatabyID(string IDcategory)
        {
            var dt = _categorysBll.GetDatabyID(IDcategory);
            return Ok(dt);
        }

        [Route("create-categorys")]
        [HttpPost]
        public categorysModel CreateItem([FromBody] categorysModel model)
        {
            _categorysBll.Create(model);
            return model;
        }

        [HttpDelete("delete-categorys")]
        public IActionResult DeleteItem(string IDcategory)
        {
            _categorysBll.Delete(IDcategory);
            return Ok(new { message = "xoa thanh cong" });
        }
    }
}
