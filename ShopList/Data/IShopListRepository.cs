using ShopList.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.Data
{
    public interface IShopListRepository
    {
        IEnumerable<Item> GetAllItems();
        IEnumerable<List> GetAllLists();
        void AddEntity(object model);
        bool SaveAll();
    }
}
