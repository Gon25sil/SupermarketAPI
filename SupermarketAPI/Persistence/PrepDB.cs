using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SupermarketAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.Domain.Persistance
{
    public static class PrepDB
    {
        public static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                SeedData(scope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext appDbContext)
        {
            Console.WriteLine("Applying migrations...");
            appDbContext.Database.Migrate();

            if (!appDbContext.Categories.Any())
            {
                Console.WriteLine("Adding Categories Data...");
                appDbContext.Categories.Add(
                    new Category()
                    {
                        Name = "Fruit",
                    });
                appDbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Database already has Categories - not seeding");
            }

            if (!appDbContext.Products.Any())
            {
                Console.WriteLine("Adding Products Data...");

                appDbContext.Products.Add(
                    new Product()
                    {
                        CategoryId = appDbContext.Categories.First().Id,
                        Name = "Apple",
                        QuantityInPackage = 2,
                        UnitOfMeasurement = EUnitOfMeasurement.Kilogram
                    });
                appDbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Database already has Products - not seeding");
            }
        }
    }
}
