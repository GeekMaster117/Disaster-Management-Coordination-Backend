﻿using DisasterManager.Data;
using DisasterManager.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DisasterManager.Services.AffectedAreaService.Commands.DeleteAffectedArea
{
    public class DeleteAffectedAreaByIdHandler : IRequestHandler<DeleteAffectedAreaByIdCommand, ResponseDTO>
    {
        private readonly DisasterManagerDbContext _context;

        public DeleteAffectedAreaByIdHandler(DisasterManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDTO> Handle(DeleteAffectedAreaByIdCommand request, CancellationToken cancellationToken)
        {
            var affectedArea = await _context.AffectedAreas
                .SingleOrDefaultAsync(area => area.AreaId == request.Id, cancellationToken);

            if (affectedArea == null)
            {
                return new ResponseDTO
                {
                    StatusCode = ResponseMessages.BadRequest.StatusCode,
                    Message = "Cannot find the following affected area"
                };
            }

            _context.AffectedAreas.Remove(affectedArea);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseDTO
            {
                StatusCode = ResponseMessages.Success.StatusCode,
                Message = "Affected area successfully deleted"
            };
        }
    }
}
