﻿using DisasterManager.Data;
using DisasterManager.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisasterManager.Services.RefugeeCampService.Commands.CreateRefugeeCamp
{
	public class CreateRefugeeCampHandler(DisasterManagerDbContext context) : IRequestHandler<CreateRefugeeCampCommand, ResponseDTO>
	{
		private DisasterManagerDbContext _context = context;

		public async Task<ResponseDTO> Handle(CreateRefugeeCampCommand request, CancellationToken cancellationToken)
		{
			AffectedArea? affectedArea = await _context.AffectedAreas.SingleOrDefaultAsync(area => area.AreaId == request.AreaId, cancellationToken);
			if (affectedArea == null)
				return new()
				{
					StatusCode = DefaultMessages.BadRequest.StatusCode,
					Message = "Cannot find the following affected area"
				};
			RefugeeCamp refugeeCamp = request.Adapt<RefugeeCamp>();
			refugeeCamp.Area = affectedArea;
			await _context.RefugeeCamps.AddAsync(refugeeCamp);
			return new()
			{
				StatusCode = DefaultMessages.Success.StatusCode,
				Message = "Refugee Camp created"
			}
		}
	}
}
