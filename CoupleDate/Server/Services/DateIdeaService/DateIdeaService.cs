using CoupleDate.Server.Data.DataContext;
using CoupleDate.Server.Services.AuthService;
using CoupleDate.Shared;
using Microsoft.EntityFrameworkCore;

namespace CoupleDate.Server.Services.DateIdeaService
{
    public class DateIdeaService : IDateIdeaService
    {
        private readonly DatingDbContext _context;
        private readonly IAuthService _authService;

        public DateIdeaService(DatingDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<ServiceResponse<List<DateIdea>>> GetDateIdeasAsync()
        {
            var response = new ServiceResponse<List<DateIdea>>();
            var userId = _authService.GetUserId();

            try
            {
                var swipedDateIds = await _context.UserSwipes
                    .Where(us => us.UserId == userId)
                    .Select(us => us.DateIdeaId)
                    .ToListAsync();

                var unswipedDateIdeas = await _context.DateIdeas
                    .Where(di => !swipedDateIds.Contains(di.Id))
                    .ToListAsync();

                response.Data = unswipedDateIdeas;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<string>> SwipeAsync(int dateId, bool liked)
        {
            var response = new ServiceResponse<string>();
            var userId = _authService.GetUserId();
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
                return response;
            }

            var coupleId = user.CoupleId;

            if (!coupleId.HasValue)
            {
                response.Success = false;
                response.Message = "User is not part of a couple.";
                return response;
            }

            try
            {
                var userSwipe = new UserSwipe
                {
                    UserId = userId,
                    DateIdeaId = dateId,
                    CoupleId = coupleId.Value,
                    Liked = liked
                };

                _context.UserSwipes.Add(userSwipe);
                await _context.SaveChangesAsync();

                // Check for a match
                if (liked)
                {
                    var isMatch = await _context.UserSwipes.AnyAsync(us =>
                        us.DateIdeaId == dateId &&
                        us.CoupleId == coupleId.Value &&
                        us.UserId != userId &&
                        us.Liked);

                    if (isMatch)
                    {
                        response.Data = "It's a match!";
                    }
                }

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
