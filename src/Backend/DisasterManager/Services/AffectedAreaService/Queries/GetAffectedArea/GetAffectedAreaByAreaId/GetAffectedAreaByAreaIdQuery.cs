using DisasterManager.Models;
using DisasterManager.Services.AffectedAreaService.Queries.GetAffectedArea;
using MediatR;

namespace DisasterManager.Services.AffectedAreaService.Queries.GetAffectedArea.GetAffectedAreaById
{
    public class GetAffectedAreaByAreaIdQuery : IRequest<ResponseDTO>
    {
        public int AreaId { get; set; }
    }
}
