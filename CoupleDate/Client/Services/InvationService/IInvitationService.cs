using CoupleDate.Shared;

namespace CoupleDate.Client.Services.InvationService
{
    public interface IInvitationService
    {
        Task<ServiceResponse<string>> GenerateInvitationLinkAsync();
        Task<ServiceResponse<string>> AcceptInvitationAsync(string token);
    }
}
