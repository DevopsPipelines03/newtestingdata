using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
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