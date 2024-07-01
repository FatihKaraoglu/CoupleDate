using CoupleDate.Shared;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace CoupleDate.Client.Services.InvationService
{
    public class InvationService : IInvationService
    {
        private readonly HttpClient _httpClient;
        public InvationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task GenerateInvitationLink()
        {
            var response = await  _httpClient.GetAsync("api/Invitation/GenerateLink");
            var link = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Invitation link: " + link);
        }
    }
}
