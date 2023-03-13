using InventoryCore.Entity;
using InventoryCore.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryInfrastructure.Data
{
    public class AppDbContextInitialiser
    {
        private readonly ILogger<AppDbContextInitialiser> _logger;
        private readonly AppDbContext _context;

        public AppDbContextInitialiser(ILogger<AppDbContextInitialiser> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
          
        }

        public async Task InitialiseAsync()
        {
            try
            {
                if (_context.Database.IsSqlServer())
                {
                    await _context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            if (!_context.Products.Any())
            {
                _context.Products.Add(new Product
                {
                    Barcode = "111",
                    CategoryName = "A",
                    Description = "Product 1 Desc",
                    IsWeighted = true,
                    Name = "Product 1",
                    Status = ProductStatus.InStock
                });

                _context.Products.Add(new Product
                {
                    Barcode = "222",
                    CategoryName = "B",
                    Description = "Product 2 Desc",
                    IsWeighted = true,
                    Name = "Product 1",
                    Status = ProductStatus.InStock
                });
                _context.Products.Add(new Product
                {
                    Barcode = "333",
                    CategoryName = "C",
                    Description = "Product 3 Desc",
                    IsWeighted = true,
                    Name = "Product 3",
                    Status = ProductStatus.InStock
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}
