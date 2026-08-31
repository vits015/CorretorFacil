using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Seguros.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddArquivoFieldsToApolice2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaminhoArquivo",
                table: "Apolice");

            migrationBuilder.CreateTable(
                name: "ArquivoApolice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApoliceId = table.Column<int>(type: "integer", nullable: false),
                    NomeArquivo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CaminhoArquivo = table.Column<string>(type: "text", nullable: false),
                    ContentType = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    TamanhoBytes = table.Column<long>(type: "bigint", nullable: true),
                    DataUpload = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Excluido = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArquivoApolice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArquivoApolice_Apolice_ApoliceId",
                        column: x => x.ApoliceId,
                        principalTable: "Apolice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArquivoApolice_ApoliceId_CaminhoArquivo",
                table: "ArquivoApolice",
                columns: new[] { "ApoliceId", "CaminhoArquivo" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArquivoApolice");

            migrationBuilder.AddColumn<string>(
                name: "CaminhoArquivo",
                table: "Apolice",
                type: "text",
                nullable: true);
        }
    }
}
