﻿using DisasterManager.Data;
using DisasterManager.Models;
using DisasterManager.Services.AffectedAreaService.Queries.GetAffectedArea;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisasterManager.Services.AffectedAreaService.Queries.GetAffectedArea.GetAffectedAreaById
{
    public class GetAffectedAreaByIdHandler(DisasterManagerDbContext context) : IRequestHandler<GetAffectedAreaByIdQuery, GetAffectedAreaResponse?>
    {
        private readonly DisasterManagerDbContext _context = context;

        public async Task<GetAffectedAreaResponse?> Handle(GetAffectedAreaByIdQuery request, CancellationToken cancellationToken)
        {
            AffectedArea? affectedArea = await _context.AffectedAreas.SingleOrDefaultAsync(area => area.AreaId == request.Id, cancellationToken);
            if (affectedArea == null)
                return null;
            return affectedArea.Adapt<GetAffectedAreaResponse>();
        }
    }
}