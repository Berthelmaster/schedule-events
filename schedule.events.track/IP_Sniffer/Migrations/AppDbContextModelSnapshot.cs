﻿// <auto-generated />
using System;
using IP_Sniffer.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IP_Sniffer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("IP_Sniffer.Models.GeoLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Continent_code")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Country")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Country_area")
                        .HasColumnType("int");

                    b.Property<string>("Country_calling_code")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Country_capital")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Country_code")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Country_name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Country_population")
                        .HasColumnType("int");

                    b.Property<string>("Currency")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Ip")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Languages")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<float>("Latitude")
                        .HasColumnType("float");

                    b.Property<float>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Postal")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Region")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Timezone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("GeoLocations");
                });
#pragma warning restore 612, 618
        }
    }
}
