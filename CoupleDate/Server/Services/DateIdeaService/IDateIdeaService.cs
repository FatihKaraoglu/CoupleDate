using CoupleDate.Shared;
using CoupleDate.Shared.DTO;

namespace CoupleDate.Server.Services.DateIdeaService
{
    public interface IDateIdeaService
    {
        Task<ServiceResponse<List<DateIdeaDTO>>> GetDateIdeasAsync();
        Task<ServiceResponse<string>> SwipeAsync(int dateId, bool liked);
    }
}
