using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercicio.API.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoTabelaDeParametros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParametrosCalculoAtraso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiasEmAtraso = table.Column<int>(type: "INTEGER", nullable: false),
                    Multa = table.Column<double>(type: "REAL", nullable: false),
                    JurosPorDia = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametrosCalculoAtraso", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParametrosCalculoAtraso");
        }
    }
}
