using System.ComponentModel.DataAnnotations;

namespace DisasterManager.Models
{
	public class AffectedArea
	{
		[Key]
		public int AreaId { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public double Radius { get; set; }
		public string DisasterType { get; set; } = "";
		public int Severity { get; set; }
	}
}
