using CoupleDate.Shared;

namespace CoupleDate.Server.Services.MatchService
{
    public interface IMatchService
    {
        Task<ServiceResponse<string>> Swipe(int dateIdeaId, bool liked);
    }
}
