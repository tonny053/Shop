namespace ShopWeb.Data
{
    using Microsoft.EntityFrameworkCore;
    using ShopWeb.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {

        }

        public DbSet<Product>  Products { get; set; }
    }
}
