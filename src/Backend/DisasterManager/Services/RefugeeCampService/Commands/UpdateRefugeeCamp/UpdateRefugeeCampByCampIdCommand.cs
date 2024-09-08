using DisasterManager.Models;
using MediatR;

namespace DisasterManager.Services.RefugeeCampService.Commands.UpdateRefugeeCamp
{
	public class UpdateRefugeeCampByCampIdCommand : IRequest<ResponseDTO>
	{
		public int CampId { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
}
