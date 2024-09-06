using DisasterManager.Data;
using DisasterManager.Models;
using DisasterManager.Services.AffectedAreaService.Queries.GetAffectedArea;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisasterManager.Services.AffectedAreaService.Queries.GetAffectedArea.GetAllAffectedAreas
{
    public class GetAllAffectedAreasHandler(DisasterManagerDbContext context) : IRequestHandler<GetAllAffectedAreasQuery, IEnumerable<GetAffectedAreaResponse>>
    {
        private readonly DisasterManagerDbContext _context = context;

        public async Task<IEnumerable<GetAffectedAreaResponse>> Handle(GetAllAffectedAreasQuery request, CancellationToken cancellationToken)
        {
            List<GetAffectedAreaResponse> affectedAreas = [];
            await _context.AffectedAreas.ForEachAsync(area => affectedAreas.Add(area.Adapt<GetAffectedAreaResponse>()), cancellationToken);
            return affectedAreas;
        }
    }
}
