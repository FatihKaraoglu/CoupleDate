using CoupleDate.Client.Services.AuthService;
using CoupleDate.Shared;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace CoupleDate.Client.Services.InvationService
{
    public class InvitationService : IInvitationService
    {
        private readonly HttpClient _httpClient;
        private readonly IAuthService _authService;

        public InvitationService(HttpClient httpClient, IAuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }

        public async Task<ServiceResponse<string>> GenerateInvitationLinkAsync()
        {
            var token = await _authService.GetTokenAsync();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PostAsJsonAsync("api/invitation/generatelink", new { });
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
            }
            return new ServiceResponse<string> { Success = false, Message = "Error generating link." };
        }

        public async Task<ServiceResponse<string>> AcceptInvitationAsync(string token)
        {
            var userToken = await _authService.GetTokenAsync();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userToken);

            var response = await _httpClient.GetAsync($"api/invitation/acceptinvitation?token={token}");
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<bool>> LeaveCoupleAsync()
        {
            var response = await _httpClient.PostAsJsonAsync("api/invitation/leavecouple", new { });
            return await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }

        public async Task<ServiceResponse<bool>> IsUserInCouple()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<bool>>("api/invitation/isUserInCouple");
            return response;
        }
    }



}
