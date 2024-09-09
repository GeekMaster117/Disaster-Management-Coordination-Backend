using DisasterManager.Models;
using DisasterManager.Data;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using DisasterManager.Notification;

namespace DisasterManager.Services.AffectedAreaService.Commands.CreateAffectedArea
{
    public class CreateAffectedAreaHandler(DisasterManagerDbContext context, IHubContext<NotificationHub> hubContext) : IRequestHandler<CreateAffectedAreaCommand, ResponseDTO>
    {
        private readonly DisasterManagerDbContext _context = context;
        private readonly IHubContext<NotificationHub> _hubContext = hubContext;

        public async Task<ResponseDTO> Handle(CreateAffectedAreaCommand request, CancellationToken cancellationToken)
        {
            AffectedArea affectedArea = request.Adapt<AffectedArea>();
            await _context.AffectedAreas.AddAsync(affectedArea, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
			await _hubContext.Clients.All.SendAsync(HubMethods.dataUpdated, cancellationToken);
			return new()
            {
                StatusCode = DefaultMessages.Success.StatusCode,
                Message = ServiceMessages.CreatedAffectedArea
            };
        }
    }
}
