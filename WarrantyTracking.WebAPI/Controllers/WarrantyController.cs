using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WarrantyTracking.Business.Abstract;

namespace WarrantyTracking.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarrantyController : ControllerBase
    {
        private IWarrantyService _warrantyService;
        
        public WarrantyController(IWarrantyService warrantyService)
        {
            _warrantyService = warrantyService;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var result = _warrantyService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}