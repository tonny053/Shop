namespace ShopWeb.Data
{
    using ShopWeb.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext _context;
        private Random random;

        public SeedDb(DataContext context)
        {
            this._context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this._context.Database.EnsureCreatedAsync();

            if(!this._context.Products.Any())
            {
                this.AddProduct("Iphone x");
                this.AddProduct("Magic Mouse");
                this.AddProduct("Iwatch Series 5");

                await this._context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name)
        {
            this._context.Products.Add(new Product()
            {
                Name = name,
                Price = this.random.Next(1000),
                IsAvailable = true,
                Stock = this.random.Next(100)
            });
        }
    }
}
