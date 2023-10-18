using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RestoEntidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DonationPointId",
                table: "Addresses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstituteId",
                table: "Addresses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Institutes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    AddressId = table.Column<int>(type: "INTEGER", nullable: true),
                    ProfileAcess = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Institutes_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DonationPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    TypeMaterial = table.Column<int>(type: "INTEGER", nullable: false),
                    AddressId = table.Column<int>(type: "INTEGER", nullable: true),
                    InstituteId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonationPoints_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DonationPoints_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Volunteerings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    InstituteId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteerings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Volunteerings_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DonationMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    TypeMaterial = table.Column<int>(type: "INTEGER", nullable: false),
                    DonationPointId = table.Column<int>(type: "INTEGER", nullable: true),
                    InstituteId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonationMaterials_DonationPoints_DonationPointId",
                        column: x => x.DonationPointId,
                        principalTable: "DonationPoints",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DonationMaterials_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Benefits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    VolunteeringId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Benefits_Volunteerings_VolunteeringId",
                        column: x => x.VolunteeringId,
                        principalTable: "Volunteerings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Responsibilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    VolunteeringId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsibilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responsibilities_Volunteerings_VolunteeringId",
                        column: x => x.VolunteeringId,
                        principalTable: "Volunteerings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Benefits_VolunteeringId",
                table: "Benefits",
                column: "VolunteeringId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationMaterials_DonationPointId",
                table: "DonationMaterials",
                column: "DonationPointId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationMaterials_InstituteId",
                table: "DonationMaterials",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationPoints_AddressId",
                table: "DonationPoints",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationPoints_InstituteId",
                table: "DonationPoints",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_Institutes_AddressId",
                table: "Institutes",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Responsibilities_VolunteeringId",
                table: "Responsibilities",
                column: "VolunteeringId");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteerings_InstituteId",
                table: "Volunteerings",
                column: "InstituteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Benefits");

            migrationBuilder.DropTable(
                name: "DonationMaterials");

            migrationBuilder.DropTable(
                name: "Responsibilities");

            migrationBuilder.DropTable(
                name: "DonationPoints");

            migrationBuilder.DropTable(
                name: "Volunteerings");

            migrationBuilder.DropTable(
                name: "Institutes");

            migrationBuilder.DropColumn(
                name: "DonationPointId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "InstituteId",
                table: "Addresses");
        }
    }
}
