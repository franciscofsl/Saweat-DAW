﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Saweat.Persistence.Contexts;

#nullable disable

namespace Saweat.Persistence.Migrations
{
    [DbContext(typeof(SaweatDbContext))]
    [Migration("20220531143235_AddNewsPhoto")]
    partial class AddNewsPhoto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Saweat.Domain.Entities.Allergen", b =>
                {
                    b.Property<int>("AllergenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AllergenId"), 1L, 1);

                    b.Property<string>("AllergenCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AllergenId");

                    b.ToTable("Allergens");
                });

            modelBuilder.Entity("Saweat.Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Lastnames")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Email = "adminsaweat@saweat.com",
                            Lastnames = "",
                            Name = "Administrador"
                        });
                });

            modelBuilder.Entity("Saweat.Domain.Entities.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"), 1L, 1);

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PeopleAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Saweat.Domain.Entities.New", b =>
                {
                    b.Property<int>("NewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NewId"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("NewId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("Saweat.Domain.Entities.OpeningPeriod", b =>
                {
                    b.Property<int>("OpeningId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OpeningId"), 1L, 1);

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndHour")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("StartHour")
                        .HasColumnType("time");

                    b.HasKey("OpeningId");

                    b.ToTable("OpeningPeriods", (string)null);

                    b.HasData(
                        new
                        {
                            OpeningId = 1,
                            Day = 1,
                            EndHour = new TimeSpan(0, 16, 0, 0, 0),
                            StartHour = new TimeSpan(0, 13, 0, 0, 0)
                        },
                        new
                        {
                            OpeningId = 2,
                            Day = 1,
                            EndHour = new TimeSpan(0, 0, 0, 0, 0),
                            StartHour = new TimeSpan(0, 20, 0, 0, 0)
                        },
                        new
                        {
                            OpeningId = 3,
                            Day = 2,
                            EndHour = new TimeSpan(0, 16, 0, 0, 0),
                            StartHour = new TimeSpan(0, 13, 0, 0, 0)
                        },
                        new
                        {
                            OpeningId = 4,
                            Day = 2,
                            EndHour = new TimeSpan(0, 0, 0, 0, 0),
                            StartHour = new TimeSpan(0, 20, 0, 0, 0)
                        },
                        new
                        {
                            OpeningId = 5,
                            Day = 3,
                            EndHour = new TimeSpan(0, 16, 0, 0, 0),
                            StartHour = new TimeSpan(0, 13, 0, 0, 0)
                        },
                        new
                        {
                            OpeningId = 6,
                            Day = 3,
                            EndHour = new TimeSpan(0, 0, 0, 0, 0),
                            StartHour = new TimeSpan(0, 20, 0, 0, 0)
                        },
                        new
                        {
                            OpeningId = 7,
                            Day = 4,
                            EndHour = new TimeSpan(0, 16, 0, 0, 0),
                            StartHour = new TimeSpan(0, 13, 0, 0, 0)
                        },
                        new
                        {
                            OpeningId = 8,
                            Day = 4,
                            EndHour = new TimeSpan(0, 0, 0, 0, 0),
                            StartHour = new TimeSpan(0, 20, 0, 0, 0)
                        },
                        new
                        {
                            OpeningId = 9,
                            Day = 5,
                            EndHour = new TimeSpan(0, 16, 0, 0, 0),
                            StartHour = new TimeSpan(0, 13, 0, 0, 0)
                        },
                        new
                        {
                            OpeningId = 10,
                            Day = 5,
                            EndHour = new TimeSpan(0, 0, 0, 0, 0),
                            StartHour = new TimeSpan(0, 20, 0, 0, 0)
                        },
                        new
                        {
                            OpeningId = 11,
                            Day = 6,
                            EndHour = new TimeSpan(0, 0, 0, 0, 0),
                            StartHour = new TimeSpan(0, 13, 0, 0, 0)
                        });
                });

            modelBuilder.Entity("Saweat.Domain.Entities.Restaurant", b =>
                {
                    b.Property<string>("RestaurantId")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("LongDescription")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Provincy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RestaurantId");

                    b.ToTable("Restaurants", (string)null);

                    b.HasData(
                        new
                        {
                            RestaurantId = "sutakito",
                            Address = "Francisco de Quevedo 12, Bajo",
                            City = "Santander",
                            Description = "Sutakito Mexicano",
                            Enabled = true,
                            LongDescription = "La mejor comida mexicana artesanal en Santander",
                            Phone = "642 63 99 73",
                            Photo = "https://sutakitomexicano.com/wp-content/uploads/2021/04/cropped-logo-sutakito.png",
                            PostalCode = "30001",
                            Provincy = "Cantabria"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
