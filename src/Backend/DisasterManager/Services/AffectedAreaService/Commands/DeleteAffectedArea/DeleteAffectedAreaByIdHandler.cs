using DisasterManager.Data;
using DisasterManager.Models;
using DisasterManager.Notification;
using MediatR;
using Microsoft.AspNet.SignalR;
using Microsoft.EntityFrameworkCore;

namespace DisasterManager.Services.AffectedAreaService.Commands.DeleteAffectedArea
{
    public class DeleteAffectedAreaByIdHandler(DisasterManagerDbContext context, IHubContext<NotificationHub> hubContext) : IRequestHandler<DeleteAffectedAreaByIdCommand, ResponseDTO>
    {
        private readonly DisasterManagerDbContext _context = context;
        private readonly IHubContext<NotificationHub> _hubContext = hubContext;

        public async Task<ResponseDTO> Handle(DeleteAffectedAreaByIdCommand request, CancellationToken cancellationToken)
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

            _context.AffectedAreas.Remove(affectedArea);

            List<RefugeeCamp> camps = await _context.RefugeeCamps.Where(camp => camp.AreaId == request.AreaId).ToListAsync(cancellationToken);
            _context.RefugeeCamps.RemoveRange(camps);

            await _context.SaveChangesAsync(cancellationToken);

            await _hubContext.Clients.All.DataUpdated(cancellationToken);

            return new ResponseDTO
            {
                StatusCode = DefaultMessages.Success.StatusCode,
                Message = ServiceMessages.DeletedAffectedArea(request.AreaId)
            };
        }
    }
}
