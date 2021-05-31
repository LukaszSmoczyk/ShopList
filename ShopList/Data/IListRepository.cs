using ShopList.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.Data
{
    public interface IListRepository
    {
        public Task<IEnumerable<List>> GetAll();

        public Task SaveAsync();

        public Task Add(List model);

        public List GetListById(int id);
        public int GetId(int id);

        public string GetListName(int id);

        public int GetItemCount(int id);

    }
}
