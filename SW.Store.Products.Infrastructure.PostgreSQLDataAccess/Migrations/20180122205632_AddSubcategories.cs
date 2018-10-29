using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Warehouse.Products.Infrastructure.PostgreSQLDataAccess.Migrations
{
    public partial class AddSubcategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "product",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    parentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                    table.ForeignKey(
                        name: "FK_category_category_parentId",
                        column: x => x.parentId,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_CategoryId",
                table: "product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_category_parentId",
                table: "category",
                column: "parentId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_category_CategoryId",
                table: "product",
                column: "CategoryId",
                principalTable: "category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_category_CategoryId",
                table: "product");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropIndex(
                name: "IX_product_CategoryId",
                table: "product");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "product");
        }
    }
}