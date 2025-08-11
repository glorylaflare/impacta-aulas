using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esquisito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestesController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Hello World!");
        }
    }
}
