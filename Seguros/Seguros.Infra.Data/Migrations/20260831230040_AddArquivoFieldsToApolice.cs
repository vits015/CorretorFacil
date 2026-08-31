using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Seguros.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddArquivoFieldsToApolice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "linkApolice",
                table: "Apolice");

            migrationBuilder.AddColumn<string>(
                name: "CaminhoArquivo",
                table: "Apolice",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkArquivos",
                table: "Apolice",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaminhoArquivo",
                table: "Apolice");

            migrationBuilder.DropColumn(
                name: "LinkArquivos",
                table: "Apolice");

            migrationBuilder.AddColumn<string>(
                name: "linkApolice",
                table: "Apolice",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
