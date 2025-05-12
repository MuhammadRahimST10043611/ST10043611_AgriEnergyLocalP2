using ProgAgriP2New.Models;
using Microsoft.EntityFrameworkCore;

namespace ProgAgriP2New.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Create database if it doesn't exist
            context.Database.EnsureCreated();

            // Check if there are any employees already (to avoid re-seeding)
            if (context.Employees.Any())
            {
                return; // Database has already been seeded
            }

            // Seed Employees (Soccer Managers)
            var employees = new Employee[]
            {
                new Employee
                {
                    Name = "Pep Guardiola",
                    Email = "pep@progagri.com",
                    Password = "Admin123!"
                },
                new Employee
                {
                    Name = "Jurgen Klopp",
                    Email = "klopp@progagri.com",
                    Password = "Admin123!"
                },
                new Employee
                {
                    Name = "Carlo Ancelotti",
                    Email = "carlo@progagri.com",
                    Password = "Admin123!"
                }
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();

            // Seed Farmers (Soccer Players)
            var farmers = new Farmer[]
            {
                new Farmer
                {
                    Name = "Lionel Messi",
                    Email = "messi@farm.com",
                    Password = "Farmer123!",
                    Address = "10 Vineyard Avenue, Constantia, Cape Town",
                    PhoneNumber = "021-555-1010"
                },
                new Farmer
                {
                    Name = "Cristiano Ronaldo",
                    Email = "ronaldo@farm.com",
                    Password = "Farmer123!",
                    Address = "7 Mountain View Road, Hout Bay, Cape Town",
                    PhoneNumber = "021-555-0777"
                },
                new Farmer
                {
                    Name = "Mohamed Salah",
                    Email = "salah@farm.com",
                    Password = "Farmer123!",
                    Address = "11 Ocean Drive, Sea Point, Cape Town",
                    PhoneNumber = "021-555-1111"
                },
                new Farmer
                {
                    Name = "Kevin De Bruyne",
                    Email = "kdb@farm.com",
                    Password = "Farmer123!",
                    Address = "17 Table Mountain Road, Camps Bay, Cape Town",
                    PhoneNumber = "021-555-1717"
                }
            };

            context.Farmers.AddRange(farmers);
            context.SaveChanges();

            // Seed Products - Messi (Specialty in South American crops)
            var products = new Product[]
            {
                new Product
                {
                    FarmerId = 1,
                    Name = "Organic Malbec Grapes",
                    Category = "Fruits",
                    ProductionDate = DateTime.Now.AddDays(-10)
                },
                new Product
                {
                    FarmerId = 1,
                    Name = "Argentine Beef",
                    Category = "Meat",
                    ProductionDate = DateTime.Now.AddDays(-5)
                },
                new Product
                {
                    FarmerId = 1,
                    Name = "Yerba Mate Leaves",
                    Category = "Herbs",
                    ProductionDate = DateTime.Now.AddDays(-15)
                },
                new Product
                {
                    FarmerId = 1,
                    Name = "Premium Quinoa",
                    Category = "Grains",
                    ProductionDate = DateTime.Now.AddDays(-20)
                },
                
                // Ronaldo (Specialty in Mediterranean produce)
                new Product
                {
                    FarmerId = 2,
                    Name = "Portuguese Olive Oil",
                    Category = "Oils",
                    ProductionDate = DateTime.Now.AddDays(-8)
                },
                new Product
                {
                    FarmerId = 2,
                    Name = "Madeira Wine Grapes",
                    Category = "Fruits",
                    ProductionDate = DateTime.Now.AddDays(-12)
                },
                new Product
                {
                    FarmerId = 2,
                    Name = "Atlantic Sardines",
                    Category = "Seafood",
                    ProductionDate = DateTime.Now.AddDays(-3)
                },
                new Product
                {
                    FarmerId = 2,
                    Name = "Portuguese Cork",
                    Category = "Materials",
                    ProductionDate = DateTime.Now.AddDays(-25)
                },
                
                // Salah (Specialty in North African/Middle Eastern produce)
                new Product
                {
                    FarmerId = 3,
                    Name = "Egyptian Cotton",
                    Category = "Materials",
                    ProductionDate = DateTime.Now.AddDays(-18)
                },
                new Product
                {
                    FarmerId = 3,
                    Name = "Medjool Dates",
                    Category = "Fruits",
                    ProductionDate = DateTime.Now.AddDays(-7)
                },
                new Product
                {
                    FarmerId = 3,
                    Name = "Tahini Paste",
                    Category = "Condiments",
                    ProductionDate = DateTime.Now.AddDays(-9)
                },
                new Product
                {
                    FarmerId = 3,
                    Name = "Za'atar Spice Mix",
                    Category = "Spices",
                    ProductionDate = DateTime.Now.AddDays(-14)
                },
                
                // De Bruyne (Specialty in Belgian and European produce)
                new Product
                {
                    FarmerId = 4,
                    Name = "Belgian Hops",
                    Category = "Brewing",
                    ProductionDate = DateTime.Now.AddDays(-11)
                },
                new Product
                {
                    FarmerId = 4,
                    Name = "Sugar Beets",
                    Category = "Vegetables",
                    ProductionDate = DateTime.Now.AddDays(-6)
                },
                new Product
                {
                    FarmerId = 4,
                    Name = "Flanders Potatoes",
                    Category = "Vegetables",
                    ProductionDate = DateTime.Now.AddDays(-4)
                },
                new Product
                {
                    FarmerId = 4,
                    Name = "Brussels Sprouts",
                    Category = "Vegetables",
                    ProductionDate = DateTime.Now.AddDays(-16)
                }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}