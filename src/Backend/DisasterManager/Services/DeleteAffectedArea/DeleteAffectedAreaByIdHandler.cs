using DisasterManager.Data;
using DisasterManager.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisasterManager.Services.DeleteAffectedArea
{
	public class DeleteAffectedAreaByIdHandler(DisasterManagerDbContext context) : IRequestHandler<DeleteAffectedAreaByIdCommand, bool>
	{
		private readonly DisasterManagerDbContext _context = context;

		public async Task<bool> Handle(DeleteAffectedAreaByIdCommand request, CancellationToken cancellationToken)
		{
			AffectedArea? affectedArea = await _context.AffectedAreas.SingleOrDefaultAsync(area => area.AreaId == request.Id, cancellationToken);
			if (affectedArea == null)
				return false;
			_context.AffectedAreas.Remove(affectedArea);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
