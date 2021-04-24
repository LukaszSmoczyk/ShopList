﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopList.Data;

namespace ShopList.Migrations
{
    [DbContext(typeof(ShopListDbContext))]
    [Migration("20210424205204_ListUpdate2")]
    partial class ListUpdate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShopList.Data.Entities.List", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ListName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lists");
                });

            modelBuilder.Entity("ShopList.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfAddingItem")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ListId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quantity")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ListId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ShopList.Data.Entities.Product", b =>
                {
                    b.HasOne("ShopList.Data.Entities.List", null)
                        .WithMany("Products")
                        .HasForeignKey("ListId");
                });

            modelBuilder.Entity("ShopList.Data.Entities.List", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
