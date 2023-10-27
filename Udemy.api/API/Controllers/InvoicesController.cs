using BLL;
using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private IInvoicesBLL _invoicesBLL;
        public InvoicesController (IInvoicesBLL invoicesBLL)
        {
            _invoicesBLL = invoicesBLL;
        }

        [HttpGet("get-by-id")]
        public InvoicesModel GetDataById(string invoicesId) => _invoicesBLL.GetDataById(invoicesId);


        [HttpPost("create-course")]
        public InvoicesModel CreateItem([FromBody] InvoicesModel model)
        {
            _invoicesBLL.Create(model);
            return model;
        }

        [HttpPatch("update-Invoices")]
        public InvoicesModel UpdateItem([FromBody] InvoicesModel model)
        {
            _invoicesBLL.Update(model);
            return model;
        }

        [HttpDelete("delete-Invoices")]
        public IActionResult DeleteItem(string invoicesId)
        {
            _invoicesBLL.Delete(invoicesId);
            return Ok(new { message = "Xóa thành công" });
        }
    }
}
