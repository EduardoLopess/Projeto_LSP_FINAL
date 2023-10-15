using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Login : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstitutoId",
                table: "Logins",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Logins_InstitutoId",
                table: "Logins",
                column: "InstitutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_Institutos_InstitutoId",
                table: "Logins",
                column: "InstitutoId",
                principalTable: "Institutos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logins_Institutos_InstitutoId",
                table: "Logins");

            migrationBuilder.DropIndex(
                name: "IX_Logins_InstitutoId",
                table: "Logins");

            migrationBuilder.DropColumn(
                name: "InstitutoId",
                table: "Logins");
        }
    }
}
