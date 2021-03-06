﻿// <auto-generated />
using System;
using IGSService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IGSService.Migrations
{
    [DbContext(typeof(IGSServiceContext))]
    [Migration("20201112131041_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IGSService.Models.Products", b =>
                {
                    b.Property<int>("ProductCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.HasKey("ProductCode");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductCode = 1,
                            Name = "Lavender heart",
                            Price = 9.25
                        },
                        new
                        {
                            ProductCode = 2,
                            Name = "Personalised cufflinks",
                            Price = 45.0
                        },
                        new
                        {
                            ProductCode = 3,
                            Name = "Kids T-shirt",
                            Price = 19.949999999999999
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
