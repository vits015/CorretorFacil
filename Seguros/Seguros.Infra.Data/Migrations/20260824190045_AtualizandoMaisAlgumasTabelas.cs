using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Seguros.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoMaisAlgumasTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Situacao",
                table: "Apolice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Situacao",
                table: "Apolice",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
