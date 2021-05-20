using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopList.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.Data
{
    public class ItemRepository : IItemRepository
    {
        private readonly ShopListDbContext _context;
        private readonly ILogger<ItemRepository> _logger;

        public ItemRepository(ShopListDbContext context, ILogger<ItemRepository> logger)
        {
            _context = context;
            _logger = logger;
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

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
