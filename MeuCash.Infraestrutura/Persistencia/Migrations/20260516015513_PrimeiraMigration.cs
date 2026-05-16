using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuCash.Infraestrutura.Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tab_Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "NVARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tab_Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    UserName = table.Column<string>(type: "NVARCHAR(80)", nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(300)", nullable: false),
                    NumeroCelular = table.Column<string>(type: "NVARCHAR(24)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tab_Conta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    SaldoAtual = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_Conta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_Conta_tab_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "tab_Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tab_Despesa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdConta = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    DataDespesa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_Despesa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_Despesa_tab_Categoria_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "tab_Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tab_Despesa_tab_Conta_IdConta",
                        column: x => x.IdConta,
                        principalTable: "tab_Conta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tab_Entrada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdConta = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_Entrada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_Entrada_tab_Conta_IdConta",
                        column: x => x.IdConta,
                        principalTable: "tab_Conta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tab_Meta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR(500)", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdConta = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataLimite = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_Meta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_Meta_tab_Conta_IdConta",
                        column: x => x.IdConta,
                        principalTable: "tab_Conta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tab_Meta_tab_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "tab_Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tab_Conta_IdUsuario",
                table: "tab_Conta",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tab_Despesa_IdCategoria",
                table: "tab_Despesa",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_tab_Despesa_IdConta",
                table: "tab_Despesa",
                column: "IdConta");

            migrationBuilder.CreateIndex(
                name: "IX_tab_Entrada_IdConta",
                table: "tab_Entrada",
                column: "IdConta");

            migrationBuilder.CreateIndex(
                name: "IX_tab_Meta_IdConta",
                table: "tab_Meta",
                column: "IdConta");

            migrationBuilder.CreateIndex(
                name: "IX_tab_Meta_IdUsuario",
                table: "tab_Meta",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tab_Despesa");

            migrationBuilder.DropTable(
                name: "tab_Entrada");

            migrationBuilder.DropTable(
                name: "tab_Meta");

            migrationBuilder.DropTable(
                name: "tab_Categoria");

            migrationBuilder.DropTable(
                name: "tab_Conta");

            migrationBuilder.DropTable(
                name: "tab_Usuarios");
        }
    }
}
