using DisasterManager.Models;
using MediatR;

namespace DisasterManager.Services.RefugeeCampService.Queries.GetRefugeeCamp.GetRefugeeCampById
{
    public class GetRefugeeCampByIdCommand : IRequest<ResponseDTO>
    {
        public int CampId { get; set; }
    }
}
