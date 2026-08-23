using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Seguros.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SituacaoID",
                table: "Apolice");

            migrationBuilder.DropColumn(
                name: "TipoSeguroID",
                table: "Apolice");

            migrationBuilder.AddColumn<string>(
                name: "EstadoCivil",
                table: "Cliente",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Profissao",
                table: "Cliente",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "Cliente",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Produto",
                table: "Apolice",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Situacao",
                table: "Apolice",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoSeguro",
                table: "Apolice",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoPagamento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ValorTotal = table.Column<double>(type: "double precision", maxLength: 50, nullable: false),
                    QuantidadeParcelas = table.Column<int>(type: "integer", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seguradora",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguradora", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sinistro",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SeguroID = table.Column<int>(type: "integer", nullable: false),
                    DataOcorrencia = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NumeroSinistro = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sinistro", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Parcela",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Valor = table.Column<double>(type: "double precision", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PagamentoID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcela_Pagamento_PagamentoID",
                        column: x => x.PagamentoID,
                        principalTable: "Pagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ClienteID = table.Column<int>(type: "integer", nullable: false),
                    SeguradoraID = table.Column<int>(type: "integer", nullable: false),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contato_Cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contato_Seguradora_SeguradoraID",
                        column: x => x.SeguradoraID,
                        principalTable: "Seguradora",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apolice_ClienteID",
                table: "Apolice",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Contato_ClienteID",
                table: "Contato",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Contato_SeguradoraID",
                table: "Contato",
                column: "SeguradoraID");

            migrationBuilder.CreateIndex(
                name: "IX_Parcela_PagamentoID",
                table: "Parcela",
                column: "PagamentoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Apolice_Cliente_ClienteID",
                table: "Apolice",
                column: "ClienteID",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apolice_Cliente_ClienteID",
                table: "Apolice");

            migrationBuilder.DropTable(
                name: "Contato");

            migrationBuilder.DropTable(
                name: "Parcela");

            migrationBuilder.DropTable(
                name: "Sinistro");

            migrationBuilder.DropTable(
                name: "Seguradora");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropIndex(
                name: "IX_Apolice_ClienteID",
                table: "Apolice");

            migrationBuilder.DropColumn(
                name: "EstadoCivil",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Profissao",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Produto",
                table: "Apolice");

            migrationBuilder.DropColumn(
                name: "Situacao",
                table: "Apolice");

            migrationBuilder.DropColumn(
                name: "TipoSeguro",
                table: "Apolice");

            migrationBuilder.AddColumn<int>(
                name: "SituacaoID",
                table: "Apolice",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoSeguroID",
                table: "Apolice",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
