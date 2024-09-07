using DisasterManager.Data;
using DisasterManager.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisasterManager.Services.RefugeeCampService.Queries.GetRefugeeCamp.GetAllRefugeeCamps
{
	public class GetAllRefugeeCampsHandler(DisasterManagerDbContext context) : IRequestHandler<GetAllRefugeeCampsQuery, ResponseDTO>
	{
		private readonly DisasterManagerDbContext _context = context;

		public async Task<ResponseDTO> Handle(GetAllRefugeeCampsQuery request, CancellationToken cancellationToken)
		{
			List<GetRefugeeCampResponse> camps = [];
			await _context.RefugeeCamps.ForEachAsync(camp => camps.Add(camp.Adapt<GetRefugeeCampResponse>()), cancellationToken);
			return new()
			{
				StatusCode = DefaultMessages.Success.StatusCode,
				Message = camps
			};
		}
	}
}
