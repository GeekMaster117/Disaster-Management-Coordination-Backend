using DisasterManager.Services.AffectedAreaService.Queries.GetAffectedArea;
using MediatR;

namespace DisasterManager.Services.AffectedAreaService.Queries.GetAffectedArea.GetAffectedAreaById
{
    public class GetAffectedAreaByIdQuery : IRequest<GetAffectedAreaResponse?>
    {
        public int Id { get; set; }
    }
}
