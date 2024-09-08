using DisasterManager.Data;
using DisasterManager.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisasterManager.Services.RefugeeCampService.Queries.GetRefugeeCamp.GetRefugeeCampsByAreaId
{
	public class GetRefugeeCampsByAreaIdHandler(DisasterManagerDbContext context) : IRequestHandler<GetRefugeeCampsByAreaIdQuery, ResponseDTO>
	{
		private readonly DisasterManagerDbContext _context = context;

		public async Task<ResponseDTO> Handle(GetRefugeeCampsByAreaIdQuery request, CancellationToken cancellationToken)
		{
			bool areaExists = await _context.AffectedAreas.AnyAsync(area => area.AreaId == request.AreaId, cancellationToken);
			if (!areaExists)
				return new()
				{
					StatusCode = DefaultMessages.BadRequest.StatusCode,
					Message = ServiceMessages.NoAffectedAreaFound(request.AreaId)
				};
			List<GetRefugeeCampResponse> camps = [];
			await _context.RefugeeCamps
				.Where(camp => camp.AreaId == request.AreaId)
				.ForEachAsync(camp => camps.Add(camp.Adapt<GetRefugeeCampResponse>()), cancellationToken);
			return new()
			{
				StatusCode = DefaultMessages.Success.StatusCode,
				Message = camps
			};
		}
	}
}
