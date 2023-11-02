﻿// <auto-generated />
using System;
using MAS_2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MAS_2.Migrations
{
    [DbContext(typeof(MVCDBContext))]
    [Migration("20230620115326_MakeNumerTelefonuNullable")]
    partial class MakeNumerTelefonuNullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MAS_2.Models.Klient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumerTelefonu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Klient");
                });

            modelBuilder.Entity("MAS_2.Models.MateracLateksowy", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Cecha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Cena")
                        .HasColumnType("real");

                    b.Property<string>("Przeznaczenie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rodzaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sztywnosc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<float>("Wysokosc")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.ToTable("MateracLateksowy");
                });

            modelBuilder.Entity("MAS_2.Models.Zgloszenie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DataZainicjalizowania")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataZrealizowania")
                        .HasColumnType("datetime2");

                    b.Property<int>("KlientID")
                        .HasColumnType("int");

                    b.Property<int>("MateracLateksowyID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("KlientID");

                    b.HasIndex("MateracLateksowyID");

                    b.ToTable("Zgloszenies");
                });

            modelBuilder.Entity("MAS_2.Models.Zgloszenie", b =>
                {
                    b.HasOne("MAS_2.Models.Klient", "Klient")
                        .WithMany()
                        .HasForeignKey("KlientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MAS_2.Models.MateracLateksowy", "MateracLateksowy")
                        .WithMany()
                        .HasForeignKey("MateracLateksowyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Klient");

                    b.Navigation("MateracLateksowy");
                });
#pragma warning restore 612, 618
        }
    }
}
