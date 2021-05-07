using ShopList.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.Data
{
    public interface IShopListRepository
    {
        public Task<IEnumerable<object>> GetAll();

        public Task SaveAsync();


        public Task Add(object model);


        public Task<List> GetListById(int id);

    }
}
