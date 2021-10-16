using Microsoft.EntityFrameworkCore.Migrations;

namespace BookApi.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin_role",
                column: "ConcurrencyStamp",
                value: "343d7727-4af9-472f-b937-1185de3fc2f9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "reader_role",
                column: "ConcurrencyStamp",
                value: "7cbfc8d5-2664-4f7f-93d4-ba61cefe9dd6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cbcae747-8cc6-4ef8-bab7-f1cd0abe9281", "AQAAAAEAACcQAAAAEIWD+BrocJtYb4FfbpkrwwiEbeDTBx2w2MnTA89ZVzDb1ro3cIZV/Av1KNFr0wJd2Q==", "f08f5e54-373e-491d-ad15-bbf0671fcc84" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25475bfa-43b0-4d34-ac4e-6df67d00ff2d", "AQAAAAEAACcQAAAAELL6FtwvcQd1BFNrSJ9sj7mMvjOtQOyk+jCvg8Z47l8iaXqy3YP4BvGsCNWc7G1Ftg==", "941d6a0e-0810-4eeb-ae9f-764f9ac26fc6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin_role",
                column: "ConcurrencyStamp",
                value: "56b75dd9-d2ef-444f-8710-28ee665e6c0e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "reader_role",
                column: "ConcurrencyStamp",
                value: "356cddaf-efc4-46fa-96d1-1e5a751c05ec");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c90bd64-d629-4afb-accd-5b2367c51803", "AQAAAAEAACcQAAAAEOJOSS/mhX/yJTRZdns7Ueht20hOFiUFTkkOy/l+hgdbqnfe9lPZ2Ej5wx3GF+escg==", "bbfb8c92-2753-40b6-9085-6ff8f25b5941" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "465df92b-fc3f-4e00-874c-a7e3e5e437a0", "AQAAAAEAACcQAAAAELnTjROQkvvSvCeBXVbAD5icVGVedqK/ZTLDZNmNgZ7mlwT/Aeq+cDvOCOIJ/gr0Xg==", "72b92e12-baec-49ba-9f48-2245964a41de" });
        }
    }
}
