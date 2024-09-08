using DisasterManager.Models;
using MediatR;

namespace DisasterManager.Services.RefugeeCampService.Commands.CreateRefugeeCamp
{
	public class CreateRefugeeCampCommand : IRequest<ResponseDTO>
	{
		public int AreaId { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
}
