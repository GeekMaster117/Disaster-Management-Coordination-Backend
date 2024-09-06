using DisasterManager.Models;
using MediatR;

namespace DisasterManager.Services.AffectedAreaService.Commands.DeleteAffectedArea
{
    public class DeleteAffectedAreaByIdCommand : IRequest<ResponseDTO>
    {
        public int Id { get; set; }
    }
}
