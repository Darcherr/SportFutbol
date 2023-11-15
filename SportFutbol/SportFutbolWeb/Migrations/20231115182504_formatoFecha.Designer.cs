﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportFutbolWeb.Infrastructure;

#nullable disable

namespace SportFutbolWeb.Migrations
{
    [DbContext(typeof(SportFutbolContext))]
    [Migration("20231115182504_formatoFecha")]
    partial class formatoFecha
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SportFutbolWeb.Domain.Entities.Cancha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImagenCancha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipoRefId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoRefId");

                    b.ToTable("Cancha");
                });

            modelBuilder.Entity("SportFutbolWeb.Domain.Entities.Tarifa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("Precio")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.ToTable("Tarifa");
                });

            modelBuilder.Entity("SportFutbolWeb.Domain.Entities.TipoCancha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("FechaRegistro")
                        .HasColumnType("smalldatetime");

                    b.HasKey("Id");

                    b.ToTable("Tipo");
                });

            modelBuilder.Entity("SportFutbolWeb.Domain.Entities.Turno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("FechaTurno")
                        .HasColumnType("smalldatetime");

                    b.Property<int?>("IdCancha")
                        .HasColumnType("int");

                    b.Property<int?>("IdTarifa")
                        .HasColumnType("int");

                    b.Property<string>("NombreCliente")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdCancha");

                    b.HasIndex("IdTarifa");

                    b.ToTable("Turno");
                });

            modelBuilder.Entity("SportFutbolWeb.Domain.Entities.Cancha", b =>
                {
                    b.HasOne("SportFutbolWeb.Domain.Entities.TipoCancha", "TipoCancha")
                        .WithMany()
                        .HasForeignKey("TipoRefId");

                    b.Navigation("TipoCancha");
                });

            modelBuilder.Entity("SportFutbolWeb.Domain.Entities.Turno", b =>
                {
                    b.HasOne("SportFutbolWeb.Domain.Entities.Cancha", "Cancha")
                        .WithMany()
                        .HasForeignKey("IdCancha");

                    b.HasOne("SportFutbolWeb.Domain.Entities.Tarifa", "Tarifa")
                        .WithMany()
                        .HasForeignKey("IdTarifa");

                    b.Navigation("Cancha");

                    b.Navigation("Tarifa");
                });
#pragma warning restore 612, 618
        }
    }
}