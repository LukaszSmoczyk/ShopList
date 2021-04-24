using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.Data.Entities
{
    public class List
    {
        public int Id { get; set; }
        public string ListName { get; set; }
        public List<Product> Products { get; set; }
        public DateTime DateTime { get; set; }


    }
}
