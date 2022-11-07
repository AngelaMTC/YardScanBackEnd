﻿// <auto-generated />
using System;
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
    [Migration("20220923150737_CreatedGetSubZoneTextFunc")]
    partial class CreatedGetSubZoneTextFunc
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

            modelBuilder.Entity("Yard_Scan_API.Data.Entities.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Space")
                        .HasColumnType("int");

                    b.Property<int>("SubZoneId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TrackInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TrackOutDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<int>("ZoneId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubZoneId")
                        .IsUnique();

                    b.HasIndex("ZoneId")
                        .IsUnique();

                    b.ToTable("Units");
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

            modelBuilder.Entity("Yard_Scan_API.Data.Views.UnitOnYardView", b =>
                {
                    b.Property<string>("Serial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Space")
                        .HasColumnType("int");

                    b.Property<string>("SubZone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TrackInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TrackOutDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<string>("Zone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToView("units_on_yard");
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

            modelBuilder.Entity("Yard_Scan_API.Data.Entities.Unit", b =>
                {
                    b.HasOne("Yard_Scan_API.Data.Entities.SubZone", "SubZone")
                        .WithOne("Unit")
                        .HasForeignKey("Yard_Scan_API.Data.Entities.Unit", "SubZoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Yard_Scan_API.Data.Entities.Zone", "Zone")
                        .WithOne("Unit")
                        .HasForeignKey("Yard_Scan_API.Data.Entities.Unit", "ZoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubZone");

                    b.Navigation("Zone");
                });

            modelBuilder.Entity("Yard_Scan_API.Data.Entities.SubZone", b =>
                {
                    b.Navigation("Unit")
                        .IsRequired();
                });

            modelBuilder.Entity("Yard_Scan_API.Data.Entities.Zone", b =>
                {
                    b.Navigation("SubZones");

                    b.Navigation("Unit")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
