using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.MockDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ICrudService<User> _service;

        public UsersController(ICrudService<User> service)
        {
            _service = service;
        }

        public IActionResult Get()
        {
            var result = _service.Read();
            return Ok(result);
        }

        public IActionResult Get(int id)
        {
            var result = _service.Read(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
