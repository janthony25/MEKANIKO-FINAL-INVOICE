﻿// <auto-generated />
using System;
using MEKANIKO_FINAL_INVOICE.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MEKANIKO_FINAL_INVOICE.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240819100142_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MEKANIKO_FINAL_INVOICE.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarId"));

                    b.Property<string>("CarModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("CarPaymentStatus")
                        .HasColumnType("bit");

                    b.Property<string>("CarRego")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("MEKANIKO_FINAL_INVOICE.Models.CarMake", b =>
                {
                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("MakeId")
                        .HasColumnType("int");

                    b.HasKey("CarId", "MakeId");

                    b.HasIndex("MakeId");

                    b.ToTable("CarMakes");
                });

            modelBuilder.Entity("MEKANIKO_FINAL_INVOICE.Models.Customer", b =>
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

                    b.Property<bool?>("PaymentStatus")
                        .HasColumnType("bit");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MEKANIKO_FINAL_INVOICE.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceId"));

                    b.Property<decimal?>("AmountPaid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<string>("IssueName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("LaborPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentTerm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("ShippingFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TaxAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("InvoiceId");

                    b.HasIndex("CarId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("MEKANIKO_FINAL_INVOICE.Models.InvoiceItem", b =>
                {
                    b.Property<int>("InvoiceItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceItemId"));

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ItemPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ItemTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("InvoiceItemId");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceItems");
                });

            modelBuilder.Entity("MEKANIKO_FINAL_INVOICE.Models.Make", b =>
                {
                    b.Property<int>("MakeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MakeId"));

                    b.Property<string>("MakeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MakeId");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("MEKANIKO_FINAL_INVOICE.Models.Car", b =>
                {
                    b.HasOne("MEKANIKO_FINAL_INVOICE.Models.Customer", "Customer")
                        .WithMany("Car")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("MEKANIKO_FINAL_INVOICE.Models.CarMake", b =>
                {
                    b.HasOne("MEKANIKO_FINAL_INVOICE.Models.Car", "Car")
                        .WithMany("CarMake")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MEKANIKO_FINAL_INVOICE.Models.Make", "Make")
                        .WithMany("CarMake")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Make");
                });

            modelBuilder.Entity("MEKANIKO_FINAL_INVOICE.Models.Invoice", b =>
                {
                    b.HasOne("MEKANIKO_FINAL_INVOICE.Models.Car", "Car")
                        .WithMany("Invoice")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("MEKANIKO_FINAL_INVOICE.Models.InvoiceItem", b =>
                {
                    b.HasOne("MEKANIKO_FINAL_INVOICE.Models.Invoice", "Invoice")
                        .WithMany("InvoiceItem")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("MEKANIKO_FINAL_INVOICE.Models.Car", b =>
                {
                    b.Navigation("CarMake");

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("MEKANIKO_FINAL_INVOICE.Models.Customer", b =>
                {
                    b.Navigation("Car");
                });

            modelBuilder.Entity("MEKANIKO_FINAL_INVOICE.Models.Invoice", b =>
                {
                    b.Navigation("InvoiceItem");
                });

            modelBuilder.Entity("MEKANIKO_FINAL_INVOICE.Models.Make", b =>
                {
                    b.Navigation("CarMake");
                });
#pragma warning restore 612, 618
        }
    }
}
