using BLL;
using BLL.Interfaces;
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

        [HttpPatch("update-course")]
        public categorysModel UpdateItem([FromBody] categorysModel model)
        {
            _categorysBll.Update(model);
            return model;
        }

        [HttpDelete("delete-categorys")]
        public IActionResult DeleteItem(string IDcategory)
        {
            _categorysBll.Delete(IDcategory);
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
                string categoryname = "";
                if (fromData.Keys.Contains("categoryname") && !string.IsNullOrEmpty(Convert.ToString(fromData["categoryname"])))
                {
                    categoryname = Convert.ToString(fromData["categoryname"]);
                }
                long total = 0;
                var data = _categorysBll.Search(page, pageSize, out total, categoryname);
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
