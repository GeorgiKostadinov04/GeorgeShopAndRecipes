using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeorgeShopAndRecipe.Infrastructure.Migrations
{
    public partial class Inital_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Category name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Ingredient name"),
                    Calories = table.Column<double>(type: "float", nullable: false, comment: "Ingredient calories"),
                    PricePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Ingredient price"),
                    Category = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Ingredient category"),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Ingredient image url")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Shop name"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Shop phone number"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Shop image url")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "IngredienstShops",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredienstShops", x => new { x.ShopId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_IngredienstShops_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_IngredienstShops_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Supplier first name"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Supplier last name"),
                    Age = table.Column<int>(type: "int", nullable: false, comment: "Supplier age"),
                    Rating = table.Column<double>(type: "float", nullable: false, comment: "Supplier rating"),
                    ShopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Recipe name"),
                    WayOfMaking = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "Recipe way of making"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Recipe image url"),
                    RecipeDeveloperId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipes_RecipeDevelopers_RecipeDeveloperId",
                        column: x => x.RecipeDeveloperId,
                        principalTable: "RecipeDevelopers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientsRecipes",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientsRecipes", x => new { x.RecipeId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_IngredientsRecipes_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_IngredientsRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "c30f15ed-8ea3-49aa-9053-dfc4a917a244", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEHe+sLsk4n47w0KjKrp5STHGDxL5WfFf+G6hpRf2yvDof2IsVtJq3eycEyPzkbWKIA==", null, false, "2a5de6fe-dd38-41f7-8944-e867fd9133f3", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "b29c5247-6133-4ccc-853f-0a8ecb1a3861", "recipeDeveloper@mail.com", false, false, null, "recipeDeveloper@mail.com", "recipeDeveloper@mail.com", "AQAAAAEAACcQAAAAENoK+jLFT6jzCQaIUHkleUrSsPL0xU3wtSmR9MMz3zb8XSoAMoJLG1CEkPXC7UjZrg==", null, false, "02c0b631-a217-4db8-a34f-ca9bad4c7525", false, "recipeDeveloper@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Gluten free" },
                    { 2, "Dairy free" },
                    { 3, "High protein" },
                    { 4, "Vegan" },
                    { 5, "Vegetarian" },
                    { 6, "None" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Calories", "Category", "ExpireDate", "ImageUrl", "Name", "PricePerUnit" },
                values: new object[,]
                {
                    { 1, 240.0, "meat", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.allrecipes.com/thmb/Z5s08uvHYI2dg5LAd0vwoA47Ngo=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/240208_simplebakedchickenbreasts_mfs_step1_0181-1-4x3-250b3f145a194aa3bab88e94e3cbae73.jpg", "Chicken breast", 9m },
                    { 2, 45.0, "vegetable", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "data:image/jpeg;base64,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", "Cucumber", 1.23m },
                    { 3, 22.0, "vegetable", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "data:image/jpeg;base64,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", "Tomato", 1.45m },
                    { 4, 402.5, "dairy product", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://igourmet.com/cdn/shop/files/189S_Bulgarian_Feta-2.jpg?v=1691411813", "Cheese", 4.69m },
                    { 5, 884.10000000000002, "dressing", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://cdncloudcart.com/16398/products/images/40252/olio-kaliakra-slancogledovo-1-l-image_5ea2d97e8c9c0_800x800.png?1595836794", "Coocking oil", 4.2m }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "ImageUrl", "Name", "PhoneNumber" },
                values: new object[] { 1, "https://upload.wikimedia.org/wikipedia/commons/thumb/9/91/Lidl-Logo.svg/800px-Lidl-Logo.svg.png", "Lidl", "359888888888" });

            migrationBuilder.InsertData(
                table: "RecipeDevelopers",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[] { 1, "Ivan Mihailov", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Age", "FirstName", "LastName", "Rating", "ShopId" },
                values: new object[] { 1, 21, "Georgi", "Ivanov", 4.5, 1 });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "ImageUrl", "Name", "RecipeDeveloperId", "WayOfMaking" },
                values: new object[] { 1, 5, "https://www.wandercooks.com/wp-content/uploads/2019/07/bulgarian-shopska-salad-ft2.jpg", "Шопска салата", 1, "Нарязваме доматите и краставиците и слагаме олио и сирене отгоре" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "ImageUrl", "Name", "RecipeDeveloperId", "WayOfMaking" },
                values: new object[] { 2, 6, "https://casafelice.bg/wp-content/uploads/2020/07/tsezar-1.jpg", "Шопска салата с пилешко", 1, "Нарязваме доматите и краставиците. След това нарязваме и пилешките гърди и ги слагаме в купата. Накрая слагаме олио и месо" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_IngredienstShops_IngredientId",
                table: "IngredienstShops",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsRecipes_IngredientId",
                table: "IngredientsRecipes",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDevelopers_UserId",
                table: "RecipeDevelopers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeDeveloperId",
                table: "Recipes",
                column: "RecipeDeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_ShopId",
                table: "Suppliers",
                column: "ShopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "IngredienstShops");

            migrationBuilder.DropTable(
                name: "IngredientsRecipes");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "RecipeDevelopers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
