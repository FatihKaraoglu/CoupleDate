using Blazored.LocalStorage;
using CoupleDate.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using System.Security.Claims;

namespace CoupleDate.Client.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorageService;

        public AuthService(HttpClient http, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorageService)
        {
            _http = http;
            _authStateProvider = authStateProvider;
            _localStorageService = localStorageService;
        }

        public async Task<ServiceResponse<bool>> ChangePassword(UserChangePassword request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/change-password", request.Password);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }

        public async Task<bool> IsUserAuthenticated()
        {
            return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }

        public async Task<ServiceResponse<string>> Login(UserLogin request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/login", request);
            var response = await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();

            if (response.Success)
            {
                await _localStorageService.SetItemAsync("authToken", response.Data);
                ((CustomAuthStateProvider)_authStateProvider).NotifyUserAuthentication(response.Data);
            }

            return response;
        }

        public async Task<ServiceResponse<int>> Register(UserRegister register)
        {
            var result = await _http.PostAsJsonAsync("api/auth/register", register);
            var response = await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();

            if (response.Success)
            {
                var loginRequest = new UserLogin { Email = register.Email, Password = register.Password };
                await Login(loginRequest);
            }

            return response;
        }

        public async Task<IEnumerable<string>> GetUserRoles()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            if (user.Identity.IsAuthenticated)
            {
                var roles = user.Claims
                    .Where(c => c.Type == ClaimTypes.Role)
                    .Select(c => c.Value);

                return roles;
            }

            return Enumerable.Empty<string>();
        }

        public async Task<string> GetTokenAsync()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                return await _localStorageService.GetItemAsync<string>("authToken");
            }
            return null;
        }

        public async Task Logout()
        {
            await _localStorageService.RemoveItemAsync("authToken");
            ((CustomAuthStateProvider)_authStateProvider).NotifyUserLogout();
            _http.DefaultRequestHeaders.Authorization = null;
        }
    }
}
