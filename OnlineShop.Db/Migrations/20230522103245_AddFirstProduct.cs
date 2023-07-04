using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class AddFirstProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
