using DisasterManager.Data;
using DisasterManager.Models;
using DisasterManager.Notification;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace DisasterManager.Services.RefugeeCampService.Commands.UpdateRefugeeCamp
{
	public class UpdateRefugeeCampByCampIdHandler(DisasterManagerDbContext context, IHubContext<NotificationHub> hubContext) : IRequestHandler<UpdateRefugeeCampByCampIdCommand, ResponseDTO>
	{
		private readonly DisasterManagerDbContext _context = context;
		private readonly IHubContext<NotificationHub> _hubContext = hubContext;

		public async Task<ResponseDTO> Handle(UpdateRefugeeCampByCampIdCommand request, CancellationToken cancellationToken)
		{
			RefugeeCamp? camp = await _context.RefugeeCamps.FindAsync([request.CampId], cancellationToken);
			if (camp == null)
				return new()
				{
					StatusCode = DefaultMessages.BadRequest.StatusCode,
					Message = ServiceMessages.NoRefugeeCampFound(request.CampId)
				};
			camp.Latitude = request.Latitude;
			camp.Longitude = request.Longitude;
			await _context.SaveChangesAsync(cancellationToken);
			await _hubContext.Clients.All.SendAsync(HubMethods.dataUpdated, cancellationToken);
			return new()
			{
				StatusCode = DefaultMessages.Success.StatusCode,
				Message = ServiceMessages.UpdatedRefugeeCamp(request.CampId)
			};
		}
	}
}
