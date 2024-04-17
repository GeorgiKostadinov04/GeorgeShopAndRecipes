using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeorgeShopAndRecipe.Infrastructure.Migrations
{
    public partial class addedIsApproveInSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "299e94d7-1a68-4738-9d25-e062394ae0c5 ");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f84eebe-b8ff-4c33-a731-fea2572112ae",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "308797fb-8c22-47b5-8da9-80adf0bb71be", "AQAAAAEAACcQAAAAEL+793cpbQm7lK3laYTXDIIDhv+3iLuMSBY3qUpSvkbNXGxy/nLcloRMnKJF7gK3MQ==", "8f97b7a9-0d2e-4ab9-aec8-18cd03c46ce3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0518706-d004-453d-930b-ef40cd37d4f0 ",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a8203fd-8cb8-4418-9bbe-9879c1eaccd3", "AQAAAAEAACcQAAAAEIZWeDqBRsTru30oSFGLPfQta/Y2dlcE1ZU7E83Vgb6PDbl1pnzz899gosfNB4ELMw==", "e630c72e-8684-4dc0-9be6-934e8c4e9db4" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "299e94d7-1a68-4738-9d25-e062394ae0c5", 0, "508ed0dd-e588-4307-8e3b-85982b8880f8", "admin@mail.com", false, "Great", "Admin", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAENtyHZP+V1z6DpU4aoHNIMrYiIWxePPiK/9bYjk7bJ2zOkiD0STr6aHaUOVXOyIQUA==", null, false, "52ba449f-9c41-4f1a-aa3a-705937564118", false, "admin@mail.com" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "RecipeDevelopers",
                keyColumn: "Id",
                keyValue: 33,
                column: "UserId",
                value: "299e94d7-1a68-4738-9d25-e062394ae0c5");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "299e94d7-1a68-4738-9d25-e062394ae0c5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f84eebe-b8ff-4c33-a731-fea2572112ae",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd31e913-b001-4a00-9c65-c87ad64e83ab", "AQAAAAEAACcQAAAAEG2Fv1ywZcjUfwlVbeONWIZKTHjKlzYz5YZcUskAHATL8VX+zPNzUcwtaQ1BUqUiKA==", "06acfa6a-53a0-4caf-944c-b2ecf8f44f4b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0518706-d004-453d-930b-ef40cd37d4f0 ",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "998171a3-f07e-4e53-ac40-b777867f5064", "AQAAAAEAACcQAAAAEF3y5CH27TBmC946s21Nw9ZfqmTbSPvDbqFtNXDqiDaCyEzZG+3lqx5MzTqapv4JGA==", "a06bfd43-78e9-4601-958a-3d22e5c1c862" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "299e94d7-1a68-4738-9d25-e062394ae0c5 ", 0, "a0bbbe2e-de72-4462-98eb-51cb1faa5a13", "admin@mail.com", false, "Great", "Admin", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAELFwyokkpYrx42S+1xIz45ornZJigTXNNs8vNlYdlmcZ1EatR92K88tjqZPRundPzg==", null, false, "6f406a44-c044-4424-bd06-b1cc72173890", false, "admin@mail.com" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "RecipeDevelopers",
                keyColumn: "Id",
                keyValue: 33,
                column: "UserId",
                value: "299e94d7-1a68-4738-9d25-e062394ae0c5 ");
        }
    }
}
