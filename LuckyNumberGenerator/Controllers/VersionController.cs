using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace LuckyNumberGenerator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VersionController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "v?";
        }
    }
}