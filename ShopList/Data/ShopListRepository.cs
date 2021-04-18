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
        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("GetAllProducts was calle");

                return _context.Products
                    .OrderBy(p => p.Title)
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
