using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeorgeShopAndRecipe.Infrastructure.Migrations
{
    public partial class admin_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f84eebe-b8ff-4c33-a731-fea2572112ae",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f457db9-adf0-4f29-85c1-52dda07c93d8", "AQAAAAEAACcQAAAAEF0HqTl7eFOKDZSqyHIyTOXqisWB+c21NRuhds3UwpreIWHa3SkaggWtrbof/LiTng==", "fa66904d-0fa8-4001-afa2-f9f8bc0c7900" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "299e94d7-1a68-4738-9d25-e062394ae0c5 ",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb92aeaf-7175-416f-b7c8-3bcca201dc1c", "AQAAAAEAACcQAAAAEA3JUHgJhwtcGQ0qCMqI3C4XaGJSyctLBhwxomSL0SmA+Fff1p/MjnE9QQwQRcsgpw==", "9ed37db2-5dea-46f1-a637-41ae60bf5482" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0518706-d004-453d-930b-ef40cd37d4f0 ",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15fd631e-ada5-416a-b0a1-9358e98fd80c", "AQAAAAEAACcQAAAAENQhbXVrosHq8juzjbfULOgYUmqrUWSXaC8LtZ8I/oBhExo4Go+mZrQDutaXs1uHJA==", "5b346d3f-b917-4e89-bf9d-f859f9a91fcf" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f84eebe-b8ff-4c33-a731-fea2572112ae",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19cfb68b-2eb4-49db-81b7-e11c3d3e1e89", "AQAAAAEAACcQAAAAEIsZBXDCHtdMvsnbhcnvtq8lbigq5YtpTwzCzYN4ZUu3RiNAThp3A0g3vzRLUS1ztQ==", "4f8dfcb1-6217-4d32-a0ca-c8d7ae656842" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "299e94d7-1a68-4738-9d25-e062394ae0c5 ",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "779dbb67-f2a3-4a75-a0ad-62b6d541053d", "AQAAAAEAACcQAAAAEBTDV03OumHEL+zXjzCkTlf4qPb//tbiRkS/Fdj5hFQuWlsCzVQ4pmgrqJEYV2ylNQ==", "1a36d78b-1d43-4a71-8b1b-161500f9f5f4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0518706-d004-453d-930b-ef40cd37d4f0 ",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ddbc0619-a2e4-4ab1-855f-46c9bd5abe0d", "AQAAAAEAACcQAAAAEDbeTz0LCZkGLpqIy8As7pLHLElruU5zI1RDPmSWcIyXEpsyzjZLG15gLbdOqz+ogg==", "f43d1051-ba5c-4fb1-932c-3f62ff061970" });
        }
    }
}
