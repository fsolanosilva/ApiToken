using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Repositories;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Ping()
        {
            return Ok("ok bro");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]User model)
        {
            var user = UserRepository.Get(model.UserName, model.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);

            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }
    }
}
