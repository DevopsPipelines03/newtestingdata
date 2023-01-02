using System.Collections;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EnvironmentVariablesController : ControllerBase
{
    private readonly ILogger<LuckyNumberController> _logger;

    public EnvironmentVariablesController(ILogger<LuckyNumberController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    public IDictionary ListEnvVars()
    {
        _logger.LogInformation("Fetching all environment variables");
        return Environment.GetEnvironmentVariables();
    }
}