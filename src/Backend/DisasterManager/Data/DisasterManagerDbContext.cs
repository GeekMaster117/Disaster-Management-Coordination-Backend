using DisasterManager.Models;
using Microsoft.EntityFrameworkCore;

namespace DisasterManager.Data
{
	public class DisasterManagerDbContext(DbContextOptions<DisasterManagerDbContext> options)
		: DbContext(options)
	{
		DbSet<AffectedArea> AffectedAreas { get; set; }
		DbSet<RefugeeCamp> RefugeeCamps { get; set; }
	}
}
