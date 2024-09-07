using DisasterManager.Data;
using DisasterManager.Models;
using Mapster;
using MediatR;

namespace DisasterManager.Services.RefugeeCampService.Queries.GetRefugeeCamp.GetRefugeeCampByCampId
{
	public class GetRefugeeCampByCampIdHandler(DisasterManagerDbContext context) : IRequestHandler<GetRefugeeCampByCampIdCommand, ResponseDTO>
	{
		private readonly DisasterManagerDbContext _context = context;

		public async Task<ResponseDTO> Handle(GetRefugeeCampByCampIdCommand request, CancellationToken cancellationToken)
		{
			RefugeeCamp? camp = await _context.RefugeeCamps.FindAsync([request.CampId], cancellationToken);
			if (camp == null)
				return new()
				{
					StatusCode = DefaultMessages.BadRequest.StatusCode,
					Message = ServiceMessages.NoRefugeeCampFound(request.CampId)
				};
			GetRefugeeCampResponse response = camp.Adapt<GetRefugeeCampResponse>();
			return new()
			{
				StatusCode = DefaultMessages.Success.StatusCode,
				Message = response
			};
		}
	}
}
