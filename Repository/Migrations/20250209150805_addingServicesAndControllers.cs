using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class addingServicesAndControllers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Shelter_ShelterId",
                table: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shelter",
                table: "Shelter");

            migrationBuilder.RenameTable(
                name: "Shelter",
                newName: "Shelters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shelters",
                table: "Shelters",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Adopters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adopters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adopters_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adoption_Applications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adoption_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adoption_Applications_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adopters_PetId",
                table: "Adopters",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Adoption_Applications_PetId",
                table: "Adoption_Applications",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Shelters_ShelterId",
                table: "Pets",
                column: "ShelterId",
                principalTable: "Shelters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Shelters_ShelterId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "Adopters");

            migrationBuilder.DropTable(
                name: "Adoption_Applications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shelters",
                table: "Shelters");

            migrationBuilder.RenameTable(
                name: "Shelters",
                newName: "Shelter");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shelter",
                table: "Shelter",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Shelter_ShelterId",
                table: "Pets",
                column: "ShelterId",
                principalTable: "Shelter",
                principalColumn: "Id");
        }
    }
}
