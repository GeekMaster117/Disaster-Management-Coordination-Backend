using DisasterManager.Models;
using Microsoft.EntityFrameworkCore;

namespace DisasterManager.Data
{
	public class DisasterManagerDbContext(DbContextOptions<DisasterManagerDbContext> options)
		: DbContext(options)
	{
		public DbSet<AffectedArea> AffectedAreas { get; set; }
		public DbSet<RefugeeCamp> RefugeeCamps { get; set; }
	}
}
