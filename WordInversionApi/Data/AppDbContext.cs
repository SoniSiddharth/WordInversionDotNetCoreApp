using Microsoft.EntityFrameworkCore;
using WordInversionApi.Models;

namespace WordInversionApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<WordInversion> WordInversions => Set<WordInversion>();
}
