using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeorgeShopAndRecipe.Infrastructure.Migrations
{
    public partial class admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecipeDevelopers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RecipeDevelopers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f84eebe-b8ff-4c33-a731-fea2572112ae",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd31e913-b001-4a00-9c65-c87ad64e83ab", "AQAAAAEAACcQAAAAEG2Fv1ywZcjUfwlVbeONWIZKTHjKlzYz5YZcUskAHATL8VX+zPNzUcwtaQ1BUqUiKA==", "06acfa6a-53a0-4caf-944c-b2ecf8f44f4b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "299e94d7-1a68-4738-9d25-e062394ae0c5 ",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0bbbe2e-de72-4462-98eb-51cb1faa5a13", "AQAAAAEAACcQAAAAELFwyokkpYrx42S+1xIz45ornZJigTXNNs8vNlYdlmcZ1EatR92K88tjqZPRundPzg==", "6f406a44-c044-4424-bd06-b1cc72173890" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0518706-d004-453d-930b-ef40cd37d4f0 ",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "998171a3-f07e-4e53-ac40-b777867f5064", "AQAAAAEAACcQAAAAEF3y5CH27TBmC946s21Nw9ZfqmTbSPvDbqFtNXDqiDaCyEzZG+3lqx5MzTqapv4JGA==", "a06bfd43-78e9-4601-958a-3d22e5c1c862" });

            migrationBuilder.InsertData(
                table: "RecipeDevelopers",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { 19, "Ivan Mihailov", "1f84eebe-b8ff-4c33-a731-fea2572112ae" },
                    { 33, "Georgi Kostadinov", "299e94d7-1a68-4738-9d25-e062394ae0c5 " }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecipeDevelopers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "RecipeDevelopers",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f84eebe-b8ff-4c33-a731-fea2572112ae",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d873dc7-6f6d-402d-a95e-b32cd9c505c9", "AQAAAAEAACcQAAAAENFpLmC6C9ZxifUtJZzkvA1RjqJw1duYxDEew3qgzzm1teYipQQwuKzuwGAtq0t7FA==", "c604ac15-e17a-4dcf-84e3-ec989848e674" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "299e94d7-1a68-4738-9d25-e062394ae0c5 ",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1364a5d3-e565-4495-826c-c01bce187ee3", "AQAAAAEAACcQAAAAEGNY8T07Ad4o7pNLTlPftGtK6EIj9FtOZnFuoix9mo+K3alb1gUI5GjgHJcWRYLk+g==", "bbdc2810-b12c-491f-9e85-4b6721d3a23f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0518706-d004-453d-930b-ef40cd37d4f0 ",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8353d96-c12b-444d-9992-ecd3fa24290f", "AQAAAAEAACcQAAAAEA7p3H1qU2iJ++GNc1xpFSYG6cnO2U1L0qYyrTRJyCWtdPBUzGMAQG6IdNVsC1287w==", "eddf803f-d535-45b1-92b2-bc69b34c55b2" });

            migrationBuilder.InsertData(
                table: "RecipeDevelopers",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "Ivan Mihailov", "1f84eebe-b8ff-4c33-a731-fea2572112ae" },
                    { 11, "Georgi Kostadinov", "299e94d7-1a68-4738-9d25-e062394ae0c5 " }
                });
        }
    }
}
