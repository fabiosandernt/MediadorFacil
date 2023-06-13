using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediadorFacil.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConvencoesColetivas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroRegistro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroProcesso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroSolicitacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConvencoesColetivas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sindicatos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoSindicato = table.Column<int>(type: "int", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sindicatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vigencias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataInicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataFim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConvencaoColetivaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vigencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vigencias_ConvencoesColetivas_ConvencaoColetivaId",
                        column: x => x.ConvencaoColetivaId,
                        principalTable: "ConvencoesColetivas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConvencaoColetivaSindicato",
                columns: table => new
                {
                    ConvencaoColetivasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SindicatosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConvencaoColetivaSindicato", x => new { x.ConvencaoColetivasId, x.SindicatosId });
                    table.ForeignKey(
                        name: "FK_ConvencaoColetivaSindicato_ConvencoesColetivas_ConvencaoColetivasId",
                        column: x => x.ConvencaoColetivasId,
                        principalTable: "ConvencoesColetivas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConvencaoColetivaSindicato_Sindicatos_SindicatosId",
                        column: x => x.SindicatosId,
                        principalTable: "Sindicatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConvencaoColetivaSindicato_SindicatosId",
                table: "ConvencaoColetivaSindicato",
                column: "SindicatosId");

            migrationBuilder.CreateIndex(
                name: "IX_Vigencias_ConvencaoColetivaId",
                table: "Vigencias",
                column: "ConvencaoColetivaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConvencaoColetivaSindicato");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Vigencias");

            migrationBuilder.DropTable(
                name: "Sindicatos");

            migrationBuilder.DropTable(
                name: "ConvencoesColetivas");
        }
    }
}
