using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LuckyNumberController : ControllerBase
    {
        private readonly LuckyNumberGeneratorService _luckyNumberGeneratorService;
        private readonly ILogger<LuckyNumberController> _logger;

        public LuckyNumberController(
            LuckyNumberGeneratorService luckyNumberGeneratorService,
            ILogger<LuckyNumberController> logger)
        {
            _luckyNumberGeneratorService = luckyNumberGeneratorService;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<int> GetLuckyNumber()
        {
            _logger.LogInformation("Fetching lucky number from lucky number service");
            return await _luckyNumberGeneratorService.FetchLuckyNumberOfTheDay();
        }
    }
}