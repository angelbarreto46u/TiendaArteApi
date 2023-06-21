﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TiendaArteApi.Datos;

#nullable disable

namespace TiendaArteApi.Migrations
{
    [DbContext(typeof(TiendaContext))]
    partial class TiendaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TiendaArteApi.Models.Comisiones", b =>
                {
                    b.Property<int>("ComisionCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComisionCode"));

                    b.Property<string>("ClienteName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaEntrega")
                        .HasColumnType("datetime2");

                    b.HasKey("ComisionCode");

                    b.ToTable("RegistroComision");
                });

            modelBuilder.Entity("TiendaArteApi.Models.Inventario", b =>
                {
                    b.Property<string>("ProductCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("float");

                    b.Property<int>("ProductUnit")
                        .HasColumnType("int");

                    b.HasKey("ProductCode");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            ProductCode = "PROD-1",
                            ProductDescription = "",
                            ProductName = "Sticker de pepapig",
                            ProductPrice = 2500.0,
                            ProductUnit = 5
                        });
                });

            modelBuilder.Entity("TiendaArteApi.Models.Ventas", b =>
                {
                    b.Property<int>("VentasCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VentasCode"));

                    b.Property<string>("ClienteName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaEntrega")
                        .HasColumnType("datetime2");

                    b.Property<double>("PrecioVenta")
                        .HasColumnType("float");

                    b.Property<string>("Solicitud")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VentasCode");

                    b.ToTable("RegistroVentas");

                    b.HasData(
                        new
                        {
                            VentasCode = 1,
                            ClienteName = "Juanito",
                            Direccion = "Mi casa",
                            FechaEntrega = new DateTime(2023, 6, 19, 14, 38, 53, 948, DateTimeKind.Local).AddTicks(1977),
                            PrecioVenta = 300.0,
                            Solicitud = "Librox3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}