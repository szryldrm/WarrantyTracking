using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using Newtonsoft.Json;
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

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _warrantyService.GetList();
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Data));
            }
            return BadRequest(result.Message);
        }
        
        [HttpGet("get")]
        public IActionResult Get(string id)
        {
            var result = _warrantyService.Get(id);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Data));
            }
            return BadRequest(result.Message);
        }
        
        [HttpGet("getbylicenseplate")]
        public IActionResult GetByLicensePlate(string plate)
        {
            var result = _warrantyService.GetByLicensePlate(plate);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Data));
            }
            return BadRequest(result.Message);
        }
        
        [HttpDelete("Delete")]
        public IActionResult Delete(string id)
        {
            var result = _warrantyService.Delete(id);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}