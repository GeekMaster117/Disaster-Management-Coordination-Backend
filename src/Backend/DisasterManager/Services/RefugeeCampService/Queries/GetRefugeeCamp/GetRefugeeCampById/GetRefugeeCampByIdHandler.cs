﻿using DisasterManager.Data;
using DisasterManager.Models;
using Mapster;
using MediatR;

namespace DisasterManager.Services.RefugeeCampService.Queries.GetRefugeeCamp.GetRefugeeCampById
{
	public class GetRefugeeCampByIdHandler(DisasterManagerDbContext context) : IRequestHandler<GetRefugeeCampByIdCommand, ResponseDTO>
	{
		private readonly DisasterManagerDbContext _context = context;

		public async Task<ResponseDTO> Handle(GetRefugeeCampByIdCommand request, CancellationToken cancellationToken)
		{
			RefugeeCamp? camp = await _context.RefugeeCamps.FindAsync([request.CampId], cancellationToken);
			if (camp == null)
				return new()
				{
					StatusCode = DefaultMessages.BadRequest.StatusCode,
					Message = ServiceMessages.NoRefugeeCampFound(request.CampId)
				};
			GetRefugeeCampByIdResponse response = camp.Adapt<GetRefugeeCampByIdResponse>();
			return new()
			{
				StatusCode = DefaultMessages.Success.StatusCode,
				Message = response
			};
		}
	}
}
