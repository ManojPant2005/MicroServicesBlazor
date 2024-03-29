﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductApi.Data;

#nullable disable

namespace ProductApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240122143117_Products")]
    partial class Products
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductApi.Data.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Category 2",
                            Description = "Description for Product 1",
                            ImageUrl = "",
                            Name = "Product Name 1",
                            Price = 10.0
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Category 1",
                            Description = "Description for Product 2",
                            ImageUrl = "",
                            Name = "Product Name 2",
                            Price = 20.0
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Category 2",
                            Description = "Description for Product 3",
                            ImageUrl = "",
                            Name = "Product Name 3",
                            Price = 30.0
                        },
                        new
                        {
                            Id = 4,
                            CategoryName = "Category 1",
                            Description = "Description for Product 4",
                            ImageUrl = "",
                            Name = "Product Name 4",
                            Price = 40.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
