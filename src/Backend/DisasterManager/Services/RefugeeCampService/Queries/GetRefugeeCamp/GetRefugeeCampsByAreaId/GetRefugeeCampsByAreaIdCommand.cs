using DisasterManager.Models;
using MediatR;

namespace DisasterManager.Services.RefugeeCampService.Queries.GetRefugeeCamp.GetRefugeeCampsByAreaId
{
	public class GetRefugeeCampsByAreaIdCommand : IRequest<ResponseDTO>
	{
		public int AreaId { get; set; }
	}
}
