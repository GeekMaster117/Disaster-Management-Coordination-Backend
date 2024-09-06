using DisasterManager.Models;
using DisasterManager.Data;
using DisasterManager.Services.AffectedAreaService.Queries.GetAffectedArea;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisasterManager.Services.AffectedAreaService.Queries.GetAffectedArea.GetAllAffectedAreas
{
    public class GetAllAffectedAreasHandler(DisasterManagerDbContext context) : IRequestHandler<GetAllAffectedAreasQuery, ResponseDTO>
    {
        private readonly DisasterManagerDbContext _context = context;

        public async Task<ResponseDTO> Handle(GetAllAffectedAreasQuery request, CancellationToken cancellationToken)
        {
            List<GetAffectedAreaResponse> affectedAreas = [];
            await _context.AffectedAreas.ForEachAsync(area => affectedAreas.Add(area.Adapt<GetAffectedAreaResponse>()), cancellationToken);
            return new()
            {
                StatusCode = DefaultMessages.Success.StatusCode,
                Message = affectedAreas
            };
        }
    }
}
