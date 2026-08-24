using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Seguros.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateContatoConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contato_Cliente_ClienteID",
                table: "Contato");

            migrationBuilder.DropForeignKey(
                name: "FK_Contato_Seguradora_SeguradoraID",
                table: "Contato");

            migrationBuilder.AlterColumn<int>(
                name: "SeguradoraID",
                table: "Contato",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteID",
                table: "Contato",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_Cliente_ClienteID",
                table: "Contato",
                column: "ClienteID",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_Seguradora_SeguradoraID",
                table: "Contato",
                column: "SeguradoraID",
                principalTable: "Seguradora",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contato_Cliente_ClienteID",
                table: "Contato");

            migrationBuilder.DropForeignKey(
                name: "FK_Contato_Seguradora_SeguradoraID",
                table: "Contato");

            migrationBuilder.AlterColumn<int>(
                name: "SeguradoraID",
                table: "Contato",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteID",
                table: "Contato",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_Cliente_ClienteID",
                table: "Contato",
                column: "ClienteID",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_Seguradora_SeguradoraID",
                table: "Contato",
                column: "SeguradoraID",
                principalTable: "Seguradora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
