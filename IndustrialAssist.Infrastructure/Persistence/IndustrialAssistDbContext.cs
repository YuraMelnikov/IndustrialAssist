using IndustrialAssist.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace IndustrialAssist.Infrastructure.Persistence;

public class IndustrialAssistDbContext : DbContext
{
    public IndustrialAssistDbContext(DbContextOptions<IndustrialAssistDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IndustrialAssistDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}