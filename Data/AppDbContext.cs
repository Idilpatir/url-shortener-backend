using Microsoft.EntityFrameworkCore;
using url_shortener_backend.Models;

namespace url_shortener_backend.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
	public DbSet<URL> URLs { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<URL>()
			.HasIndex(u => u.EncodedURL)
			.HasDatabaseName("IX_URL_EncodedURL");
	}
}