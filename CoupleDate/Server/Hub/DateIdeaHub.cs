namespace CoupleDate.Server.Hub
{
    using CoupleDate.Server.Data.DataContext;
    using CoupleDate.Server.Services.AuthService;
    using Microsoft.AspNetCore.SignalR;

    public class DateIdeasHub : Hub
    {
        private readonly IAuthService _authService;
        private readonly DatingDbContext _context;

        public DateIdeasHub(IAuthService authService, DatingDbContext context)
        {
            _authService = authService;
            _context = context;
        }

        public async Task SendMatchNotification(int coupleId, string message)
        {
            Console.WriteLine($"Sending match notification to couple ID: {coupleId} with message: {message}");
            await Clients.Group(coupleId.ToString()).SendAsync("ReceiveMatchNotification", message);
        }

        public override async Task OnConnectedAsync()
        {
            var userId = _authService.GetUserId();
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                Console.WriteLine("User not found, cannot add to group.");
                return;
            }

            var coupleId = user.CoupleId;

            if (coupleId.HasValue)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, coupleId.Value.ToString());
                Console.WriteLine($"User {userId} added to group {coupleId}");
            }
            else
            {
                Console.WriteLine("Couple ID is missing, cannot add user to group.");
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var userId = _authService.GetUserId();
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                Console.WriteLine("User not found, cannot remove from group.");
                return;
            }

            var coupleId = user.CoupleId;

            if (coupleId.HasValue)
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, coupleId.Value.ToString());
                Console.WriteLine($"User {userId} removed from group {coupleId}");
            }
            else
            {
                Console.WriteLine("Couple ID is missing, cannot remove user from group.");
            }

            await base.OnDisconnectedAsync(exception);
        }
    }









}
