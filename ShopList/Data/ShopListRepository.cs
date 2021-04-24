using Microsoft.Extensions.Logging;
using ShopList.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.Data
{
    public class ShopListRepository : IShopListRepository
    {
        private readonly ShopListDbContext _context;
        private readonly ILogger<ShopListRepository> _logger;

        public ShopListRepository(ShopListDbContext context, ILogger<ShopListRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<List> GetAllLists()
        {
            try
            {
                _logger.LogInformation("GetAllLists was called");

                return _context.Lists
                    .OrderBy(l => l.ListName)
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all lists: {ex}");
                return null;
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("GetAllProducts was called");

                return _context.Products
                    .OrderBy(p => p.ProductName)
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products: {ex}");
                return null;
            }
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
