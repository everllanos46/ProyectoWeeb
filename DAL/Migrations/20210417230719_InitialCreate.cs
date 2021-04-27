using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asignaturas",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "varchar(10)", nullable: false),
                    NombreAsignatura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creditos = table.Column<int>(type: "int", nullable: false),
                    ProgramaAcademico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HDD = table.Column<int>(type: "int", nullable: false),
                    HTP = table.Column<int>(type: "int", nullable: false),
                    HTI = table.Column<int>(type: "int", nullable: false),
                    HTT = table.Column<int>(type: "int", nullable: false),
                    Prerequisitos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Corequisitos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartamentoOferente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoAsignatura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Habilitable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Validable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Homologable = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaturas", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Docentes",
                columns: table => new
                {
                    Identificacion = table.Column<string>(type: "varchar(10)", nullable: false),
                    Correo = table.Column<string>(type: "varchar(25)", nullable: true),
                    Nombre = table.Column<string>(type: "varchar(20)", nullable: true),
                    Apellido = table.Column<string>(type: "varchar(20)", nullable: true),
                    Direccion = table.Column<string>(type: "varchar(20)", nullable: true),
                    Ciudad = table.Column<string>(type: "varchar(15)", nullable: true),
                    Pais = table.Column<string>(type: "varchar(15)", nullable: true),
                    SobreDocente = table.Column<string>(type: "varchar(300)", nullable: true),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docentes", x => x.Identificacion);
                });

            migrationBuilder.CreateTable(
                name: "PlanAsignaturas",
                columns: table => new
                {
                    CodigoPlan = table.Column<string>(type: "varchar(10)", nullable: false),
                    AsignaturaCodigo = table.Column<string>(type: "varchar(10)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjetivoGeneral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjetivosEspecificos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estrategias = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanAsignaturas", x => x.CodigoPlan);
                    table.ForeignKey(
                        name: "FK_PlanAsignaturas_Asignaturas_AsignaturaCodigo",
                        column: x => x.AsignaturaCodigo,
                        principalTable: "Asignaturas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanAsignaturas_AsignaturaCodigo",
                table: "PlanAsignaturas",
                column: "AsignaturaCodigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Docentes");

            migrationBuilder.DropTable(
                name: "PlanAsignaturas");

            migrationBuilder.DropTable(
                name: "Asignaturas");
        }
    }
}
