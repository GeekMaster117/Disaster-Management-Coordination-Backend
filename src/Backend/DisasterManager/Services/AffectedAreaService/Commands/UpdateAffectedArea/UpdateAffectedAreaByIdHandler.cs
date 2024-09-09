using DisasterManager.Data;
using DisasterManager.Models;
using DisasterManager.Notification;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace DisasterManager.Services.AffectedAreaService.Commands.UpdateAffectedArea
{
    public class UpdateAffectedAreaByIdHandler(DisasterManagerDbContext context, IHubContext<NotificationHub> hubContext) : IRequestHandler<UpdateAffectedAreaByIdCommand, ResponseDTO>
    {
        private readonly DisasterManagerDbContext _context = context;
        private readonly IHubContext<NotificationHub> _hubContext = hubContext;

        public async Task<ResponseDTO> Handle(UpdateAffectedAreaByIdCommand request, CancellationToken cancellationToken)
        {
            AffectedArea? affectedArea = await _context.AffectedAreas.FindAsync([request.AreaId], cancellationToken);

            if (affectedArea == null)
            {
                return new ResponseDTO
                {
                    StatusCode = DefaultMessages.BadRequest.StatusCode,
                    Message = ServiceMessages.NoAffectedAreaFound(request.AreaId)
                };
            }

            affectedArea.Latitude = request.Latitude;
            affectedArea.Longitude = request.Longitude;
            affectedArea.Radius = request.Radius;
            affectedArea.DisasterType = request.DisasterType;
            affectedArea.Severity = request.Severity;

            await _context.SaveChangesAsync(cancellationToken);

			await _hubContext.Clients.All.SendAsync(HubMethods.dataUpdated, cancellationToken);

			return new ResponseDTO
            {
                StatusCode = DefaultMessages.Success.StatusCode,
                Message = ServiceMessages.UpdatedAffectedArea(request.AreaId)
            };
        }
    }
}
