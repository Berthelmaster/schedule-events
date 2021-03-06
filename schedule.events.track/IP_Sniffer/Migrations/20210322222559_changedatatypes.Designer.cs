// <auto-generated />
using IP_Sniffer.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IP_Sniffer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210322222559_changedatatypes")]
    partial class changedatatypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("As")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("City")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Country")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CountryCode")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Isp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<float>("Lat")
                        .HasColumnType("float");

                    b.Property<float>("Lon")
                        .HasColumnType("float");

                    b.Property<string>("Org")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Query")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Region")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("RegionName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Timezone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Zip")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("GeoLocations");
                });
#pragma warning restore 612, 618
        }
    }
}
