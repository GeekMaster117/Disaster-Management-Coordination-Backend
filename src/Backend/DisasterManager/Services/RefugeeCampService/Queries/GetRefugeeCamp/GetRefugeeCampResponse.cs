using System.ComponentModel.DataAnnotations.Schema;

namespace DisasterManager.Services.RefugeeCampService.Queries.GetRefugeeCamp
{
	public class GetRefugeeCampResponse
	{
		public int CampId { get; set; }
		public int AreaId { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
}
