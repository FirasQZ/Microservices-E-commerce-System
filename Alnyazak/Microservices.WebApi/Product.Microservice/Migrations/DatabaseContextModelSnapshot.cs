﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Product.Microservice.Data;

#nullable disable

namespace Product.Microservice.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Product.Microservice.Models.ProductDetails", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductPrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.Property<string>("createdAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("createdBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("updatedAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("updatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("PRODUCT_DETAILS_ENTITY");

                    b.HasData(
                        new
                        {
                            id = 1,
                            ProductName = "Product 1",
                            ProductPrice = "100",
                            ProductQuantity = 10,
                            createdAt = "8/23/2023 10:31:58 PM",
                            createdBy = "User_1",
                            updatedAt = "8/23/2023 10:31:58 PM",
                            updatedBy = "User_1"
                        },
                        new
                        {
                            id = 2,
                            ProductName = "Product 2",
                            ProductPrice = "200",
                            ProductQuantity = 20,
                            createdAt = "8/23/2023 10:31:58 PM",
                            createdBy = "User_1",
                            updatedAt = "8/23/2023 10:31:58 PM",
                            updatedBy = "User_1"
                        },
                        new
                        {
                            id = 3,
                            ProductName = "Product 3",
                            ProductPrice = "300",
                            ProductQuantity = 30,
                            createdAt = "8/23/2023 10:31:58 PM",
                            createdBy = "User_1",
                            updatedAt = "8/23/2023 10:31:58 PM",
                            updatedBy = "User_1"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
