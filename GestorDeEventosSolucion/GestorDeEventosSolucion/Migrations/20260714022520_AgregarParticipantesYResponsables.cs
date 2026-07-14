using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorDeEventosSolucion.Migrations
{
    /// <inheritdoc />
    public partial class AgregarParticipantesYResponsables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParticipanteId",
                table: "Eventos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentificationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Responsables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsables", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_ParticipanteId",
                table: "Eventos",
                column: "ParticipanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_ResponsableId",
                table: "Eventos",
                column: "ResponsableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Participantes_ParticipanteId",
                table: "Eventos",
                column: "ParticipanteId",
                principalTable: "Participantes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Responsables_ResponsableId",
                table: "Eventos",
                column: "ResponsableId",
                principalTable: "Responsables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Participantes_ParticipanteId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Responsables_ResponsableId",
                table: "Eventos");

            migrationBuilder.DropTable(
                name: "Participantes");

            migrationBuilder.DropTable(
                name: "Responsables");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_ParticipanteId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_ResponsableId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "ParticipanteId",
                table: "Eventos");
        }
    }
}
