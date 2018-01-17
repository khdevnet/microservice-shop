using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Warehouse.Products.Infrastructure.PostgreSQLDataAccess.Migrations
{
    public partial class AddProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    count = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    name = table.Column<string>(maxLength: 255, nullable: false),
                    price = table.Column<decimal>(nullable: false),
                    sku = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_sku",
                table: "product",
                column: "sku",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product");
        }
    }
}
