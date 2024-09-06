using AuthenticationAPI.Models;
using DisasterManager.Data;
using DisasterManager.Models;
using Mapster;
using MediatR;

namespace DisasterManager.Services.AffectedAreaService.CreateAffectedArea
{
    public class CreateAffectedAreaHandler(DisasterManagerDbContext context) : IRequestHandler<CreateAffectedAreaCommand, ResponseDTO>
    {
        private readonly DisasterManagerDbContext _context = context;

        public async Task<ResponseDTO> Handle(CreateAffectedAreaCommand request, CancellationToken cancellationToken)
        {
            AffectedArea affectedArea = request.Adapt<AffectedArea>();
            await _context.AffectedAreas.AddAsync(affectedArea, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return new()
            {
                StatusCode = ResponseMessages.Success.StatusCode,
                Message = "Affected Area created"
            };
        }
    }
}
