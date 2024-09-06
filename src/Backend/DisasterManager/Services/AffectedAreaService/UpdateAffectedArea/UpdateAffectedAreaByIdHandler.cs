using DisasterManager.Data;
using DisasterManager.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisasterManager.Services.AffectedAreaService.UpdateAffectedArea
{
	public class UpdateAffectedAreaByIdHandler(DisasterManagerDbContext context) : IRequestHandler<UpdateAffectedAreaByIdCommand, bool>
	{
		private readonly DisasterManagerDbContext _context = context;

		public async Task<bool> Handle(UpdateAffectedAreaByIdCommand request, CancellationToken cancellationToken)
		{
			AffectedArea? affectedArea = await _context.AffectedAreas.SingleOrDefaultAsync(area => area.AreaId == request.Id, cancellationToken);
			if (affectedArea == null)
				return false;
			affectedArea.Latitude = request.Latitude;
			affectedArea.Longitude = request.Longitude;
			affectedArea.Radius = request.Radius;
			affectedArea.DisasterType = request.DisasterType;
			affectedArea.Severity = request.Severity;
			await _context.SaveChangesAsync(cancellationToken);
			return true;
		}
	}
}
