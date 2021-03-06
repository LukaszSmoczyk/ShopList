using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.Data.Entities
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Quantity { get; set; }
        public DateTime DateOfAddingItem { get; set; }
        public List List { get; set; }
        public AppUser User { get; }
    }
}
