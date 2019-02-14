namespace ShopWeb.Data
{
    using Microsoft.AspNetCore.Identity;
    using ShopWeb.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        private Random random;

        //<User> es mi clase modelo User e la inyectamos atraves del UserManager
        public SeedDb(DataContext context, UserManager<User> userManager)
        {
            this._context = context;
            this._userManager = userManager;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this._context.Database.EnsureCreatedAsync();

            //Creamos Usuario
            var user = await this._userManager.FindByEmailAsync("tonny053@hotmail.com");
            if (user == null)
            {
                user = new User()
                {
                    FirsrName ="Jose Antonio",
                    Lastname = "Roman",
                    Email = "tonny053@hotmail.com",
                    UserName = "tonny053@hotmail.com",
                    PhoneNumber = "(624) 120 46 87"
                };

                var result = await this._userManager.CreateAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create, the user in Seeder (Semilla)");
                }
            }

            //Creamos productos
            if (!this._context.Products.Any())
            {
                this.AddProduct("Iphone x", user);
                this.AddProduct("Magic Mouse", user);
                this.AddProduct("Iwatch Series 5", user);

                await this._context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            this._context.Products.Add(new Product()
            {
                Name = name,
                Price = this.random.Next(1000),
                IsAvailable = true,
                Stock = this.random.Next(100),
                User = user
            });
        }
    }
}
