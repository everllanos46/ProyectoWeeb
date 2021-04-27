﻿// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(AsignaturaContext))]
    [Migration("20210417230719_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.Asignatura", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Corequisitos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Creditos")
                        .HasColumnType("int");

                    b.Property<string>("DepartamentoOferente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HDD")
                        .HasColumnType("int");

                    b.Property<int>("HTI")
                        .HasColumnType("int");

                    b.Property<int>("HTP")
                        .HasColumnType("int");

                    b.Property<int>("HTT")
                        .HasColumnType("int");

                    b.Property<string>("Habilitable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Homologable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreAsignatura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prerequisitos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgramaAcademico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoAsignatura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Validable")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("Asignaturas");
                });

            modelBuilder.Entity("Entity.Docente", b =>
                {
                    b.Property<string>("Identificacion")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Apellido")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Ciudad")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Correo")
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Direccion")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Pais")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("SobreDocente")
                        .HasColumnType("varchar(300)");

                    b.HasKey("Identificacion");

                    b.ToTable("Docentes");
                });

            modelBuilder.Entity("Entity.PlanAsignatura", b =>
                {
                    b.Property<string>("CodigoPlan")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("AsignaturaCodigo")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estrategias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ObjetivoGeneral")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ObjetivosEspecificos")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodigoPlan");

                    b.HasIndex("AsignaturaCodigo");

                    b.ToTable("PlanAsignaturas");
                });

            modelBuilder.Entity("Entity.PlanAsignatura", b =>
                {
                    b.HasOne("Entity.Asignatura", "Asignatura")
                        .WithMany()
                        .HasForeignKey("AsignaturaCodigo");

                    b.Navigation("Asignatura");
                });
#pragma warning restore 612, 618
        }
    }
}
