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
    public virtual DbSet<Allergen> Allergens { get; set; }
    public virtual DbSet<New> News { get; set; }
    public virtual DbSet<FoodPlate> FoodPlates { get; set; }
    public virtual DbSet<FoodPlateType> FoodPlateTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging(true);
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=PCFRAN;Initial Catalog=saweat;Integrated Security=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RestaurantConfiguration());
        modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
        modelBuilder.ApplyConfiguration(new FoodPlateConfiguration());
        modelBuilder.ApplyConfiguration(new FoodPlateTypeConfiguration());

        this.OnModelCreatingPartial(modelBuilder);
    }

    public void Migrate()
    {
        try
        {
            this.Database.Migrate();
        }
        catch (Exception)
        {
        }
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}