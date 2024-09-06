using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisasterManager.Models
{
	public class RefugeeCamp
	{
		[Key]
		public int CampId { get; set; }
		[ForeignKey("Area")]
		public int AreaID { get; set; }
		public double latitude { get; set; }
		public double longitude { get; set; }
		public AffectedArea Area { get; set; } = new AffectedArea();
	}
}
