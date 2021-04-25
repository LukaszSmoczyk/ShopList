using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.Data.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Quantity { get; set; }
        public DateTime DateOfAddingItem { get; set; }
        public AppUser User { get; }
    }
}
