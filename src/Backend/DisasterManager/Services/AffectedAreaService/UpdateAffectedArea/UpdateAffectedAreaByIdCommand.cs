using MediatR;

namespace DisasterManager.Services.AffectedAreaService.UpdateAffectedArea
{
	public class UpdateAffectedAreaByIdCommand : IRequest<bool>
	{
		public int Id { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public double Radius { get; set; }
		public string DisasterType { get; set; } = "";
		public int Severity { get; set; }
	}
}
