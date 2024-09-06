using MediatR;

namespace DisasterManager.Services.AffectedAreaService.GetAffectedArea.GetAffectedAreaById
{
    public class GetAffectedAreaByIdQuery : IRequest<GetAffectedAreaResponse?>
    {
        public int Id { get; set; }
    }
}
