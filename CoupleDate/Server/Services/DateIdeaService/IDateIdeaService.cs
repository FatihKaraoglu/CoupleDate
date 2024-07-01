using CoupleDate.Shared;

namespace CoupleDate.Server.Services.DateIdeaService
{
    public interface IDateIdeaService
    {
        Task<ServiceResponse<List<DateIdea>>> GetDateIdeasAsync();
        Task<ServiceResponse<string>> SwipeAsync(int dateId, bool liked);
    }
}
