using DisasterManager.Models;
using MediatR;

namespace DisasterManager.Services.RefugeeCampService.Queries.GetRefugeeCamp.GetRefugeeCampById
{
    public class GetRefugeeCampByCampIdCommand : IRequest<ResponseDTO>
    {
        public int CampId { get; set; }
    }
}
