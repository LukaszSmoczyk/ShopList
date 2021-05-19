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

        public async Task<IEnumerable<List>> GetAll()
        {
            return await _context.Set<List>().ToListAsync();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Add(List model)
        {
            await _context.Set<List>().AddAsync(model);
        }

        public async Task<List> GetListById(int id)
        {
            return await _context.Lists
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Item>> GetAllItemsInList(int id)
        {
            return await _context.Set<Item>()
                .Where(i => i.List.Id == id)
                .ToListAsync();
        }

        public async Task Add(Item model)
        {
            await _context.Set<Item>().AddAsync(model);
        }
    }
}
