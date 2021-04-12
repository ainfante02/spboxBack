using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace appspbox.Migrations
{
    public partial class ContextPostDbContextt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Orders_orderrId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_orderrId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "orderrId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "orderrId",
                table: "Orders",
                newName: "providerId");

            migrationBuilder.AddColumn<int>(
                name: "providerId1",
                table: "Provider",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "providerId",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "orderId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "orderId");

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    orderId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.OrderDetailId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Provider_Provider_providerId1",
                table: "Provider");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_Provider_providerId1",
                table: "Provider");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "providerId1",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "orderId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "providerId",
                table: "Orders",
                newName: "orderrId");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Provider",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Product",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "orderrId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "orderrId",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "orderrId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_orderrId",
                table: "Product",
                column: "orderrId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Orders_orderrId",
                table: "Product",
                column: "orderrId",
                principalTable: "Orders",
                principalColumn: "orderrId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
