using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeorgeShopAndRecipe.Infrastructure.Migrations
{
    public partial class Add_class_RecipeDeveloper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_AspNetUsers_PublisherId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_PublisherId",
                table: "Recipes");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "Recipes");

            migrationBuilder.AddColumn<int>(
                name: "RecipeDeveloperId",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RecipeDevelopers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Recipe developer's name"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDevelopers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeDevelopers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeDeveloperId",
                table: "Recipes",
                column: "RecipeDeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDevelopers_UserId",
                table: "RecipeDevelopers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_RecipeDevelopers_RecipeDeveloperId",
                table: "Recipes",
                column: "RecipeDeveloperId",
                principalTable: "RecipeDevelopers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_RecipeDevelopers_RecipeDeveloperId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "RecipeDevelopers");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_RecipeDeveloperId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeDeveloperId",
                table: "Recipes");

            migrationBuilder.AddColumn<string>(
                name: "PublisherId",
                table: "Recipes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Gluten free" },
                    { 2, "Vegetarian" },
                    { 3, "Vegan" },
                    { 4, "Dairy free" },
                    { 5, "High protein" },
                    { 6, "None" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_PublisherId",
                table: "Recipes",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_AspNetUsers_PublisherId",
                table: "Recipes",
                column: "PublisherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
