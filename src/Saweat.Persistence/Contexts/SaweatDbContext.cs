using Microsoft.EntityFrameworkCore;

namespace Saweat.Persistence.Contexts;

public partial class SaweatDbContext : DbContext
{
    public SaweatDbContext()
    {
    }

    public SaweatDbContext(DbContextOptions<SaweatDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=PCFRAN;Initial Catalog=saweat;Integrated Security=True");
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        this.OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}