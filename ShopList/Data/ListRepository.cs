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
    public class ListRepository : IListRepository
    {
        private readonly ShopListDbContext _context;
        private readonly ILogger<ListRepository> _logger;

        public ListRepository(ShopListDbContext context, ILogger<ListRepository> logger)
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

        public List GetListById(int id)
        {
            return _context.Lists.
                Where(i => i.Id == id).
                FirstOrDefault();
        }

        public string GetListName(int id)
        {
            return _context.Lists
                .Where(i => i.Id == id)
                .FirstOrDefault()
                .ListName;
        }
    }
}
