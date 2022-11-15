namespace Yard_Scan_API.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // Db sets (tables and views)
        public DbSet<Zone> Zones { get; set; }
        public DbSet<SubZone> SubZones { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UnitOnYardView> units_on_yard { get; set; }
        public DbSet<InspectUnitView> unit_on_inspect { get; set; }

        // Configuration and seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Zones 
            modelBuilder.Entity<Zone>()
                .HasIndex(z => z.Name)
                .IsUnique();

            modelBuilder.Entity<Zone>()
                .HasData(
                    new Zone
                    {
                        Id = 1,
                        Name = "C4",
                        Status = false
                    },
                    new Zone
                    {
                        Id = 2,
                        Name = "Corralito",
                        Status = false
                    },
                    new Zone
                    {
                        Id = 3,
                        Name = "Yarda",
                        Status = false
                    },
                    new Zone
                    {
                        Id = 4,
                        Name = "Campañas",
                        Status = false
                    },
                    new Zone
                    {
                        Id = 5,
                        Name = "Avenida",
                        Status = false
                    });

            modelBuilder.Entity<Zone>()
                .Property(z => z.UsagePercentage)
                .HasComputedColumnSql("dbo.zone_usage_percentage([Id])");

            // SubZones
            modelBuilder.Entity<SubZone>()
                .HasOne(s => s.Zone)
                .WithMany(z => z.SubZones);

            modelBuilder.Entity<SubZone>()
                .Property(s => s.UsagePercentage)
                .HasComputedColumnSql("dbo.subzone_usage_percentage([Id], [Spaces])");

            modelBuilder.Entity<SubZone>()
                .HasData(
                new
                {
                    Id = 1,
                    Name = "A",
                    subName = "",
                    ZoneId = 1,
                    Spaces = 14,
                    Status = false
                },
                new
                {
                    Id = 2,
                    Name = "B",
                    subName = "",
                    ZoneId = 1,
                    Spaces = 14,
                    Status = false
                },
                new
                {
                    Id = 3,
                    Name = "C",
                    subName = "",
                    ZoneId = 1,
                    Spaces = 14,
                    Status = false
                },
                new
                {
                    Id = 4,
                    Name = "D",
                    subName = "",
                    ZoneId = 1,
                    Spaces = 19,
                    Status = false
                });

            // Units
            modelBuilder.Entity<UnitOnYardView>(u =>
            {
                u.HasNoKey();
                u.ToView("units_on_yard");
            });

            modelBuilder.Entity<InspectUnitView>(u =>
            {
                u.HasNoKey();
                u.ToView("unit_on_inspect");
            });

            modelBuilder.Entity<Unit>()
                .HasOne(u => u.Zone)
                .WithMany(z => z.Units);

            modelBuilder.Entity<Unit>()
                .HasOne(u => u.SubZone)
                .WithMany(s => s.Units);
        }
    }
}
