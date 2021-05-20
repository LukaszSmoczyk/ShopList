using ShopList.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.ViewModels
{
    public class ItemListViewModel
    {
        public int Id { get; set; }
        public string ListName { get; set; }
        public ICollection<Item> Items { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Quantity { get; set; }
        public List List { get; set; }
        public AppUser User { get; }
    }
}
