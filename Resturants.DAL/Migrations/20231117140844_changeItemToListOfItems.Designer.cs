﻿// <auto-generated />
using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Resturants.DAL;

#nullable disable

namespace Resturants.DAL.Migrations
{
    [DbContext(typeof(ResturantsContext))]
    [Migration("20231117140844_changeItemToListOfItems")]
    partial class changeItemToListOfItems
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

            modelBuilder.Entity("DAL.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<string>("Categories")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("ItemPrice")
                        .HasColumnType("float");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.HasIndex("MenuId");

                    b.ToTable("Item", (string)null);
                });

            modelBuilder.Entity("DAL.Models.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuId"));

                    b.Property<string>("MenuName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MenuId");

                    b.ToTable("Menu", (string)null);
                });

            modelBuilder.Entity("DAL.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("OrderNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderStaus")
                        .HasColumnType("int");

                    b.Property<int?>("ResturantID")
                        .HasColumnType("int");

                    b.Property<double?>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerID");

                    b.HasIndex("ResturantID");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("DAL.Models.Resturant", b =>
                {
                    b.Property<int>("ResturantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResturantID"));

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("ResturantName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResturantID");

                    b.HasIndex("ItemId");

                    b.HasIndex("MenuId");

                    b.ToTable("Resturant", (string)null);
                });

            modelBuilder.Entity("ItemOrder", b =>
                {
                    b.Property<int>("ItemsItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("ItemsItemId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("ItemOrder");
                });

            modelBuilder.Entity("DAL.Models.Item", b =>
                {
                    b.HasOne("DAL.Models.Menu", "Menus")
                        .WithMany("Items")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menus");
                });

            modelBuilder.Entity("DAL.Models.Order", b =>
                {
                    b.HasOne("DAL.Models.Customer", "Customers")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Resturant", null)
                        .WithMany("Orders")
                        .HasForeignKey("ResturantID");

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("DAL.Models.Resturant", b =>
                {
                    b.HasOne("DAL.Models.Item", null)
                        .WithMany("Resturants")
                        .HasForeignKey("ItemId");

                    b.HasOne("DAL.Models.Menu", "Menus")
                        .WithMany("Resturants")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menus");
                });

            modelBuilder.Entity("ItemOrder", b =>
                {
                    b.HasOne("DAL.Models.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemsItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Models.Item", b =>
                {
                    b.Navigation("Resturants");
                });

            modelBuilder.Entity("DAL.Models.Menu", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("Resturants");
                });

            modelBuilder.Entity("DAL.Models.Resturant", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
