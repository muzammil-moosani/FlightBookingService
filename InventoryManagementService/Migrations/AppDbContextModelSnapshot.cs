﻿// <auto-generated />
using System;
using InventoryManagementService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InventoryManagementService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InventoryManagementService.Models.InventoryDetail", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AirlineId");

                    b.Property<DateTime>("EndDateTime");

                    b.Property<int>("FlightNumber");

                    b.Property<string>("FromPlace");

                    b.Property<string>("Instrument");

                    b.Property<string>("Meal");

                    b.Property<int>("NoOfBusinessSeats");

                    b.Property<int>("NoOfNonBusinessSeats");

                    b.Property<int>("NoOfRows");

                    b.Property<string>("ScheduledDays");

                    b.Property<DateTime>("StartDateTime");

                    b.Property<double>("TicketCharges");

                    b.Property<string>("ToPlace");

                    b.HasKey("InventoryId");

                    b.ToTable("InventoryDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
