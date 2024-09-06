using DisasterManager.Models;
using DisasterManager.Services.AffectedAreaService.Queries.GetAffectedArea;
using MediatR;

namespace DisasterManager.Services.AffectedAreaService.Queries.GetAffectedArea.GetAffectedAreaById
{
    public class GetAffectedAreaByIdQuery : IRequest<ResponseDTO>
    {
        public int AreaId { get; set; }
    }
}
