using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using Newtonsoft.Json;
using WarrantyTracking.Business.Abstract;
using WarrantyTracking.Core.Aspects.Autofac.Caching;
using WarrantyTracking.Entities.Concrete;

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
        
        // [HttpGet("getactivelist")]
        // public IActionResult GetActiveList()
        // {
        //     var result = _warrantyService.GetActiveList();
        //     if (result.Success)
        //     {
        //         return Ok(JsonConvert.SerializeObject(result.Data));
        //     }
        //     return BadRequest(result.Message);
        //}

        [HttpPost("add")]
        public IActionResult Add([FromBody]Warranty warranty)
        {
            var result = _warrantyService.Add(warranty);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            return BadRequest(result.Message);
        }
        
        [HttpGet("getlatestlist")]
        public IActionResult GetLatestList()
        {
            var result = _warrantyService.GetLatestList();
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Data));
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getactive/{id}")]
        public IActionResult GetActive(string id)
        {
            var result = _warrantyService.GetActive(id);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Data));
            }
            return BadRequest(result.Message);
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(string id)
        {
            var result = _warrantyService.Get(id);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Data));
            }
            return BadRequest(result.Message);
        }
        
        [HttpGet("getbylicenseplate/{plate}")]
        public IActionResult GetByLicensePlate(string plate)
        {
            var result = _warrantyService.GetByLicensePlate(plate);
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Data));
            }
            return BadRequest(result.Message);
        }
        
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(string id)
        {
            var result = _warrantyService.Delete(id);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        
        [HttpPost("AddDetail/{id}")]
        public IActionResult AddDetail(string id, [FromBody] Detail detail)
        {
            var result = _warrantyService.AddDetail(id, detail);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        
        [HttpGet("DeleteDetail/{serialNumber}")]
        public IActionResult DeleteDetail(string serialNumber)
        {
            var result = _warrantyService.DeleteDetail(serialNumber);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
