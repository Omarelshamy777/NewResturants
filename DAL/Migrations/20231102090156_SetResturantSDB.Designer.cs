﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(ResturantsContext))]
    [Migration("20231102090156_SetResturantSDB")]
    partial class SetResturantSDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerOrder", b =>
                {
                    b.Property<int>("CustomersCustomerID")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("CustomersCustomerID", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("CustomerOrder");
                });

            modelBuilder.Entity("DAL.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("DAL.Models.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodId"));

                    b.Property<string>("Categories")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodPrice")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FoodId");

                    b.ToTable("Food", (string)null);
                });

            modelBuilder.Entity("DAL.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<string>("OrderNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderStaus")
                        .HasColumnType("int");

                    b.Property<double?>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("OrderId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("DAL.Models.Resturant", b =>
                {
                    b.Property<int>("ResturantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResturantID"));

                    b.Property<string>("ResturantName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResturantID");

                    b.ToTable("Resturant", (string)null);
                });

            modelBuilder.Entity("FoodResturant", b =>
                {
                    b.Property<int>("FoodsFoodId")
                        .HasColumnType("int");

                    b.Property<int>("ResturantsResturantID")
                        .HasColumnType("int");

                    b.HasKey("FoodsFoodId", "ResturantsResturantID");

                    b.HasIndex("ResturantsResturantID");

                    b.ToTable("FoodResturant");
                });

            modelBuilder.Entity("OrderResturant", b =>
                {
                    b.Property<int>("OrdersOrderId")
                        .HasColumnType("int");

                    b.Property<int>("ResturantsResturantID")
                        .HasColumnType("int");

                    b.HasKey("OrdersOrderId", "ResturantsResturantID");

                    b.HasIndex("ResturantsResturantID");

                    b.ToTable("OrderResturant");
                });

            modelBuilder.Entity("CustomerOrder", b =>
                {
                    b.HasOne("DAL.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomersCustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodResturant", b =>
                {
                    b.HasOne("DAL.Models.Food", null)
                        .WithMany()
                        .HasForeignKey("FoodsFoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Resturant", null)
                        .WithMany()
                        .HasForeignKey("ResturantsResturantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrderResturant", b =>
                {
                    b.HasOne("DAL.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Resturant", null)
                        .WithMany()
                        .HasForeignKey("ResturantsResturantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
