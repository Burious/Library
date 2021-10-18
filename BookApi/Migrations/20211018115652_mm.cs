using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class mm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin_role",
                column: "ConcurrencyStamp",
                value: "b9ae020b-283e-49e4-89b0-2c32b64f9825");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "reader_role",
                column: "ConcurrencyStamp",
                value: "3689b6dd-2d82-467e-bec0-e85faaf9507f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e699253d-3d6e-4fd3-886c-11ad1f4e2c65", "AQAAAAEAACcQAAAAEH1VmwQyqL4hCYeuVTVgzGZNy0u8Wdk102abCR4z2a9Qmb6GWn81n6fa0s2W31NW0A==", "b6e44f6b-d9ab-40dd-af8a-c9e10d4defde" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin_role",
                column: "ConcurrencyStamp",
                value: "c0ac590e-0f63-41e2-8f5f-12e6ba1367e6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "reader_role",
                column: "ConcurrencyStamp",
                value: "823f3800-774d-4834-b0cd-6f458efd1fa9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "724b4eea-464a-4cc1-85ca-ea1605a0855d", "AQAAAAEAACcQAAAAENn1VJMpSSvtTVz0ezUd+c1UUWW1pz0qhamI8RQjx0ZNSpNFrGLu9E+xCKnZLc2/hA==", "d167b08a-c178-4d68-93f9-cc601b3874eb" });
        }
    }
}
