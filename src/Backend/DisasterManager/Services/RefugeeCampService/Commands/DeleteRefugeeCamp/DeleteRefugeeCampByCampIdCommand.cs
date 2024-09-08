using DisasterManager.Models;
using MediatR;

namespace DisasterManager.Services.RefugeeCampService.Commands.DeleteRefugeeCamp
{
	public class DeleteRefugeeCampByCampIdCommand : IRequest<ResponseDTO>
	{
		public int CampId { get; set; }
	}
}
