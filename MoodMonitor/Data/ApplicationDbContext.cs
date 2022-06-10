using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoodMonitor.Models;

namespace MoodMonitor.Data;

public class ApplicationDbContext : IdentityDbContext {

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options) { }

	public DbSet<MoodModel> Moods { get; set; }

	protected override void OnModelCreating(ModelBuilder builder) {
		base.OnModelCreating(builder);

		builder.Entity<MoodModel>()
			.Property(p => p.CreatedAt)
			.HasDefaultValueSql("datetime()");

		builder.Entity<MoodModel>()
			.HasKey(m => new { m.ID, m.UserID });
	}
}