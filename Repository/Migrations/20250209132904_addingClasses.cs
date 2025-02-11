using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class addingClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdopted",
                table: "Pets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ShelterId",
                table: "Pets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Shelter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShelterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelter", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_ShelterId",
                table: "Pets",
                column: "ShelterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Shelter_ShelterId",
                table: "Pets",
                column: "ShelterId",
                principalTable: "Shelter",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Shelter_ShelterId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "Shelter");

            migrationBuilder.DropIndex(
                name: "IX_Pets_ShelterId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "IsAdopted",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "ShelterId",
                table: "Pets");
        }
    }
}
