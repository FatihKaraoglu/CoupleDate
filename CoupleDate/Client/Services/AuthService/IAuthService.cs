using CoupleDate.Shared;

namespace CoupleDate.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(UserRegister register);
        Task<ServiceResponse<string>> Login(UserLogin request);
        Task<ServiceResponse<bool>> ChangePassword(UserChangePassword request);
        Task<bool> IsUserAuthenticated();
        Task<IEnumerable<string>> GetUserRoles();
        Task<string> GetTokenAsync();
        Task Logout();

    }
}
