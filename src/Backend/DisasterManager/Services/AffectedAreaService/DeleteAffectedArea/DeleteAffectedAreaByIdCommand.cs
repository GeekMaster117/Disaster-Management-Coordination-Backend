using MediatR;

namespace DisasterManager.Services.AffectedAreaService.DeleteAffectedArea
{
    public class DeleteAffectedAreaByIdCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
