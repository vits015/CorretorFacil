using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Seguros.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoApolices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apolice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClienteID = table.Column<int>(type: "integer", nullable: false),
                    VigenciaInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VigenciaFim = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SeguradoraID = table.Column<int>(type: "integer", nullable: false),
                    TipoSeguroID = table.Column<int>(type: "integer", nullable: false),
                    SituacaoID = table.Column<int>(type: "integer", nullable: false),
                    PagamentoID = table.Column<int>(type: "integer", nullable: false),
                    PremioLiquido = table.Column<double>(type: "double precision", nullable: false),
                    Comissao = table.Column<double>(type: "double precision", nullable: false),
                    Excluido = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apolice", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apolice");
        }
    }
}
