using DisasterManager.Data;
using DisasterManager.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisasterManager.Services.RefugeeCampService.Commands.CreateRefugeeCamp
{
	public class CreateRefugeeCampHandler(DisasterManagerDbContext context) : IRequestHandler<CreateRefugeeCampCommand, ResponseDTO>
	{
		private readonly DisasterManagerDbContext _context = context;

		public async Task<ResponseDTO> Handle(CreateRefugeeCampCommand request, CancellationToken cancellationToken)
		{
			AffectedArea? affectedArea = await _context.AffectedAreas.FindAsync([request.AreaId], cancellationToken);
			if (affectedArea == null)
				return new()
				{
					StatusCode = DefaultMessages.BadRequest.StatusCode,
					Message = ServiceMessages.NoAffectedAreaFound(request.AreaId)
				};
			RefugeeCamp refugeeCamp = request.Adapt<RefugeeCamp>();
			refugeeCamp.Area = affectedArea;
			await _context.RefugeeCamps.AddAsync(refugeeCamp, cancellationToken);
			await _context.SaveChangesAsync(cancellationToken);
			return new()
			{
				StatusCode = DefaultMessages.Success.StatusCode,
				Message = ServiceMessages.CreatedRefugeeCamp
			};
		}
	}
}
