using DisasterManager.Data;
using DisasterManager.Models;
using DisasterManager.Services.AffectedAreaService.Queries.GetAffectedArea;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisasterManager.Services.AffectedAreaService.Queries.GetAffectedArea.GetAffectedAreaById
{
    public class GetAffectedAreaByIdHandler(DisasterManagerDbContext context) : IRequestHandler<GetAffectedAreaByIdQuery, ResponseDTO>
    {
        private readonly DisasterManagerDbContext _context = context;

        public async Task<ResponseDTO> Handle(GetAffectedAreaByIdQuery request, CancellationToken cancellationToken)
        {
            AffectedArea? affectedArea = await _context.AffectedAreas.SingleOrDefaultAsync(area => area.AreaId == request.AreaId, cancellationToken);
            if (affectedArea == null)
                return new()
                {
                    StatusCode = DefaultMessages.BadRequest.StatusCode,
                    Message = ServiceMessages.NoAffectedAreaFound(request.AreaId)
				};
            return new()
            {
                StatusCode = DefaultMessages.Success.StatusCode,
                Message = affectedArea
            };

        }
    }
}
