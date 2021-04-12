using Microsoft.EntityFrameworkCore.Migrations;

namespace appspbox.Migrations
{
    public partial class ContextPostDbContexto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Provider_Provider_providerId1",
                table: "Provider");

            migrationBuilder.DropIndex(
                name: "IX_Provider_providerId1",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "providerId1",
                table: "Provider");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Provider_providerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_providerId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "providerId1",
                table: "Provider",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Provider_providerId1",
                table: "Provider",
                column: "providerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Provider_Provider_providerId1",
                table: "Provider",
                column: "providerId1",
                principalTable: "Provider",
                principalColumn: "providerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
