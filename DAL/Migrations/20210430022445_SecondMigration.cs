using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanSolicitud",
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
                    table.PrimaryKey("PK_PlanSolicitud", x => x.CodigoPlan);
                    table.ForeignKey(
                        name: "FK_PlanSolicitud_Asignaturas_AsignaturaCodigo",
                        column: x => x.AsignaturaCodigo,
                        principalTable: "Asignaturas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Solicitudes",
                columns: table => new
                {
                    CodigoSolicitud = table.Column<string>(type: "varchar(10)", nullable: false),
                    PlanSolicitudCodigoPlan = table.Column<string>(type: "varchar(10)", nullable: true),
                    Solicitante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => x.CodigoSolicitud);
                    table.ForeignKey(
                        name: "FK_Solicitudes_PlanSolicitud_PlanSolicitudCodigoPlan",
                        column: x => x.PlanSolicitudCodigoPlan,
                        principalTable: "PlanSolicitud",
                        principalColumn: "CodigoPlan",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanSolicitud_AsignaturaCodigo",
                table: "PlanSolicitud",
                column: "AsignaturaCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_PlanSolicitudCodigoPlan",
                table: "Solicitudes",
                column: "PlanSolicitudCodigoPlan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solicitudes");

            migrationBuilder.DropTable(
                name: "PlanSolicitud");
        }
    }
}
