using Eshop.Entity.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Eshop.Entity.Context
{
    public static class SeedData
    {
        public static void Seed(this EshopContext context)
        {
            var dogCategory = new AnimalCategory
            {
                Name = "Dog"
            };
            var catCategory = new AnimalCategory
            {
                Name = "Cat"
            };
            var othersCategory = new AnimalCategory
            {
                Name = "Others"
            };
            if (!context.AnimalCategories.Any())
            {
                var animalCategories = new List<AnimalCategory>
                {
                    dogCategory,
                    catCategory,
                    othersCategory
                };
                context.AnimalCategories.AddRange(animalCategories);
                context.SaveChanges();
            }
            if (!context.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product
                    {
                        Name = "Blue Baffalo",
                        AnimalCategoryId = dogCategory.Id,
                        Price = 20,
                        Description = "Blue Buffalo Life Protection Formula Adult Chicken & Brown Rice Recipe Dry Dog Food"
                    },
                    new Product
                    {
                        Name = "Taste Of Wild",
                        AnimalCategoryId = dogCategory.Id,
                        Price = 35,
                        Description = "Taste of the Wild High Prairie Grain-Free Dry Dog Food"
                    },
                    new Product
                    {
                        Name = "American Journey",
                        AnimalCategoryId =dogCategory.Id,
                        Description = "American Journey Salmon & Sweet Potato Recipe Grain-Free Dry Dog Food",
                        Price = 30
                    },
                    new Product
                    {
                        Name = "Fancy Feast",
                        AnimalCategoryId = catCategory.Id,
                        Description = "Fancy Feast Grilled Seafood Feast Variety Pack Canned Cat Food",
                        Price = 15
                    }
                };
                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}
