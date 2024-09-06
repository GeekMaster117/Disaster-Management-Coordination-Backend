using DisasterManager.Data;
using DisasterManager.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisasterManager.Services.AffectedAreaService.Commands.UpdateAffectedArea
{
    public class UpdateAffectedAreaByIdHandler : IRequestHandler<UpdateAffectedAreaByIdCommand, ResponseDTO>
    {
        private readonly DisasterManagerDbContext _context;

        public UpdateAffectedAreaByIdHandler(DisasterManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDTO> Handle(UpdateAffectedAreaByIdCommand request, CancellationToken cancellationToken)
        {
            var affectedArea = await _context.AffectedAreas
                .SingleOrDefaultAsync(area => area.AreaId == request.Id, cancellationToken);

            if (affectedArea == null)
            {
                return new ResponseDTO
                {
                    StatusCode = DefaultMessages.BadRequest.StatusCode,
                    Message = ServiceMessages.NoAffectedAreaFound(request.Id)
                };
            }

            affectedArea.Latitude = request.Latitude;
            affectedArea.Longitude = request.Longitude;
            affectedArea.Radius = request.Radius;
            affectedArea.DisasterType = request.DisasterType;
            affectedArea.Severity = request.Severity;

            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseDTO
            {
                StatusCode = DefaultMessages.Success.StatusCode,
                Message = ServiceMessages.UpdatedAffectedArea(request.Id)
            };
        }
    }
}
