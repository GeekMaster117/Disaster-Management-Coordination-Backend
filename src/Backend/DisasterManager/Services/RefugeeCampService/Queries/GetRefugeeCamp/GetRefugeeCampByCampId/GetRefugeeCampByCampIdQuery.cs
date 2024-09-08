using DisasterManager.Models;
using MediatR;

namespace DisasterManager.Services.RefugeeCampService.Queries.GetRefugeeCamp.GetRefugeeCampByCampId
{
	public class GetRefugeeCampByCampIdQuery : IRequest<ResponseDTO>
	{
		public int CampId { get; set; }
	}
}
