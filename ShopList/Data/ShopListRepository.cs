using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopList.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<IEnumerable<object>> GetAll()
        {
            return await _context.Set<object>().ToListAsync();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Add(object model)
        {
            await _context.Set<object>().AddAsync(model);
        }

        public async Task<List> GetListById(int id)
        {
            return await _context.Lists
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
