using DisasterManager.Data;
using DisasterManager.Models;
using DisasterManager.Notification;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace DisasterManager.Services.RefugeeCampService.Commands.CreateRefugeeCamp
{
	public class CreateRefugeeCampHandler(DisasterManagerDbContext context, IHubContext<NotificationHub> hubContext) : IRequestHandler<CreateRefugeeCampCommand, ResponseDTO>
	{
		private readonly DisasterManagerDbContext _context = context;
		private readonly IHubContext<NotificationHub> _hubContext = hubContext;

		public async Task<ResponseDTO> Handle(CreateRefugeeCampCommand request, CancellationToken cancellationToken)
		{
			AffectedArea? affectedArea = await _context.AffectedAreas.FindAsync([request.AreaId], cancellationToken);
			if (affectedArea == null)
				return new()
				{
					StatusCode = DefaultMessages.BadRequest.StatusCode,
					Message = ServiceMessages.NoAffectedAreaFound(request.AreaId)
				};
			RefugeeCamp refugeeCamp = request.Adapt<RefugeeCamp>();
			refugeeCamp.Area = affectedArea;
			await _context.RefugeeCamps.AddAsync(refugeeCamp, cancellationToken);
			await _context.SaveChangesAsync(cancellationToken);
			await _hubContext.Clients.All.SendAsync(HubMethods.dataUpdated, cancellationToken);
			return new()
			{
				StatusCode = DefaultMessages.Success.StatusCode,
				Message = ServiceMessages.CreatedRefugeeCamp
			};
		}
	}
}
