using Microsoft.AspNetCore.SignalR;

namespace DisasterManager.Notification
{
	public class NotificationHub : Hub
	{
		public async Task DataUpdated(CancellationToken cancellationToken = default)
		{
			await Clients.All.SendAsync("DataUpdated", cancellationToken);
		}
	}
}
