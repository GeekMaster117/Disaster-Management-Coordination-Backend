﻿using DisasterManager.Services.AffectedAreaService.Queries.GetAffectedArea;
using MediatR;

namespace DisasterManager.Services.AffectedAreaService.Queries.GetAffectedArea.GetAllAffectedAreas
{
    public class GetAllAffectedAreasQuery : IRequest<IEnumerable<GetAffectedAreaResponse>>
    {
    }
}