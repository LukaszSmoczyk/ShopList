using ShopList.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.ViewModels
{
    public class ListViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string ListName { get; set; }
        public ICollection<ItemViewModel> Items { get; set; }
    }
}
