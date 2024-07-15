using CoupleDate.Shared;

namespace CoupleDate.Server.Services.ProfileService
{
    public interface IProfileService
    {
        Task<User> GetProfile();
        Task<User> GetPartnerProfile();
        Task<bool> UpdateProfile(User updatedUser);
    }
}
