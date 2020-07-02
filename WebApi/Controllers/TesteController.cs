using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("v1/teste")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        [HttpGet]
        [Route("")]        
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
