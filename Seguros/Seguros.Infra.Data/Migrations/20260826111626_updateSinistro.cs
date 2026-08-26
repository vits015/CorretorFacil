using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Seguros.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateSinistro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sinistro_Apolice_ApoliceId",
                table: "Sinistro");

            migrationBuilder.DropColumn(
                name: "SeguroID",
                table: "Sinistro");

            migrationBuilder.AlterColumn<int>(
                name: "ApoliceId",
                table: "Sinistro",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sinistro_Apolice_ApoliceId",
                table: "Sinistro",
                column: "ApoliceId",
                principalTable: "Apolice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sinistro_Apolice_ApoliceId",
                table: "Sinistro");

            migrationBuilder.AlterColumn<int>(
                name: "ApoliceId",
                table: "Sinistro",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "SeguroID",
                table: "Sinistro",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Sinistro_Apolice_ApoliceId",
                table: "Sinistro",
                column: "ApoliceId",
                principalTable: "Apolice",
                principalColumn: "Id");
        }
    }
}
