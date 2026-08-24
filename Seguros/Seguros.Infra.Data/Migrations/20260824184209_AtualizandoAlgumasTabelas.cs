using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Seguros.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoAlgumasTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DataOcorrencia",
                table: "Sinistro",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<int>(
                name: "ApoliceId",
                table: "Sinistro",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DataVencimento",
                table: "Parcela",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "VigenciaInicio",
                table: "Apolice",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "VigenciaFim",
                table: "Apolice",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateIndex(
                name: "IX_Sinistro_ApoliceId",
                table: "Sinistro",
                column: "ApoliceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sinistro_Apolice_ApoliceId",
                table: "Sinistro",
                column: "ApoliceId",
                principalTable: "Apolice",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sinistro_Apolice_ApoliceId",
                table: "Sinistro");

            migrationBuilder.DropIndex(
                name: "IX_Sinistro_ApoliceId",
                table: "Sinistro");

            migrationBuilder.DropColumn(
                name: "ApoliceId",
                table: "Sinistro");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataOcorrencia",
                table: "Sinistro",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataVencimento",
                table: "Parcela",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "VigenciaInicio",
                table: "Apolice",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "VigenciaFim",
                table: "Apolice",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
