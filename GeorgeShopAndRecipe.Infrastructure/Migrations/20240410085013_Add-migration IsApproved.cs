using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeorgeShopAndRecipe.Infrastructure.Migrations
{
    public partial class AddmigrationIsApproved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Recipes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is a recipe approved by admin");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28be9bb8-88eb-4637-9161-7a7c72d47820", "AQAAAAEAACcQAAAAEPzyHY4mAxqI93KW40XZOZ+ZqcUiupjADJk3AMhQSqbZ5hC/mjGMZWGURP+SwUxd3A==", "88d8aa7e-8cff-4784-bd19-48128943d637" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98767df8-9197-416f-988d-8b4e7a7aa218",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27c5859c-d7a8-4bba-ac19-5712ea3fb0d4", "AQAAAAEAACcQAAAAECKUaS2an/AS9AjT9p1WlwFpYDZXG8jqU4M5qJHr/owcFeomFyionKVkjewWPNRyFA==", "0793dda0-559c-4d15-bcac-179835304acb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec921e45-c08b-4b23-bc5c-14860c3814e7", "AQAAAAEAACcQAAAAEK9fHftQN6gBhoCaGfBe86fw6J9/dMyI0920mFbyAwtSl8iHCduR6SMgWvFCg92Jqw==", "442868f8-7c95-4f28-b087-0f8505c389d7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Recipes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42f48857-377c-4386-9658-4a7fffe21895", "AQAAAAEAACcQAAAAEBPiRTfHxSp4kyiS1PR5ktKOzSYMyCb7aMj1unsJQcBtI94Ah8yS/70coQWgIfApQg==", "893c9b08-0d26-475e-9c2f-0b42ec02cd27" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98767df8-9197-416f-988d-8b4e7a7aa218",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a311d90-8a9a-449d-99a4-19fccb494ac8", "AQAAAAEAACcQAAAAEFiSsnqu3xyCr+ZcC8FTBC7XSXKidQGvwlgZJqJ2ux9Dm3547WX/5d0lk3tK+1yXTA==", "0f8f9dbe-c9ee-4ffb-aa5e-bf4ce0ad779b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a395263-d47e-4f16-958c-139370faf4f9", "AQAAAAEAACcQAAAAEMCYS4IB2iMcgPBZR8DFx4ZlIGvveTwYet+RSTaUzQPZqZqyRkj+z+5FPczbIa0L/w==", "05035ced-b4eb-4408-add6-9b06ad5b8956" });
        }
    }
}
