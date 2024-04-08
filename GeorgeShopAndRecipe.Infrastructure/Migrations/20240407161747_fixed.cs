using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeorgeShopAndRecipe.Infrastructure.Migrations
{
    public partial class @fixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2547dcc-ec04-4870-b72e-bf170a63feeb", "AQAAAAEAACcQAAAAEMMlFR/3IWdNElLRGCJZdXAAS26HRWwbslxPBkwXZDNW31fQOVkFH7wlzJKBqikT9Q==", "19ca4b4c-74e1-494e-aec8-c5093aa17b4d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "515b7ad3-06ec-40d8-877b-3e109b95cf16", "AQAAAAEAACcQAAAAEDWVrTDe0YiICHXdbeZY3uSk3p7VKY/auedwTlLaFXkReXMPgLFCKojgPlj5TBSXSQ==", "3931220b-f5b1-4177-87d2-dc9ff5191838" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1685507c-8886-4ea1-816e-3f014a4eb88b", "AQAAAAEAACcQAAAAEAUDsm+lkhT56Nu45YeC1yal371m28VqOYnR7Kx/9pto3IV9npYM8gBSMqrKrZ7IXg==", "45ff94bf-e2c9-44ed-a1f8-75f743a79614" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f7239ab-d571-4269-82d9-6eca8c0cc82c", "AQAAAAEAACcQAAAAEId0OE4740263FhKSbjo2zql5bTd5TmzlE9qdfQzorCOZS+HQXOStstAYw2MGYjRMw==", "d702b7f1-6a56-4362-8c26-7447f57e2a3e" });
        }
    }
}
