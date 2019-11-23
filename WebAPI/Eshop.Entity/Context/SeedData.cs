using Eshop.Entity.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Eshop.Entity.Context
{
    public static class SeedData
    {
        public static void Seed(this EshopContext context)
        {
            if (!context.AnimalCategories.Any())
            {
                var animalCategories = new List<AnimalCategory>
                {
                    new AnimalCategory
                    {
                        Id = 1,
                        Name = "Dog"
                    },
                    new AnimalCategory
                    {
                        Id = 2,
                        Name = "Cat"
                    },
                    new AnimalCategory
                    {
                        Id = 3,
                        Name = "Others"
                    }
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
                        Id = 1,
                        Name = "Blue Baffalo",
                        AnimalCategoryId = 1,
                        Price = 20,
                        Description = "Blue Buffalo Life Protection Formula Adult Chicken & Brown Rice Recipe Dry Dog Food"
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Taste Of Wild",
                        AnimalCategoryId = 1,
                        Price = 35,
                        Description = "Taste of the Wild High Prairie Grain-Free Dry Dog Food"
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "American Journey",
                        AnimalCategoryId = 1,
                        Description = "American Journey Salmon & Sweet Potato Recipe Grain-Free Dry Dog Food",
                        Price = 30
                    },
                    new Product
                    {
                        Id = 4,
                        Name = "Fancy Feast",
                        AnimalCategoryId = 2,
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
