using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("v1/account")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            var user = UserService
                        .Login(model.Username, 
                                model.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou Senha inválido" });

            var token = TokenService
                            .GenerateToken(user);
            user.Password = "";
            return new
            {
                user,
                token
            };
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => $"Usário autenticado: { User.Identity.Name }";

        [HttpGet]
        [Route("filhos")]
        [Authorize(Roles = "filhos, pais")]
        public string Employee() => "Filhos";

        [HttpGet]
        [Route("pais")]
        [Authorize(Roles = " pais")]
        public string Manager() => "Pais";
    }
}