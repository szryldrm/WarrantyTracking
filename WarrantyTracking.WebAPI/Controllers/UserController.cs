using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WarrantyTracking.Business.Abstract;

namespace WarrantyTracking.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(JsonConvert.SerializeObject(result.Data));
            }
            return BadRequest(result.Message);
        }
    }
}
