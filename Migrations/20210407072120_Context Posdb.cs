using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace appspbox.Migrations
{
    public partial class ContextPosdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Provider_providerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_providerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "identity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Orders");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Orders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Orders",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "identity",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Orders",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_providerId",
                table: "Orders",
                column: "providerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Provider_providerId",
                table: "Orders",
                column: "providerId",
                principalTable: "Provider",
                principalColumn: "providerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
