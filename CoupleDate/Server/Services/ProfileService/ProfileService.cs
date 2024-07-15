using CoupleDate.Server.Services.AuthService;
using CoupleDate.Server.Data.DataContext;
using CoupleDate.Shared;
using Microsoft.EntityFrameworkCore;
using System;

namespace CoupleDate.Server.Services.ProfileService
{
    public class ProfileService : IProfileService
    {
        private readonly DatingDbContext _context;
        private readonly IAuthService _authService;

        public ProfileService(DatingDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<User> GetProfile()
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == _authService.GetUserId());
        }

        public async Task<User> GetPartnerProfile()
        {
            var user = await _context.Users.FindAsync(_authService.GetUserId());
            if (user == null || !user.CoupleId.HasValue)
            {
                return null;
            }

            return await _context.Users
                .FirstOrDefaultAsync(u => u.CoupleId == user.CoupleId && u.Id != _authService.GetUserId());
        }

        public async Task<bool> UpdateProfile(User updatedUser)
        {
            var user = await _context.Users.FindAsync(updatedUser.Id);
            if (user == null)
            {
                return false;
            }

            user.Email = updatedUser.Email;
            user.Role = updatedUser.Role;
            user.IsSubscribed = updatedUser.IsSubscribed;
            user.CoupleId = updatedUser.CoupleId;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
