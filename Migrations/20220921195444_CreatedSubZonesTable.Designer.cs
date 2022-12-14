// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Yard_Scan_API.Data.Context;

#nullable disable

namespace Yard_Scan_API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220921195444_CreatedSubZonesTable")]
    partial class CreatedSubZonesTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Yard_Scan_API.Data.Entities.SubZone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Spaces")
                        .HasColumnType("int");

                    b.Property<int>("ZoneId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ZoneId");

                    b.ToTable("SubZones");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "A",
                            Spaces = 14,
                            ZoneId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "B",
                            Spaces = 14,
                            ZoneId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "C",
                            Spaces = 14,
                            ZoneId = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "D",
                            Spaces = 19,
                            ZoneId = 1
                        });
                });

            modelBuilder.Entity("Yard_Scan_API.Data.Entities.Zone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Zones");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "C4"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Corralito"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Yarda"
                        });
                });

            modelBuilder.Entity("Yard_Scan_API.Data.Entities.SubZone", b =>
                {
                    b.HasOne("Yard_Scan_API.Data.Entities.Zone", "Zone")
                        .WithMany("SubZones")
                        .HasForeignKey("ZoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Zone");
                });

            modelBuilder.Entity("Yard_Scan_API.Data.Entities.Zone", b =>
                {
                    b.Navigation("SubZones");
                });
#pragma warning restore 612, 618
        }
    }
}
