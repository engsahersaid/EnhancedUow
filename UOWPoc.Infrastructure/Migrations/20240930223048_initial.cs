using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UOWPoc.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nationality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniqueName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalityId = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Nationality_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    POBox = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apartment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Nationality",
                columns: new[] { "Id", "Active", "Name", "UniqueName" },
                values: new object[,]
                {
                    { 1, true, "Egypt", "Egypt" },
                    { 2, true, "KSA", "KSA" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Age", "CreatedAt", "DeletedAt", "FirstName", "IsDeleted", "LastName", "NationalityId", "lastUpdatedAt" },
                values: new object[,]
                {
                    { "a7a0608b-80e0-4f4e-9867-c1196bbee56a", 20, new DateTime(2024, 10, 1, 1, 30, 48, 528, DateTimeKind.Local).AddTicks(5027), null, "Saher", false, "Fahd", 1, null },
                    { "ce233911-fb84-43da-9b1e-fbeb0f4bba81", 15, new DateTime(2024, 10, 1, 1, 30, 48, 528, DateTimeKind.Local).AddTicks(5040), null, "Saher", false, "Said", 2, null }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "Apartment", "City", "Country", "CreatedAt", "DeletedAt", "IsDeleted", "POBox", "PersonId", "Street", "lastUpdatedAt" },
                values: new object[,]
                {
                    { "94c0b145-8725-47d0-aa08-efc8f78373e4", "54", "Riydah", "KSA", new DateTime(2024, 10, 1, 1, 30, 48, 528, DateTimeKind.Local).AddTicks(5057), null, false, "443543", "ce233911-fb84-43da-9b1e-fbeb0f4bba81", "Almourabe", null },
                    { "a9747682-b31d-4c10-918c-9c19048148de", "3", "Cairo", "Egypt", new DateTime(2024, 10, 1, 1, 30, 48, 528, DateTimeKind.Local).AddTicks(5054), null, false, "7575", "a7a0608b-80e0-4f4e-9867-c1196bbee56a", "test street", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_PersonId",
                table: "Address",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Nationality_UniqueName",
                table: "Nationality",
                column: "UniqueName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_NationalityId",
                table: "Person",
                column: "NationalityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Nationality");
        }
    }
}