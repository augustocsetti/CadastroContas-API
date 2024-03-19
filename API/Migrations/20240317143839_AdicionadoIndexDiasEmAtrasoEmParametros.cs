using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercicio.API.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoIndexDiasEmAtrasoEmParametros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParametrosCalculoAtraso");

            migrationBuilder.CreateTable(
                name: "ParametrosCalculo",
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
                    table.PrimaryKey("PK_ParametrosCalculo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParametrosCalculo_DiasEmAtraso",
                table: "ParametrosCalculo",
                column: "DiasEmAtraso",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParametrosCalculo");

            migrationBuilder.CreateTable(
                name: "ParametrosCalculoAtraso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiasEmAtraso = table.Column<int>(type: "INTEGER", nullable: false),
                    JurosPorDia = table.Column<double>(type: "REAL", nullable: false),
                    Multa = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametrosCalculoAtraso", x => x.Id);
                });
        }
    }
}
