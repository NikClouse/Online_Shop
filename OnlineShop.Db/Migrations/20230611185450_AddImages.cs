using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class AddImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bf58752d-eee2-4551-9f4f-3af6eb1367a9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c267dd45-7112-4197-a62c-277884847eac"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c95d4669-fa1b-4971-80be-ef4578c0bfae"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e26af290-53c5-436d-b33a-d2b6c57603f7"));

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Name" },
                values: new object[] { new Guid("92bced76-82ba-4f44-af74-70eb7b31a6f9"), 15000m, "Honor s10", "Honor" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Name" },
                values: new object[] { new Guid("ba7aec10-4500-49ad-8ee6-ddbe95371796"), 20000m, "Huawei nova 9", "Huawei" });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ProductId", "Url" },
                values: new object[] { new Guid("d3630000-5d0f-0015-2872-08da3058ad5a"), new Guid("92bced76-82ba-4f44-af74-70eb7b31a6f9"), "/img/product/honor.jfif" });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ProductId", "Url" },
                values: new object[] { new Guid("68bfe1d6-a659-4407-aa2a-d38b10af42b1"), new Guid("ba7aec10-4500-49ad-8ee6-ddbe95371796"), "/img/product/Huawei19.jfif" });

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProductId",
                table: "Image",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("92bced76-82ba-4f44-af74-70eb7b31a6f9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ba7aec10-4500-49ad-8ee6-ddbe95371796"));

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("bf58752d-eee2-4551-9f4f-3af6eb1367a9"), 1750.00m, "Укрепление иммунной системы", "/img/iphon.png", "Смартфоне" },
                    { new Guid("c267dd45-7112-4197-a62c-277884847eac"), 2500.00m, "Заряд энергии на клеточном уровне", "/img/iphon.png", "Смартфоне" },
                    { new Guid("e26af290-53c5-436d-b33a-d2b6c57603f7"), 1960.00m, "Поддержка роста и развития", "/img/iphon.png", "Смартфоне" },
                    { new Guid("c95d4669-fa1b-4971-80be-ef4578c0bfae"), 1020.00m, "Здоровье костей", "/img/iphon.png", "Смартфоне" }
                });
        }
    }
}
