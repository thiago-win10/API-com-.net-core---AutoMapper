using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microsservices.Products.Infra.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "statusProduto",
                columns: table => new
                {
                    statusProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statusProduto", x => x.statusProdutoId);
                });

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    produtoId = table.Column<string>(type: "varchar(50)", nullable: false),
                    nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    descricao = table.Column<string>(type: "varchar(200)", nullable: true),
                    dataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    dataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    statusProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.produtoId);
                    table.ForeignKey(
                        name: "FK_produto_statusProduto_statusProdutoId",
                        column: x => x.statusProdutoId,
                        principalTable: "statusProduto",
                        principalColumn: "statusProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_produto_statusProdutoId",
                table: "produto",
                column: "statusProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropTable(
                name: "statusProduto");
        }
    }
}
