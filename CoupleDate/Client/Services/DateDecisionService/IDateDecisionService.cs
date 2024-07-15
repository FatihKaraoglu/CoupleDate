using CoupleDate.Shared;
using CoupleDate.Shared.DTO;
using CoupleDate.Shared.RequestObject;

namespace CoupleDate.Client.Services.DateDecisionService
{
    public interface IDateDecisionService
    {
        Task<ServiceResponse<List<DateIdeaDTO>>> GetDateIdeasAsync();
        Task<ServiceResponse<string>> SwipeAsync(SwipeRequest request);
    }

}
