﻿using GeorgeShopAndRecipe.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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

        public Supplier FirstSupplier { get; set; }

        public ApplicationUser RecipeDeveloperUser { get; set; }

        public ApplicationUser GuestUser { get; set; }

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
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "recipeDeveloper@mail.com",
                NormalizedEmail = "recipeDeveloper@mail.com",
                Email = "recipeDeveloper@mail.com",
                NormalizedUserName = "recipeDeveloper@mail.com"
            };

            RecipeDeveloperUser.PasswordHash = hasher.HashPassword(RecipeDeveloperUser, "recipeDeveloper123");

            GuestUser = new ApplicationUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };

            GuestUser.PasswordHash = hasher.HashPassword(RecipeDeveloperUser, "guest123");
        }

        private void SeedRecipeDevelopers()
        {
            RecipeDeveloper = new RecipeDeveloper()
            {
                Id = 1,
                Name = "Ivan Mihailov",
                UserId = RecipeDeveloperUser.Id
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