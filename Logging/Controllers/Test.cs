using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Logging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Test : ControllerBase
    {
        public readonly ILogger _logger;
        public Test(ILogger<Test> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult test1()
        {
            _logger.LogInformation("======================== GET test/ =========================");
            return Ok("Testes com log 1");
        }
    }
}
