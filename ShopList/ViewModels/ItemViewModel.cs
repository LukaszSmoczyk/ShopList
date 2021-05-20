using ShopList.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.ViewModels
{
    public class ItemViewModel
    {
        public int ItemId { get; set; }

        [Required]
        [MinLength(2)]
        public string ItemName { get; set; }
        public string Quantity { get; set; }
        public ListViewModel List { get; set; }

    }
}
