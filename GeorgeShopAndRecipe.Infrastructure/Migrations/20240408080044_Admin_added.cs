using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeorgeShopAndRecipe.Infrastructure.Migrations
{
    public partial class Admin_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42f48857-377c-4386-9658-4a7fffe21895", "Ivan", "Lainqnov", "AQAAAAEAACcQAAAAEBPiRTfHxSp4kyiS1PR5ktKOzSYMyCb7aMj1unsJQcBtI94Ah8yS/70coQWgIfApQg==", "893c9b08-0d26-475e-9c2f-0b42ec02cd27" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a395263-d47e-4f16-958c-139370faf4f9", "Andreikata", "Georgiev", "AQAAAAEAACcQAAAAEMCYS4IB2iMcgPBZR8DFx4ZlIGvveTwYet+RSTaUzQPZqZqyRkj+z+5FPczbIa0L/w==", "05035ced-b4eb-4408-add6-9b06ad5b8956" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "98767df8-9197-416f-988d-8b4e7a7aa218", 0, "0a311d90-8a9a-449d-99a4-19fccb494ac8", "admin@mail.com", false, "Great", "Admin", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEFiSsnqu3xyCr+ZcC8FTBC7XSXKidQGvwlgZJqJ2ux9Dm3547WX/5d0lk3tK+1yXTA==", null, false, "0f8f9dbe-c9ee-4ffb-aa5e-bf4ce0ad779b", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "RecipeDevelopers",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[] { 11, "Georgi Kostadinov", "98767df8-9197-416f-988d-8b4e7a7aa218" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecipeDevelopers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98767df8-9197-416f-988d-8b4e7a7aa218");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2547dcc-ec04-4870-b72e-bf170a63feeb", "", "", "AQAAAAEAACcQAAAAEMMlFR/3IWdNElLRGCJZdXAAS26HRWwbslxPBkwXZDNW31fQOVkFH7wlzJKBqikT9Q==", "19ca4b4c-74e1-494e-aec8-c5093aa17b4d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "515b7ad3-06ec-40d8-877b-3e109b95cf16", "", "", "AQAAAAEAACcQAAAAEDWVrTDe0YiICHXdbeZY3uSk3p7VKY/auedwTlLaFXkReXMPgLFCKojgPlj5TBSXSQ==", "3931220b-f5b1-4177-87d2-dc9ff5191838" });
        }
    }
}
