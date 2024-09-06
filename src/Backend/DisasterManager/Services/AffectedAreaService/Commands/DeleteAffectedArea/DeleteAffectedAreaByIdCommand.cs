using MediatR;

namespace DisasterManager.Services.AffectedAreaService.Commands.DeleteAffectedArea
{
    public class DeleteAffectedAreaByIdCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
