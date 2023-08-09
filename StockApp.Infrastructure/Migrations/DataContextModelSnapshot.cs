﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StockApp.Infrastructure.Data;

#nullable disable

namespace StockApp.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("StockApp.Domain.Entities.Acceptance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Acceptance");
                });

            modelBuilder.Entity("StockApp.Domain.Entities.AcceptanceGoods", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AcceptanceId")
                        .HasColumnType("integer");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<int>("GoodId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AcceptanceId");

                    b.HasIndex("GoodId");

                    b.ToTable("AcceptanceGoods");
                });

            modelBuilder.Entity("StockApp.Domain.Entities.Good", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("PurchasePrice")
                        .HasPrecision(20, 2)
                        .HasColumnType("numeric(20,2)");

                    b.Property<decimal>("SellingPrice")
                        .HasPrecision(20, 2)
                        .HasColumnType("numeric(20,2)");

                    b.Property<int>("Units")
                        .HasColumnType("integer");

                    b.Property<string>("VendorCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Good");
                });

            modelBuilder.Entity("StockApp.Domain.Entities.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Sale");
                });

            modelBuilder.Entity("StockApp.Domain.Entities.SaleGoods", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<int>("GoodId")
                        .HasColumnType("integer");

                    b.Property<int>("SaleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GoodId");

                    b.HasIndex("SaleId");

                    b.ToTable("SaleGoods");
                });

            modelBuilder.Entity("StockApp.Domain.Entities.AcceptanceGoods", b =>
                {
                    b.HasOne("StockApp.Domain.Entities.Acceptance", "Acceptance")
                        .WithMany("AcceptanceGoods")
                        .HasForeignKey("AcceptanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_AcceptanceGoods_Acceptance");

                    b.HasOne("StockApp.Domain.Entities.Good", "Good")
                        .WithMany("AcceptanceGoods")
                        .HasForeignKey("GoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_AcceptanceGoods_Good");

                    b.Navigation("Acceptance");

                    b.Navigation("Good");
                });

            modelBuilder.Entity("StockApp.Domain.Entities.SaleGoods", b =>
                {
                    b.HasOne("StockApp.Domain.Entities.Good", "Good")
                        .WithMany("SaleGoods")
                        .HasForeignKey("GoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_SaleGoods_Good");

                    b.HasOne("StockApp.Domain.Entities.Sale", "Sale")
                        .WithMany("SaleGoods")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_SaleGoods_Sale");

                    b.Navigation("Good");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("StockApp.Domain.Entities.Acceptance", b =>
                {
                    b.Navigation("AcceptanceGoods");
                });

            modelBuilder.Entity("StockApp.Domain.Entities.Good", b =>
                {
                    b.Navigation("AcceptanceGoods");

                    b.Navigation("SaleGoods");
                });

            modelBuilder.Entity("StockApp.Domain.Entities.Sale", b =>
                {
                    b.Navigation("SaleGoods");
                });
#pragma warning restore 612, 618
        }
    }
}
