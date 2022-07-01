﻿// <auto-generated />

using Example.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Example.Infrastructure.Migrations;

[DbContext(typeof(ExampleDbContext))]
[Migration("20220629090129_Initial")]
partial class Initial
{
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "6.0.6")
            .HasAnnotation("Relational:MaxIdentifierLength", 128);

        SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

        modelBuilder.Entity("Example.Infrastructure.DomainEntity", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            b.Property<string>("Dupa")
                .HasColumnType("nvarchar(max)");

            b.Property<string>("Name")
                .HasMaxLength(1000)
                .HasColumnType("nvarchar(1000)");

            b.HasKey("Id");

            b.ToTable("DomainEntities");
        });
#pragma warning restore 612, 618
    }
}
