﻿using GeorgeShopAndRecipe.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GeorgeShopAndRecipe.Infrastructure.Data.Constants.ClaimConstants;

namespace GeorgeShopAndRecipe.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public Category FirstCategory { get; set; }

        public Category SecondCategory {  get; set; }

        public Category ThirdCategory { get; set; }

        public Category FourthCategory { get; set; }

        public Category FifthCategory { get; set; }

        public Category NoneCategory { get; set; }

        public Recipe FirstRecipe { get; set; }

        public Recipe SecondRecipe { get; set;}

        public Shop FirstShop { get; set; }

        public Ingredient FirstIngredient { get; set; }

        public Ingredient SecondIngredient { get; set; }

        public Ingredient ThirdIngredient { get; set; }

        public Ingredient FourthIngredient { get;set; }

        public Ingredient FifthIngredient { get; set; }
        public Ingredient SixthIngredient { get; set; }
        public Ingredient SeventhIngredient { get; set; }
        public Ingredient EigthIngredient { get; set; }
        public Ingredient NinthIngredient { get; set; }
        public Ingredient TenthIngredient { get; set; }
        public Ingredient ElevenIngredient { get; set; }
        public Ingredient TwelveIngredient { get; set; }
        public Ingredient ThirteenIngredient { get; set; }

        public Supplier FirstSupplier { get; set; }

        public ApplicationUser RecipeDeveloperUser { get; set; }

        public IdentityUserClaim<string> RecipeDeveloperUserClaim { get; set; }
        public ApplicationUser GuestUser { get; set; }

        public IdentityUserClaim<string> GuestUserClaim { get; set; }
        public ApplicationUser AdminUser { get; set; }

        public IdentityUserClaim<string> AdminUserClaim { get; set; }

        public RecipeDeveloper AdminRecipeDeveloper { get; set; }

        public RecipeDeveloper RecipeDeveloper { get; set; }


        public SeedData()
        {
            SeedIngredients();
            SeedUsers();
            SeedRecipeDevelopers();
            SeedCategories();
            SeedShops();
            SeedSuppliers();
            SeedRecipes();
        }
        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            RecipeDeveloperUser = new ApplicationUser()
            {
                Id = "1f84eebe-b8ff-4c33-a731-fea2572112ae",
                UserName = "recipeDeveloper@mail.com",
                NormalizedEmail = "recipeDeveloper@mail.com",
                Email = "recipeDeveloper@mail.com",
                NormalizedUserName = "recipeDeveloper@mail.com",
                FirstName = "Andrei",
                LastName = "Georgiev"

            };

            RecipeDeveloperUserClaim = new IdentityUserClaim<string>()
            {
                Id = 3,
                ClaimType = UserFullNameType,
                ClaimValue = "Andrei Georgiev",
                UserId = "1f84eebe-b8ff-4c33-a731-fea2572112ae"
            };

            RecipeDeveloperUser.PasswordHash = hasher.HashPassword(RecipeDeveloperUser, "recipeDeveloper123");

            GuestUser = new ApplicationUser()
            {
                Id = "c0518706-d004-453d-930b-ef40cd37d4f0 ",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com",
                FirstName = "Ivan",
                LastName = "Markov"
            };

            GuestUserClaim = new IdentityUserClaim<string>()
            {
                Id = 4,
                ClaimType = UserFullNameType,
                ClaimValue = "Ivan Markov",
                UserId = "c0518706-d004-453d-930b-ef40cd37d4f0 "
            };

            GuestUser.PasswordHash = hasher.HashPassword(RecipeDeveloperUser, "guest123");

            AdminUser = new ApplicationUser()
            {
                Id = "299e94d7-1a68-4738-9d25-e062394ae0c5 ",
                UserName = "admin@mail.com",
                NormalizedUserName = "ADMIN@MAIL.COM",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                FirstName = "Great",
                LastName = "Admin"
            };

            AdminUserClaim = new IdentityUserClaim<string>()
            {
                Id = 5,
                ClaimType = UserFullNameType,
                ClaimValue = "Great Admin",
                UserId = "299e94d7-1a68-4738-9d25-e062394ae0c5 "
            };

            AdminUser.PasswordHash =
                hasher.HashPassword(AdminUser, "admin123");
        }

        private void SeedRecipeDevelopers()
        {
            RecipeDeveloper = new RecipeDeveloper()
            {
                Id = 1,
                Name = "Ivan Mihailov",
                UserId = RecipeDeveloperUser.Id
            };

            AdminRecipeDeveloper = new RecipeDeveloper()
            {
                Id = 11,
                Name = "Georgi Kostadinov",
                UserId = AdminUser.Id
            };
        }

        private void SeedCategories()
        {
            FirstCategory = new Category()
            {
                Id = 1,
                Name = "Gluten free"
            };

            SecondCategory = new Category()
            {
                Id = 2,
                Name = "Dairy free"
            };

            ThirdCategory = new Category()
            {
                Id = 3,
                Name = "High protein"
            };

            FourthCategory = new Category()
            {
                Id = 4,
                Name = "Vegan"
            };

            FifthCategory = new Category()
            {
                Id = 5,
                Name = "Vegetarian"
            };

            NoneCategory = new Category()
            {
                Id = 6,
                Name = "None"
            };
        }

        private void SeedIngredients()
        {
            FirstIngredient = new Ingredient()
            {
                Id = 1,
                Name = "Chicken breast",
                Calories = 240,
                ExpireDate = new DateTime(2024, 12, 31),
                PricePerUnit = (decimal)9,
                Category = "meat",
                ImageUrl = "https://www.allrecipes.com/thmb/Z5s08uvHYI2dg5LAd0vwoA47Ngo=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/240208_simplebakedchickenbreasts_mfs_step1_0181-1-4x3-250b3f145a194aa3bab88e94e3cbae73.jpg"
            };

            SecondIngredient = new Ingredient()
            {
                Id = 2,
                Name = "Cucumber",
                Calories = 45,
                ExpireDate = new DateTime(2024, 12, 31),
                PricePerUnit = (decimal)1.23,
                Category = "vegetable",
                ImageUrl = "data:image/jpeg;base64,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"
            };

            ThirdIngredient = new Ingredient()
            {
                Id = 3,
                Name = "Tomato",
                Calories = 22,
                ExpireDate = new DateTime(2024, 12, 31),
                PricePerUnit = (decimal)1.45,
                Category = "vegetable",
                ImageUrl = "data:image/jpeg;base64,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"
            };

            FourthIngredient = new Ingredient()
            {
                Id = 4,
                Name = "Cheese",
                Calories = 402.5,
                ExpireDate = new DateTime(2024, 12, 31),
                PricePerUnit = (decimal)4.69,
                Category = "dairy product",
                ImageUrl = "https://igourmet.com/cdn/shop/files/189S_Bulgarian_Feta-2.jpg?v=1691411813"
            };

            FifthIngredient = new Ingredient()
            {
                Id = 5,
                Name = "Coocking oil",
                Calories = 884.1,
                ExpireDate = new DateTime(2024, 12, 31),
                PricePerUnit = (decimal)4.20,
                Category = "dressing",
                ImageUrl = "https://cdncloudcart.com/16398/products/images/40252/olio-kaliakra-slancogledovo-1-l-image_5ea2d97e8c9c0_800x800.png?1595836794"
            };

            SixthIngredient = new Ingredient()
            {
                Id = 6,
                Name = "Fish",
                Calories = 350,
                ExpireDate = new DateTime(2024, 12, 31),
                PricePerUnit = (decimal)6.50,
                Category = "see food",
                ImageUrl = "https://www.royco.co.za/cdn-cgi/image/width=1360,height=583,f=auto,quality=90/sites/g/files/fnmzdf1866/files/2022-11/Grilled%20Spicy%20Whole%20Linefish.jpeg"
            };

            SeventhIngredient = new Ingredient()
            {
                Id = 7,
                Name = "Flour",
                Calories = 364,
                ExpireDate = new DateTime(2024, 12, 31),
                PricePerUnit = (decimal)2.40,
                Category = "Cereal Grain",
                ImageUrl = "data:image/jpeg;base64,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"
            };

            EigthIngredient = new Ingredient()
            {
                Id = 8,
                Name = "Sugar",
                Calories = 100,
                ExpireDate = new DateTime(2024, 12, 31),
                PricePerUnit = (decimal)2,
                Category = "sugar",
                ImageUrl = "data:image/jpeg;base64,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"
            };

            NinthIngredient = new Ingredient()
            {
                Id = 9,
                Name = "Salt",
                Calories = 111,
                ExpireDate = new DateTime(2024, 12, 31),
                PricePerUnit = (decimal)2,
                Category = "salt",
                ImageUrl = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/4QBzRXhpZgAASUkqAAgAAAACAA4BAgA7AAAAJgAAAJiCAgAKAAAAYQAAAAAAAABTYWx0IHNoYWtlciB3aXRoIGxhcmdlIGFuZCBzbWFsbCBzYWx0IG9uIGEgYmxhY2sgYmFja2dyb3VuZFBob3Rvc2liZXL/7QCYUGhvdG9zaG9wIDMuMAA4QklNBAQAAAAAAHscAlAAClBob3Rvc2liZXIcAngAO1NhbHQgc2hha2VyIHdpdGggbGFyZ2UgYW5kIHNtYWxsIHNhbHQgb24gYSBibGFjayBiYWNrZ3JvdW5kHAJ0AApQaG90b3NpYmVyHAJuABhHZXR0eSBJbWFnZXMvaVN0b2NrcGhvdG8A/+EFVWh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8APD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4KPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyI+Cgk8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPgoJCTxyZGY6RGVzY3JpcHRpb24gcmRmOmFib3V0PSIiIHhtbG5zOnBob3Rvc2hvcD0iaHR0cDovL25zLmFkb2JlLmNvbS9waG90b3Nob3AvMS4wLyIgeG1sbnM6SXB0YzR4bXBDb3JlPSJodHRwOi8vaXB0Yy5vcmcvc3RkL0lwdGM0eG1wQ29yZS8xLjAveG1sbnMvIiAgIHhtbG5zOkdldHR5SW1hZ2VzR0lGVD0iaHR0cDovL3htcC5nZXR0eWltYWdlcy5jb20vZ2lmdC8xLjAvIiB4bWxuczpkYz0iaHR0cDovL3B1cmwub3JnL2RjL2VsZW1lbnRzLzEuMS8iIHhtbG5zOnBsdXM9Imh0dHA6Ly9ucy51c2VwbHVzLm9yZy9sZGYveG1wLzEuMC8iICB4bWxuczppcHRjRXh0PSJodHRwOi8vaXB0Yy5vcmcvc3RkL0lwdGM0eG1wRXh0LzIwMDgtMDItMjkvIiB4bWxuczp4bXBSaWdodHM9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9yaWdodHMvIiBkYzpSaWdodHM9IlBob3Rvc2liZXIiIHBob3Rvc2hvcDpDcmVkaXQ9IkdldHR5IEltYWdlcy9pU3RvY2twaG90byIgR2V0dHlJbWFnZXNHSUZUOkFzc2V0SUQ9IjQ3MjQ5NDQzNCIgeG1wUmlnaHRzOldlYlN0YXRlbWVudD0iaHR0cHM6Ly93d3cuZ2V0dHlpbWFnZXMuY29tL2V1bGE/dXRtX21lZGl1bT1vcmdhbmljJmFtcDt1dG1fc291cmNlPWdvb2dsZSZhbXA7dXRtX2NhbXBhaWduPWlwdGN1cmwiID4KPGRjOmNyZWF0b3I+PHJkZjpTZXE+PHJkZjpsaT5QaG90b3NpYmVyPC9yZGY6bGk+PC9yZGY6U2VxPjwvZGM6Y3JlYXRvcj48ZGM6ZGVzY3JpcHRpb24+PHJkZjpBbHQ+PHJkZjpsaSB4bWw6bGFuZz0ieC1kZWZhdWx0Ij5TYWx0IHNoYWtlciB3aXRoIGxhcmdlIGFuZCBzbWFsbCBzYWx0IG9uIGEgYmxhY2sgYmFja2dyb3VuZDwvcmRmOmxpPjwvcmRmOkFsdD48L2RjOmRlc2NyaXB0aW9uPgo8cGx1czpMaWNlbnNvcj48cmRmOlNlcT48cmRmOmxpIHJkZjpwYXJzZVR5cGU9J1Jlc291cmNlJz48cGx1czpMaWNlbnNvclVSTD5odHRwczovL3d3dy5nZXR0eWltYWdlcy5jb20vZGV0YWlsLzQ3MjQ5NDQzND91dG1fbWVkaXVtPW9yZ2FuaWMmYW1wO3V0bV9zb3VyY2U9Z29vZ2xlJmFtcDt1dG1fY2FtcGFpZ249aXB0Y3VybDwvcGx1czpMaWNlbnNvclVSTD48L3JkZjpsaT48L3JkZjpTZXE+PC9wbHVzOkxpY2Vuc29yPgoJCTwvcmRmOkRlc2NyaXB0aW9uPgoJPC9yZGY6UkRGPgo8L3g6eG1wbWV0YT4KPD94cGFja2V0IGVuZD0idyI/Pgr/2wCEAAkGBwgHBgkIBwgKCgkLDRYPDQwMDRsUFRAWIB0iIiAdHx8kKDQsJCYxJx8fLT0tMTU3Ojo6Iys/RD84QzQ5OjcBCgoKDQwNGg8PGjclHyU3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3N//AABEIAIQA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"
            };

            TenthIngredient = new Ingredient()
            {
                Id = 10,
                Name = "Egg",
                Calories = 155,
                ExpireDate = new DateTime(2024, 12, 31),
                PricePerUnit = (decimal)1.30,
                Category = "dairy",
                ImageUrl = "data:image/jpeg;base64,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"
            };

            ElevenIngredient = new Ingredient()
            {
                Id = 11,
                Name = "Water",
                Calories = 0,
                ExpireDate = new DateTime(2024, 12, 31),
                PricePerUnit = 0,
                Category = "water",
                ImageUrl = "data:image/jpeg;base64,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"
            };

            TwelveIngredient = new Ingredient()
            {
                Id = 12,
                Name = "Onion",
                Calories = 40,
                ExpireDate = new DateTime(2024, 12, 31),
                PricePerUnit = (decimal)1.15,
                Category = "vegetable",
                ImageUrl = "data:image/jpeg;base64,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"
            };
        }

        private void SeedRecipes()
        {
            FirstRecipe = new Recipe()
            {
                Id = 1,
                Name = "Шопска салата",
                WayOfMaking = "Нарязваме доматите и краставиците и слагаме олио и сирене отгоре",
                CategoryId = 5,
                ImageUrl = "https://www.wandercooks.com/wp-content/uploads/2019/07/bulgarian-shopska-salad-ft2.jpg",
                RecipeDeveloperId = 1,
                
            };

            SecondRecipe = new Recipe()
            {
                Id = 2,
                Name = "Шопска салата с пилешко",
                WayOfMaking = "Нарязваме доматите и краставиците. След това нарязваме и пилешките гърди и ги слагаме в купата. Накрая слагаме олио и месо",
                CategoryId = 6,
                ImageUrl = "https://casafelice.bg/wp-content/uploads/2020/07/tsezar-1.jpg",
                RecipeDeveloperId = 1,


            };
        }

        private void SeedShops()
        {
            FirstShop = new Shop()
            {
                Id = 1,
                Name = "Lidl",
                PhoneNumber = "359888888888",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/91/Lidl-Logo.svg/800px-Lidl-Logo.svg.png",

            };
        }
        private void SeedSuppliers()
        {
            FirstSupplier = new Supplier()
            {
                Id = 1,
                FirstName = "Georgi",
                LastName = "Ivanov",
                Age = 21,
                Rating = 4.5,
                ShopId = FirstShop.Id,
            };
        }

    }

    
}