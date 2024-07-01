using CoupleDate.Server.Data.DataContext;
using CoupleDate.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace CoupleDate.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly DatingDbContext _context;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(DatingDbContext context, IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<string>> Login(string email, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));

            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
            }
            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong Password.";
            }
            else
            {
                response.Data = CreateToken(user);
            }

            return response;
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("IsSubscribed", user.IsSubscribed.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: cred);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            if (await UserExists(user.Email))
                return new ServiceResponse<int> { Success = false, Message = "User already exists." };

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Role = "Free";
            user.IsSubscribed = false;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new ServiceResponse<int> { Data = user.Id, Message = "Registration successful!" };
        }

        public async Task<bool> UserExists(string email)
        {
            return await _context.Users.AnyAsync(user => user.Email.ToLower().Equals(email.ToLower()));
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public async Task<ServiceResponse<bool>> ChangePassword(int userID, string newPassword)
        {
            var user = await _context.Users.FindAsync(userID);
            if (user == null)
                return new ServiceResponse<bool> { Success = false, Message = "User not found." };

            CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true, Message = "Password has been changed", Success = true };
        }

        public int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public string GetUserEmail() => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);

        public async Task<User> GetUserByEmail(string email) => await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));

        public async Task<ServiceResponse<bool>> SubscribeUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return new ServiceResponse<bool> { Success = false, Message = "User not found." };

            user.IsSubscribed = true;
            user.Role = "SubscribedUser";
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true, Message = "User subscribed successfully!", Success = true };
        }

        public async Task<ServiceResponse<bool>> UnsubscribeUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return new ServiceResponse<bool> { Success = false, Message = "User not found." };

            user.IsSubscribed = false;
            user.Role = "Normal";
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true, Message = "User unsubscribed successfully!", Success = true };
        }
    }
}
