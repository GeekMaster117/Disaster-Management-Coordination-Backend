using DisasterManager.Models;
using MediatR;

namespace DisasterManager.Services.RefugeeCampService.Commands.CreateRefugeeCamp
{
	public class CreateRefugeeCampCommand : IRequest<ResponseDTO>
	{
		public int AreaId { get; set; }
		public double latitude { get; set; }
		public double longitude { get; set; }
	}
}
