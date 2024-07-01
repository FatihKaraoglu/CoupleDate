using CoupleDate.Shared.RequestObject;
using CoupleDate.Shared;
using System.Net.Http.Json;

namespace CoupleDate.Client.Services.DateDecisionService
{
    public class DateDecisionService : IDateDecisionService
    {
        private readonly HttpClient _httpClient;

        public DateDecisionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse<List<DateIdea>>> GetDateIdeasAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<DateIdea>>>("api/DateIdeas");
            return response;
        }

        public async Task<ServiceResponse<string>> SwipeAsync(SwipeRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Swipes", request);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }
    }


}
