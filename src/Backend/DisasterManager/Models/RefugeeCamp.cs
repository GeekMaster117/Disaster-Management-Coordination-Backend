using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisasterManager.Models
{
	public class RefugeeCamp
	{
		[Key]
		public int CampId { get; set; }
		[ForeignKey("Area")]
		public int AreaId { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public AffectedArea Area { get; set; } = new AffectedArea();
	}
}
