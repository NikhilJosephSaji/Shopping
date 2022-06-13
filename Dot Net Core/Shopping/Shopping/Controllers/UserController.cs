using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Shopping.Business;
using Shopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ShoppingContext context;
        private readonly ILogger<UserController> _logger;
        private Logging log;
        public UserController(ILogger<UserController> logger, ShoppingContext dbContext, IConfiguration config)
        {
            if(Convert.ToBoolean(config["CustomLog"]))
                log = new Logging();
            log?.logger.LogEnter("");
            context = dbContext;
            _logger = logger;
            log?.logger.LogExit("");
        }

        [HttpGet("IsUserExist")]
        public IActionResult IsUserExist(string username, string password)
        {
            using (context)
            {
                var user = context.Users.FirstOrDefault(x => x.UserName == username && x.Password == password);
                if (user != null)
                {
                    if (user.UserName.Equals(username) && user.Password.Equals(password))
                    {
                        return Ok("User Found");
                    }
                }
                return NotFound();
            }
        }

        [HttpGet("GetUserById")]
        public IActionResult GetUserById(string id)
        {
            using (context)
            {
                var user = context.Users.FirstOrDefault(x => x.Id.ToString() == id);
                if (user != null)
                {
                    return Ok(user);
                }
                return NotFound();
            }
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] UserModel user)
        {
            using (context)
            {
                try
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
                catch
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
                return Ok("User Created");
            }
        }
    }
}