using CoupleDate.Shared;
using CoupleDate.Shared.RequestObject;

namespace CoupleDate.Client.Services.DateDecisionService
{
    public interface IDateDecisionService
    {
        Task<ServiceResponse<List<DateIdea>>> GetDateIdeasAsync();
        Task<ServiceResponse<string>> SwipeAsync(SwipeRequest request);
    }

}
