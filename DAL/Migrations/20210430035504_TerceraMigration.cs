using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class TerceraMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanSolicitud_Asignaturas_AsignaturaCodigo",
                table: "PlanSolicitud");

            migrationBuilder.RenameColumn(
                name: "AsignaturaCodigo",
                table: "PlanSolicitud",
                newName: "IdAsignatura");

            migrationBuilder.RenameIndex(
                name: "IX_PlanSolicitud_AsignaturaCodigo",
                table: "PlanSolicitud",
                newName: "IX_PlanSolicitud_IdAsignatura");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanSolicitud_Asignaturas_IdAsignatura",
                table: "PlanSolicitud",
                column: "IdAsignatura",
                principalTable: "Asignaturas",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanSolicitud_Asignaturas_IdAsignatura",
                table: "PlanSolicitud");

            migrationBuilder.RenameColumn(
                name: "IdAsignatura",
                table: "PlanSolicitud",
                newName: "AsignaturaCodigo");

            migrationBuilder.RenameIndex(
                name: "IX_PlanSolicitud_IdAsignatura",
                table: "PlanSolicitud",
                newName: "IX_PlanSolicitud_AsignaturaCodigo");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanSolicitud_Asignaturas_AsignaturaCodigo",
                table: "PlanSolicitud",
                column: "AsignaturaCodigo",
                principalTable: "Asignaturas",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
