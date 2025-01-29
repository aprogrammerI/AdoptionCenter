using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class petinheritance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsIndoor",
                table: "Pets",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrained",
                table: "Pets",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PetId",
                table: "Pets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsIndoor",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "IsTrained",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Pets");
        }
    }
}
