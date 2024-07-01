namespace CoupleDate.Client.SignalR
{
    using CoupleDate.Client.Services.AuthService;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.SignalR.Client;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    public class SignalRService
    {
        private readonly NavigationManager _navigationManager;
        private readonly ILogger<SignalRService> _logger;
        private readonly IAuthService _authService;
        private HubConnection _hubConnection;
        private bool _isConnected;
        private int _reconnectAttempts;

        public event Action<string> OnMatchReceived;

        public SignalRService(NavigationManager navigationManager, ILogger<SignalRService> logger, IAuthService authService)
        {
            _navigationManager = navigationManager;
            _logger = logger;
            _authService = authService;
        }

        public async Task StartAsync()
        {
            if (_isConnected) return;

            var token = await _authService.GetTokenAsync();
            if (string.IsNullOrEmpty(token))
            {
                _logger.LogError("Token is missing, cannot establish SignalR connection.");
                return;
            }

            _hubConnection = new HubConnectionBuilder()
                .WithUrl(_navigationManager.ToAbsoluteUri("/dateIdeasHub"), options =>
                {
                    options.AccessTokenProvider = () => Task.FromResult(token);
                })
                .Build();

            _hubConnection.On<string>("ReceiveMatchNotification", (message) =>
            {
                _logger.LogInformation($"Match notification received: {message}");
                OnMatchReceived?.Invoke(message);
            });

            _hubConnection.Closed += async (error) =>
            {
                _logger.LogError($"SignalR connection closed: {error?.Message}");
                _isConnected = false;

                if (_reconnectAttempts < 3)
                {
                    _reconnectAttempts++;
                    _logger.LogInformation($"Attempting to reconnect... ({_reconnectAttempts}/3)");
                    await Task.Delay(_reconnectAttempts * 2000); // Exponential backoff
                    await StartAsync();
                }
                else
                {
                    _logger.LogError("Maximum reconnection attempts reached. Stopping reconnection attempts.");
                }
            };

            try
            {
                await _hubConnection.StartAsync();
                _isConnected = true;
                _reconnectAttempts = 0;
                _logger.LogInformation("SignalR Connected");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error starting SignalR connection: {ex.Message}");
                await HandleReconnection();
            }
        }

        private async Task HandleReconnection()
        {
            _isConnected = false;
            if (_reconnectAttempts < 3)
            {
                _reconnectAttempts++;
                _logger.LogInformation($"Attempting to reconnect... ({_reconnectAttempts}/3)");
                await Task.Delay(_reconnectAttempts * 2000); // Exponential backoff
                await StartAsync();
            }
            else
            {
                _logger.LogError("Maximum reconnection attempts reached. Stopping reconnection attempts.");
            }
        }

        public async Task StopAsync()
        {
            if (_hubConnection != null && _isConnected)
            {
                await _hubConnection.StopAsync();
                _isConnected = false;
                _logger.LogInformation("SignalR Disconnected");
            }
        }
    }
}
