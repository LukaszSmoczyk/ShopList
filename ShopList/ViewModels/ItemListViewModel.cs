using ShopList.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.ViewModels
{
    public class ItemListViewModel
    {
        // list
        public int ListId { get; set; }
        public string ListName { get; set; }
        public List<Item> Items { get; set; }

        // item
        public int ItemId { get; set; }
        [Required]
        [MinLength(2)]
        public string ItemName { get; set; }
        public string Quantity { get; set; }
        public DateTime DateOfAddingItem { get; set; }
        public List List { get; set; }

    }
}
