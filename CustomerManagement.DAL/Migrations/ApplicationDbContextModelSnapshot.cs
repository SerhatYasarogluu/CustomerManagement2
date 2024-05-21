﻿// <auto-generated />
using System;
using CustomerManagement.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerManagement.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerManagement.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Customer");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("CustomerManagement.Entities.CorporateCustomer", b =>
                {
                    b.HasBaseType("CustomerManagement.Entities.Customer");

                    b.Property<string>("TaskNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("CorporateCustomer");
                });

            modelBuilder.Entity("CustomerManagement.Entities.IndivialCustomer", b =>
                {
                    b.HasBaseType("CustomerManagement.Entities.Customer");

                    b.Property<DateTime>("DateBirhh")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("IndivialCustomer");
                });
#pragma warning restore 612, 618
        }
    }
}
