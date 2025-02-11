using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class no_subclasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adopters_Pets_PetId",
                table: "Adopters");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "IsIndoor",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "IsTrained",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Pets");

            migrationBuilder.AlterColumn<Guid>(
                name: "PetId",
                table: "Adopters",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Adopters_Pets_PetId",
                table: "Adopters",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adopters_Pets_PetId",
                table: "Adopters");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Pets",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PetId",
                table: "Adopters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Adopters_Pets_PetId",
                table: "Adopters",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
