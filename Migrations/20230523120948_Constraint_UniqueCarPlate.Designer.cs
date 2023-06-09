﻿// <auto-generated />
using System;
using Infobip.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infobip.Migrations
{
    [DbContext(typeof(CarpoolDbContext))]
    [Migration("20230523120948_Constraint_UniqueCarPlate")]
    partial class Constraint_UniqueCarPlate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("EmployeeTravelPlan", b =>
                {
                    b.Property<int>("EmployeesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TravelPlansId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EmployeesId", "TravelPlansId");

                    b.HasIndex("TravelPlansId");

                    b.ToTable("EmployeeTravelPlan");
                });

            modelBuilder.Entity("Infobip.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CarType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberSeats")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Plate")
                        .IsUnique();

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarType = "Toyota Corolla",
                            Color = "Red",
                            Name = "Toyota Corolla of Alice",
                            NumberSeats = 6,
                            Plate = "ABC-123"
                        },
                        new
                        {
                            Id = 2,
                            CarType = "Ford F-150",
                            Color = "Orange",
                            Name = "Ford F-150 of Bob",
                            NumberSeats = 5,
                            Plate = "DEF-456"
                        },
                        new
                        {
                            Id = 3,
                            CarType = "BMW 3 Series",
                            Color = "Yellow",
                            Name = "BMW 3 Series of Charlie",
                            NumberSeats = 3,
                            Plate = "GHI-789"
                        },
                        new
                        {
                            Id = 4,
                            CarType = "Honda Civic",
                            Color = "Green",
                            Name = "Honda Civic of David",
                            NumberSeats = 6,
                            Plate = "JKL-012"
                        },
                        new
                        {
                            Id = 5,
                            CarType = "Chevrolet Camaro",
                            Color = "Blue",
                            Name = "Chevrolet Camaro of Emma",
                            NumberSeats = 6,
                            Plate = "MNO-345"
                        },
                        new
                        {
                            Id = 6,
                            CarType = "Hyundai Sonata",
                            Color = "Indigo",
                            Name = "Hyundai Sonata of Frank",
                            NumberSeats = 4,
                            Plate = "PQR-678"
                        },
                        new
                        {
                            Id = 7,
                            CarType = "Nissan Altima",
                            Color = "Violet",
                            Name = "Nissan Altima of Grace",
                            NumberSeats = 5,
                            Plate = "STU-901"
                        },
                        new
                        {
                            Id = 8,
                            CarType = "Audi A4",
                            Color = "Black",
                            Name = "Audi A4 of Henry",
                            NumberSeats = 2,
                            Plate = "VWX-234"
                        },
                        new
                        {
                            Id = 9,
                            CarType = "Subaru Outback",
                            Color = "White",
                            Name = "Subaru Outback of Isabel",
                            NumberSeats = 5,
                            Plate = "YZA-567"
                        },
                        new
                        {
                            Id = 10,
                            CarType = "Tesla Model 3",
                            Color = "Gray",
                            Name = "Tesla Model 3 of Jack",
                            NumberSeats = 6,
                            Plate = "BCD-890"
                        });
                });

            modelBuilder.Entity("Infobip.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDriver")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDriver = true,
                            Name = "Anna Smith"
                        },
                        new
                        {
                            Id = 2,
                            IsDriver = true,
                            Name = "Brian Jones"
                        },
                        new
                        {
                            Id = 3,
                            IsDriver = true,
                            Name = "Chloe Wilson"
                        },
                        new
                        {
                            Id = 4,
                            IsDriver = false,
                            Name = "Daniel Lee"
                        },
                        new
                        {
                            Id = 5,
                            IsDriver = false,
                            Name = "Ella Brown"
                        },
                        new
                        {
                            Id = 6,
                            IsDriver = false,
                            Name = "Felix Garcia"
                        },
                        new
                        {
                            Id = 7,
                            IsDriver = false,
                            Name = "Grace Miller"
                        },
                        new
                        {
                            Id = 8,
                            IsDriver = true,
                            Name = "Harry Johnson"
                        },
                        new
                        {
                            Id = 9,
                            IsDriver = false,
                            Name = "Ivy Davis"
                        },
                        new
                        {
                            Id = 10,
                            IsDriver = false,
                            Name = "James Taylor"
                        },
                        new
                        {
                            Id = 11,
                            IsDriver = true,
                            Name = "Kayla Martin"
                        },
                        new
                        {
                            Id = 12,
                            IsDriver = false,
                            Name = "Leo Thompson"
                        },
                        new
                        {
                            Id = 13,
                            IsDriver = true,
                            Name = "Mia Williams"
                        },
                        new
                        {
                            Id = 14,
                            IsDriver = false,
                            Name = "Noah Rodriguez"
                        },
                        new
                        {
                            Id = 15,
                            IsDriver = true,
                            Name = "Olivia Anderson"
                        },
                        new
                        {
                            Id = 16,
                            IsDriver = true,
                            Name = "Ryan Clark"
                        },
                        new
                        {
                            Id = 17,
                            IsDriver = false,
                            Name = "Sophia Lopez"
                        },
                        new
                        {
                            Id = 18,
                            IsDriver = false,
                            Name = "Tyler Lewis"
                        },
                        new
                        {
                            Id = 19,
                            IsDriver = false,
                            Name = "Zoe Walker"
                        },
                        new
                        {
                            Id = 20,
                            IsDriver = false,
                            Name = "Adam White"
                        },
                        new
                        {
                            Id = 21,
                            IsDriver = true,
                            Name = "Bella Harris"
                        },
                        new
                        {
                            Id = 22,
                            IsDriver = false,
                            Name = "Connor Hall"
                        },
                        new
                        {
                            Id = 23,
                            IsDriver = true,
                            Name = "Emma Young"
                        },
                        new
                        {
                            Id = 24,
                            IsDriver = true,
                            Name = "Liam Allen"
                        },
                        new
                        {
                            Id = 25,
                            IsDriver = true,
                            Name = "Nora King"
                        });
                });

            modelBuilder.Entity("Infobip.Models.TravelPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("EndLocation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("StartLocation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TravelPlans");
                });

            modelBuilder.Entity("EmployeeTravelPlan", b =>
                {
                    b.HasOne("Infobip.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infobip.Models.TravelPlan", null)
                        .WithMany()
                        .HasForeignKey("TravelPlansId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
