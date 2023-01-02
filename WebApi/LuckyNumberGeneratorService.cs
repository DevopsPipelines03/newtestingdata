namespace WebApi
{
    public class LuckyNumberGeneratorService
    {
        private readonly HttpClient _httpClient;

        public LuckyNumberGeneratorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> FetchLuckyNumberOfTheDay()
        {
            return await _httpClient.GetFromJsonAsync<int>("generate/number");
        }
    }
}
