using ShopList.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.ViewModels
{
    public class ItemListViewModel
    {
        public string ListName { get; set; }
        public List<Item> Items { get; set; }

    }
}
