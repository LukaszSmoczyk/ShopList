using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using ShopList.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.Data
{
    public class ShopListDbContext : DbContext
    {

        public ShopListDbContext(DbContextOptions<ShopListDbContext> options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<List> Lists { get; set; }


    }
}
