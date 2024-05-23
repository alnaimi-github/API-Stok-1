﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240430123511_Two")]
    partial class Two
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StockId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "I love this company",
                            CreatedOn = new DateTime(2024, 5, 1, 1, 35, 9, 372, DateTimeKind.Local).AddTicks(5957),
                            StockId = 1,
                            Title = "Great Company"
                        },
                        new
                        {
                            Id = 2,
                            Content = "I love this company",
                            CreatedOn = new DateTime(2024, 5, 1, 1, 35, 9, 372, DateTimeKind.Local).AddTicks(5960),
                            StockId = 2,
                            Title = "Great Company"
                        });
                });

            modelBuilder.Entity("API.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Industry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("LastDividend")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<long>("MarketCap")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Purchase")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stocks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyName = "Apple Inc",
                            Industry = "Technology",
                            LastDividend = 0.82m,
                            MarketCap = 2000000000L,
                            Purchase = 120.00m,
                            Symbol = "AAPL"
                        },
                        new
                        {
                            Id = 2,
                            CompanyName = "Microsoft Corporation",
                            Industry = "Technology",
                            LastDividend = 1.56m,
                            MarketCap = 1000000000L,
                            Purchase = 200.00m,
                            Symbol = "MSFT"
                        });
                });

            modelBuilder.Entity("API.Models.Comment", b =>
                {
                    b.HasOne("API.Models.Stock", "Stock")
                        .WithMany("Comments")
                        .HasForeignKey("StockId");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("API.Models.Stock", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
