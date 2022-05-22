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

    public virtual DbSet<Restaurant> Restaurants { get; set; }
    public virtual DbSet<ApplicationUser> Users { get; set; }
    public virtual DbSet<Booking> Bookings { get; set; }
    public virtual DbSet<OpeningPeriod> OpeningPeriods { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer("Data Source=PCFRAN;Initial Catalog=saweat;Integrated Security=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OpeningPeriodConfiguration());
        modelBuilder.ApplyConfiguration(new RestaurantConfiguration());
        modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    public void Migrate()
    {
        try
        {
            this.Database.Migrate();
        }
        catch (Exception ex)
        {
        }
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}