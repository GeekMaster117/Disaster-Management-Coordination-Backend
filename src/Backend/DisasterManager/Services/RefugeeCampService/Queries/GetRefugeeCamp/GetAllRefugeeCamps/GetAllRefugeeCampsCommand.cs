﻿using DisasterManager.Models;
using MediatR;

namespace DisasterManager.Services.RefugeeCampService.Queries.GetRefugeeCamp.GetAllRefugeeCamps
{
	public class GetAllRefugeeCampsCommand : IRequest<ResponseDTO>
	{
	}
}
