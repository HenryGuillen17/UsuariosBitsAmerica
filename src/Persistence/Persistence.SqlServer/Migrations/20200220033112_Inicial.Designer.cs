﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.SqlServer;

namespace Persistence.SqlServer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200220033112_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Dao.Ciudad", b =>
                {
                    b.Property<int>("CiudadId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("CiudadId");

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("Models.Dao.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<int>("CiudadId");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("DireccionResidencia")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("NumeroDocumento")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PrimerNombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("SegundoApellido")
                        .HasMaxLength(50);

                    b.Property<string>("SegundoNombre")
                        .HasMaxLength(50);

                    b.Property<string>("Telefono")
                        .HasMaxLength(25);

                    b.Property<byte>("TipoDocumento");

                    b.HasKey("UsuarioId");

                    b.HasIndex("CiudadId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Models.Dao.Usuario", b =>
                {
                    b.HasOne("Models.Dao.Ciudad", "Ciudad")
                        .WithMany("Usuarios")
                        .HasForeignKey("CiudadId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
