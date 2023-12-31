﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prototipos;

#nullable disable

namespace Prototipos.DAL.Migrations
{
    [DbContext(typeof(PrototiposContext))]
    [Migration("20231130080329_Add zonas mesas y reservas tables")]
    partial class Addzonasmesasyreservastables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Prototipos.DAL.Models.Mesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("IdZona")
                        .HasColumnType("int");

                    b.Property<string>("NombreMesa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Personas")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdZona");

                    b.ToTable("Mesas");
                });

            modelBuilder.Entity("Prototipos.DAL.Models.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contacto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstadoReserva")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaReserva")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdMesa")
                        .HasColumnType("int");

                    b.Property<string>("PersonaACargo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdMesa");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Prototipos.DAL.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contraseña")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Prototipos.DAL.Models.Zona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NombreZona")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Zonas");
                });

            modelBuilder.Entity("Prototipos.DAL.Models.Mesa", b =>
                {
                    b.HasOne("Prototipos.DAL.Models.Zona", "Zona")
                        .WithMany("Mesas")
                        .HasForeignKey("IdZona");

                    b.Navigation("Zona");
                });

            modelBuilder.Entity("Prototipos.DAL.Models.Reserva", b =>
                {
                    b.HasOne("Prototipos.DAL.Models.Mesa", "Mesa")
                        .WithMany()
                        .HasForeignKey("IdMesa");

                    b.Navigation("Mesa");
                });

            modelBuilder.Entity("Prototipos.DAL.Models.Zona", b =>
                {
                    b.Navigation("Mesas");
                });
#pragma warning restore 612, 618
        }
    }
}
