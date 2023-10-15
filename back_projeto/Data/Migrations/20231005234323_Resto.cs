using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Resto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SobreNome",
                table: "Usuarios",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Perfil",
                table: "Usuarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SenhaHash",
                table: "Usuarios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstitutoId",
                table: "Enderecos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PontoDoacaoId",
                table: "Enderecos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VoluntariadoId",
                table: "Enderecos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Institutos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    Perfil = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    SenhaHash = table.Column<string>(type: "TEXT", nullable: true),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logins_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PontoDoacaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeLocal = table.Column<string>(type: "TEXT", nullable: true),
                    MateriasAceito = table.Column<int>(type: "INTEGER", nullable: false),
                    InstitutoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontoDoacaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PontoDoacaos_Institutos_InstitutoId",
                        column: x => x.InstitutoId,
                        principalTable: "Institutos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Voluntariados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 800, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voluntariados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voluntariados_Institutos_Id",
                        column: x => x.Id,
                        principalTable: "Institutos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialDoacaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Tipo = table.Column<int>(type: "INTEGER", nullable: false),
                    PontoDoacaoId = table.Column<int>(type: "INTEGER", nullable: true),
                    InstitutoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialDoacaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialDoacaos_Institutos_InstitutoId",
                        column: x => x.InstitutoId,
                        principalTable: "Institutos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaterialDoacaos_PontoDoacaos_PontoDoacaoId",
                        column: x => x.PontoDoacaoId,
                        principalTable: "PontoDoacaos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VoluntariadoBeneficios",
                columns: table => new
                {
                    Beneficio = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    VoluntariadoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoluntariadoBeneficios", x => x.Beneficio);
                    table.ForeignKey(
                        name: "FK_VoluntariadoBeneficios_Voluntariados_VoluntariadoId",
                        column: x => x.VoluntariadoId,
                        principalTable: "Voluntariados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoluntariadoResponsabilidades",
                columns: table => new
                {
                    Responsabilidade = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    VoluntariadoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoluntariadoResponsabilidades", x => x.Responsabilidade);
                    table.ForeignKey(
                        name: "FK_VoluntariadoResponsabilidades_Voluntariados_VoluntariadoId",
                        column: x => x.VoluntariadoId,
                        principalTable: "Voluntariados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoluntariadoUsuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    VoluntariadoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoluntariadoUsuarios", x => new { x.UsuarioId, x.VoluntariadoId });
                    table.ForeignKey(
                        name: "FK_VoluntariadoUsuario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoluntariadoUsuario_Voluntariado_VoluntariadoId",
                        column: x => x.VoluntariadoId,
                        principalTable: "Voluntariados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_InstitutoId",
                table: "Enderecos",
                column: "InstitutoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_PontoDoacaoId",
                table: "Enderecos",
                column: "PontoDoacaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_VoluntariadoId",
                table: "Enderecos",
                column: "VoluntariadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_UsuarioId",
                table: "Logins",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaterialDoacaos_InstitutoId",
                table: "MaterialDoacaos",
                column: "InstitutoId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialDoacaos_PontoDoacaoId",
                table: "MaterialDoacaos",
                column: "PontoDoacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PontoDoacaos_InstitutoId",
                table: "PontoDoacaos",
                column: "InstitutoId");

            migrationBuilder.CreateIndex(
                name: "IX_VoluntariadoBeneficios_VoluntariadoId",
                table: "VoluntariadoBeneficios",
                column: "VoluntariadoId");

            migrationBuilder.CreateIndex(
                name: "IX_VoluntariadoResponsabilidades_VoluntariadoId",
                table: "VoluntariadoResponsabilidades",
                column: "VoluntariadoId");

            migrationBuilder.CreateIndex(
                name: "IX_VoluntariadoUsuarios_VoluntariadoId",
                table: "VoluntariadoUsuarios",
                column: "VoluntariadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Institutos_InstitutoId",
                table: "Enderecos",
                column: "InstitutoId",
                principalTable: "Institutos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_PontoDoacaos_PontoDoacaoId",
                table: "Enderecos",
                column: "PontoDoacaoId",
                principalTable: "PontoDoacaos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Voluntariados_VoluntariadoId",
                table: "Enderecos",
                column: "VoluntariadoId",
                principalTable: "Voluntariados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Institutos_InstitutoId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_PontoDoacaos_PontoDoacaoId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Voluntariados_VoluntariadoId",
                table: "Enderecos");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "MaterialDoacaos");

            migrationBuilder.DropTable(
                name: "VoluntariadoBeneficios");

            migrationBuilder.DropTable(
                name: "VoluntariadoResponsabilidades");

            migrationBuilder.DropTable(
                name: "VoluntariadoUsuarios");

            migrationBuilder.DropTable(
                name: "PontoDoacaos");

            migrationBuilder.DropTable(
                name: "Voluntariados");

            migrationBuilder.DropTable(
                name: "Institutos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_InstitutoId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_PontoDoacaoId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_VoluntariadoId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "Perfil",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "SenhaHash",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "InstitutoId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "PontoDoacaoId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "VoluntariadoId",
                table: "Enderecos");

            migrationBuilder.AlterColumn<string>(
                name: "SobreNome",
                table: "Usuarios",
                type: "TEXT",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);
        }
    }
}
