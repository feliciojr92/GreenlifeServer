using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GreenlifeServer.Migrations
{
    public partial class Banco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ENDERECO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rua = table.Column<string>(maxLength: 80, nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Cidade = table.Column<string>(maxLength: 20, nullable: true),
                    Cep = table.Column<string>(maxLength: 9, nullable: true),
                    Estado = table.Column<string>(maxLength: 20, nullable: true),
                    Bairro = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ENDERECO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_TESTEMUNHA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 80, nullable: false),
                    Cpf = table.Column<string>(maxLength: 20, nullable: false),
                    Telefone = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TESTEMUNHA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimeiroNome = table.Column<string>(maxLength: 30, nullable: false),
                    Sobrenome = table.Column<string>(maxLength: 80, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Senha = table.Column<string>(maxLength: 15, nullable: false),
                    NivelAcesso = table.Column<string>(maxLength: 10, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: true),
                    Rg = table.Column<string>(maxLength: 9, nullable: true),
                    Telefone = table.Column<string>(maxLength: 11, nullable: true),
                    TipoSanguineo = table.Column<string>(maxLength: 3, nullable: true),
                    EnderecoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_USUARIO_TB_ENDERECO_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "TB_ENDERECO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_DEPOIMENTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(maxLength: 15, nullable: false),
                    Mensagem = table.Column<string>(maxLength: 250, nullable: false),
                    Foto = table.Column<string>(maxLength: 800, nullable: true),
                    DataPublicacao = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DEPOIMENTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_DEPOIMENTO_TB_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TB_USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_DOCUMENTO_DOADOR",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(nullable: false),
                    TestemunhaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DOCUMENTO_DOADOR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_DOCUMENTO_DOADOR_TB_TESTEMUNHA_TestemunhaId",
                        column: x => x.TestemunhaId,
                        principalTable: "TB_TESTEMUNHA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_DOCUMENTO_DOADOR_TB_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TB_USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_MIDIA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(maxLength: 30, nullable: false),
                    Mensagem = table.Column<string>(nullable: false),
                    Arquivo = table.Column<string>(nullable: false),
                    DataPostagem = table.Column<DateTime>(nullable: false),
                    Fonte = table.Column<string>(nullable: false),
                    Substituto = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MIDIA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_MIDIA_TB_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TB_USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_DEPOIMENTO_UsuarioId",
                table: "TB_DEPOIMENTO",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_DOCUMENTO_DOADOR_TestemunhaId",
                table: "TB_DOCUMENTO_DOADOR",
                column: "TestemunhaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_DOCUMENTO_DOADOR_UsuarioId",
                table: "TB_DOCUMENTO_DOADOR",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MIDIA_UsuarioId",
                table: "TB_MIDIA",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIO_EnderecoId",
                table: "TB_USUARIO",
                column: "EnderecoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_DEPOIMENTO");

            migrationBuilder.DropTable(
                name: "TB_DOCUMENTO_DOADOR");

            migrationBuilder.DropTable(
                name: "TB_MIDIA");

            migrationBuilder.DropTable(
                name: "TB_TESTEMUNHA");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");

            migrationBuilder.DropTable(
                name: "TB_ENDERECO");
        }
    }
}
