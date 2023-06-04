using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogP.Data.Migrations
{
    /// <inheritdoc />
    public partial class DalDuzenlemesi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("31aa2a65-f7db-4dd3-a848-79e33ba992b9"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[] { new Guid("02d0a05d-fe52-4d71-8325-3a8f49f00df9"), new Guid("a37c8c85-ba5d-49fe-8729-5c1b05a17ca0"), "Makale belirli bir konuda yazılan ve belli bir düşünceyi savunma amacı taşıyan yazılara verilen isimdir. Makale yazımında kanıt kaygısı olduğundan çeşitli dergi, gazete veya kitaplarda yayımlanır ve bu nedenle bilimsel metin türleri arasında yer alır.  Makalelerdeki en önemli nokta savunulan düşüncenin bilimsel temele dayandırılması ve alanında uzman kişiler tarafından yazılmasıdır.", "Admin Test", new DateTime(2023, 6, 4, 23, 16, 33, 574, DateTimeKind.Local).AddTicks(9167), null, null, new Guid("821a63a5-3942-47e5-b4f8-d338be7438a2"), false, null, null, "Asp.Net Core Deneme Makalesi 1", 0 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a37c8c85-ba5d-49fe-8729-5c1b05a17ca0"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 4, 23, 16, 33, 575, DateTimeKind.Local).AddTicks(2531));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("821a63a5-3942-47e5-b4f8-d338be7438a2"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 4, 23, 16, 33, 575, DateTimeKind.Local).AddTicks(4374));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("02d0a05d-fe52-4d71-8325-3a8f49f00df9"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[] { new Guid("31aa2a65-f7db-4dd3-a848-79e33ba992b9"), new Guid("a37c8c85-ba5d-49fe-8729-5c1b05a17ca0"), "Makale belirli bir konuda yazılan ve belli bir düşünceyi savunma amacı taşıyan yazılara verilen isimdir. Makale yazımında kanıt kaygısı olduğundan çeşitli dergi, gazete veya kitaplarda yayımlanır ve bu nedenle bilimsel metin türleri arasında yer alır.  Makalelerdeki en önemli nokta savunulan düşüncenin bilimsel temele dayandırılması ve alanında uzman kişiler tarafından yazılmasıdır.", "Admin Test", new DateTime(2023, 6, 4, 22, 20, 1, 772, DateTimeKind.Local).AddTicks(5554), null, null, new Guid("821a63a5-3942-47e5-b4f8-d338be7438a2"), false, null, null, "Asp.Net Core Deneme Makalesi 1", 0 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a37c8c85-ba5d-49fe-8729-5c1b05a17ca0"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 4, 22, 20, 1, 772, DateTimeKind.Local).AddTicks(9405));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("821a63a5-3942-47e5-b4f8-d338be7438a2"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 4, 22, 20, 1, 773, DateTimeKind.Local).AddTicks(2077));
        }
    }
}
