﻿// <auto-generated />
using System;
using BirrasBares.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BirrasBares.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240720070946_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BirrasBares.Models.Bar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AccesibilidadDiscapacitados")
                        .HasColumnType("bit");

                    b.Property<string>("Ambiente")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("AñoApertura")
                        .HasColumnType("int");

                    b.Property<decimal>("CalificacionPromedio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Especialidades")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ImagenUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("PermiteReservas")
                        .HasColumnType("bit");

                    b.Property<string>("Propietario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RangoPrecios")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("RedesSociales")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ServiciosAdicionales")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SitioWeb")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("TieneTerraza")
                        .HasColumnType("bit");

                    b.Property<string>("TipoBar")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Bares");
                });

            modelBuilder.Entity("BirrasBares.Models.BarCerveza", b =>
                {
                    b.Property<int>("BarId")
                        .HasColumnType("int");

                    b.Property<int>("CervezaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("BarId", "CervezaId");

                    b.HasIndex("CervezaId");

                    b.ToTable("BaresCervezas");
                });

            modelBuilder.Entity("BirrasBares.Models.Cerveza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Aroma")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("AñoLanzamiento")
                        .HasColumnType("int");

                    b.Property<int?>("Calorias")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("DisponibleTodoElAño")
                        .HasColumnType("bit");

                    b.Property<bool>("EsArtesanal")
                        .HasColumnType("bit");

                    b.Property<string>("Estilo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Graduacion")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("IBU")
                        .HasColumnType("int");

                    b.Property<string>("ImagenUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Maridaje")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PaisOrigen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Sabor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Cervezas");
                });

            modelBuilder.Entity("BirrasBares.Models.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BarId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("BarId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("BirrasBares.Models.HorarioBar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BarId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("DiaSemana")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("HoraApertura")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("HoraCierre")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("BarId");

                    b.ToTable("HorariosBar");
                });

            modelBuilder.Entity("BirrasBares.Models.PlatoMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alergenos")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("BarId")
                        .HasColumnType("int");

                    b.Property<int?>("Calorias")
                        .HasColumnType("int");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("Disponible")
                        .HasColumnType("bit");

                    b.Property<bool>("EsEspecialidad")
                        .HasColumnType("bit");

                    b.Property<bool>("EsSinGluten")
                        .HasColumnType("bit");

                    b.Property<bool>("EsVegano")
                        .HasColumnType("bit");

                    b.Property<bool>("EsVegetariano")
                        .HasColumnType("bit");

                    b.Property<string>("ImagenUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Ingredientes")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Popularidad")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Preparacion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("TamañoPorcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Temporada")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("BarId");

                    b.ToTable("PlatosMenu");
                });

            modelBuilder.Entity("BirrasBares.Models.BarCerveza", b =>
                {
                    b.HasOne("BirrasBares.Models.Bar", "Bar")
                        .WithMany("BaresCervezas")
                        .HasForeignKey("BarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BirrasBares.Models.Cerveza", "Cerveza")
                        .WithMany("BaresCervezas")
                        .HasForeignKey("CervezaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bar");

                    b.Navigation("Cerveza");
                });

            modelBuilder.Entity("BirrasBares.Models.Evento", b =>
                {
                    b.HasOne("BirrasBares.Models.Bar", "Bar")
                        .WithMany("Eventos")
                        .HasForeignKey("BarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bar");
                });

            modelBuilder.Entity("BirrasBares.Models.HorarioBar", b =>
                {
                    b.HasOne("BirrasBares.Models.Bar", "Bar")
                        .WithMany("Horarios")
                        .HasForeignKey("BarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bar");
                });

            modelBuilder.Entity("BirrasBares.Models.PlatoMenu", b =>
                {
                    b.HasOne("BirrasBares.Models.Bar", "Bar")
                        .WithMany("PlatosMenu")
                        .HasForeignKey("BarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bar");
                });

            modelBuilder.Entity("BirrasBares.Models.Bar", b =>
                {
                    b.Navigation("BaresCervezas");

                    b.Navigation("Eventos");

                    b.Navigation("Horarios");

                    b.Navigation("PlatosMenu");
                });

            modelBuilder.Entity("BirrasBares.Models.Cerveza", b =>
                {
                    b.Navigation("BaresCervezas");
                });
#pragma warning restore 612, 618
        }
    }
}
