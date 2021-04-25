using ShopList.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.ViewModels
{
    public class ListViewModel
    {
        public int Id { get; set; }
        public string ListName { get; set; }
        public ICollection<ItemViewModel> Items { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
