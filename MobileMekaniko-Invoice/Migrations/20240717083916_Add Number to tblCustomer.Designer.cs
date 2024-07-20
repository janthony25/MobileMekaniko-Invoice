﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MobileMekaniko_Invoice.Data;

#nullable disable

namespace MobileMekaniko_Invoice.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240717083916_Add Number to tblCustomer")]
    partial class AddNumbertotblCustomer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MobileMekaniko_Invoice.Models.Entities.tblCar", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarId"));

                    b.Property<string>("CarModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarRego")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.HasIndex("CustomerId");

                    b.ToTable("tblCar");
                });

            modelBuilder.Entity("MobileMekaniko_Invoice.Models.Entities.tblCarMake", b =>
                {
                    b.Property<int>("CarMakeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarMakeId"));

                    b.Property<string>("CarMakeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarMakeId");

                    b.ToTable("tblCarMake");
                });

            modelBuilder.Entity("MobileMekaniko_Invoice.Models.Entities.tblCarManufacturer", b =>
                {
                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("CarMakeId")
                        .HasColumnType("int");

                    b.HasKey("CarId", "CarMakeId");

                    b.HasIndex("CarMakeId");

                    b.ToTable("tblCarManufacturer");
                });

            modelBuilder.Entity("MobileMekaniko_Invoice.Models.Entities.tblCustomer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("tblCustomer");
                });

            modelBuilder.Entity("MobileMekaniko_Invoice.Models.Entities.tblCar", b =>
                {
                    b.HasOne("MobileMekaniko_Invoice.Models.Entities.tblCustomer", "tblCustomer")
                        .WithMany("tblCar")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tblCustomer");
                });

            modelBuilder.Entity("MobileMekaniko_Invoice.Models.Entities.tblCarManufacturer", b =>
                {
                    b.HasOne("MobileMekaniko_Invoice.Models.Entities.tblCar", "tblCar")
                        .WithMany("tblCarManufacturer")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MobileMekaniko_Invoice.Models.Entities.tblCarMake", "tblCarMake")
                        .WithMany("tblCarManufacturer")
                        .HasForeignKey("CarMakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tblCar");

                    b.Navigation("tblCarMake");
                });

            modelBuilder.Entity("MobileMekaniko_Invoice.Models.Entities.tblCar", b =>
                {
                    b.Navigation("tblCarManufacturer");
                });

            modelBuilder.Entity("MobileMekaniko_Invoice.Models.Entities.tblCarMake", b =>
                {
                    b.Navigation("tblCarManufacturer");
                });

            modelBuilder.Entity("MobileMekaniko_Invoice.Models.Entities.tblCustomer", b =>
                {
                    b.Navigation("tblCar");
                });
#pragma warning restore 612, 618
        }
    }
}
