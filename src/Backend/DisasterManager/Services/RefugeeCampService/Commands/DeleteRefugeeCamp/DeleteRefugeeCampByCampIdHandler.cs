using DisasterManager.Data;
using DisasterManager.Models;
using DisasterManager.Notification;
using MediatR;
using Microsoft.AspNet.SignalR;

namespace DisasterManager.Services.RefugeeCampService.Commands.DeleteRefugeeCamp
{
	public class DeleteRefugeeCampByCampIdHandler(DisasterManagerDbContext context, IHubContext<NotificationHub> hubContext) : IRequestHandler<DeleteRefugeeCampByCampIdCommand, ResponseDTO>
	{
		private readonly DisasterManagerDbContext _context = context;
		private readonly IHubContext<NotificationHub> _hubContext = hubContext;

		public async Task<ResponseDTO> Handle(DeleteRefugeeCampByCampIdCommand request, CancellationToken cancellationToken)
		{
			RefugeeCamp? camp = await _context.RefugeeCamps.FindAsync([request.CampId], cancellationToken);
			if (camp == null)
				return new()
				{
					StatusCode = DefaultMessages.BadRequest.StatusCode,
					Message = ServiceMessages.NoRefugeeCampFound(request.CampId)
				};
			_context.RefugeeCamps.Remove(camp);
			await _context.SaveChangesAsync(cancellationToken);
			await _hubContext.Clients.All.DataUpdated(cancellationToken);
			return new()
			{
				StatusCode = DefaultMessages.Success.StatusCode,
				Message = ServiceMessages.DeletedRefugeeCamp(request.CampId)
			};
		}
	}
}
