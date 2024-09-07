using DisasterManager.Data;
using DisasterManager.Models;
using DisasterManager.Services.AffectedAreaService.Queries.GetAffectedArea;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisasterManager.Services.AffectedAreaService.Queries.GetAffectedArea.GetAffectedAreaById
{
    public class GetAffectedAreaByAreaIdHandler(DisasterManagerDbContext context) : IRequestHandler<GetAffectedAreaByAreaIdQuery, ResponseDTO>
    {
        private readonly DisasterManagerDbContext _context = context;

        public async Task<ResponseDTO> Handle(GetAffectedAreaByAreaIdQuery request, CancellationToken cancellationToken)
        {
            AffectedArea? affectedArea = await _context.AffectedAreas.FindAsync([request.AreaId], cancellationToken);
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
