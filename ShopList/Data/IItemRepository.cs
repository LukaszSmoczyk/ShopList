using ShopList.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.Data
{
    public interface IItemRepository
    {

        public Task SaveAsync();

        public Task<IEnumerable<Item>> GetAllItemsInList(int id);

        public Task Add(Item model);
    }
}
