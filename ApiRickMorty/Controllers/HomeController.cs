using ApiRickMorty.Interfaces;
using ApiRickMorty.Models;
using ApiRickMorty.Repositories;
using ApiRickMorty.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace ApiRickMorty.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class HomeController : ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]

        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            var user = UserRepository.Get(model.UserName, model.Password);

            if (user == null)
            {
                return NotFound(new {message = "Usuário ou senha inválidos !"});
            }

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
