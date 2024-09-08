using DisasterManager.Data;
using DisasterManager.Models;
using MediatR;

namespace DisasterManager.Services.RefugeeCampService.Commands.DeleteRefugeeCamp
{
	public class DeleteRefugeeCampByCampIdHandler(DisasterManagerDbContext context) : IRequestHandler<DeleteRefugeeCampByCampIdCommand, ResponseDTO>
	{
		private readonly DisasterManagerDbContext _context = context;

		public async Task<ResponseDTO> Handle(DeleteRefugeeCampByCampIdCommand request, CancellationToken cancellationToken)
		{
			RefugeeCamp? camp = await _context.RefugeeCamps.FindAsync([request.CampId], cancellationToken);
			if (camp == null)
				return new()
				{
					StatusCode = DefaultMessages.BadRequest.StatusCode,
					Message = ServiceMessages.NoRefugeeCampFound(request.CampId)
				};
			_context.RefugeeCamps.Remove(camp);
			await _context.SaveChangesAsync(cancellationToken);
			return new()
			{
				StatusCode = DefaultMessages.Success.StatusCode,
				Message = ServiceMessages.DeletedRefugeeCamp(request.CampId)
			};
		}
	}
}
