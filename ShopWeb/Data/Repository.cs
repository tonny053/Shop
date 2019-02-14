using ShopWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWeb.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext context;       

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products.OrderBy(p => p.Name);
        }

        public Product GetProductById(int id)
        {
            return context.Products.Find(id);
            //return context.Products.Where(p => p.Id == id).FirstOrDefault();
        }

        public void AddProduct(Product product)
        {
            context.Add(product);           
        }

        public void UpdateProduct(Product product)
        {
            context.Products.Update(product);
            //or
            //context.Update(product);
        }

        public void RemoveProduct(Product product)
        {
            context.Products.Remove(product);
            //or
            //context.Remove(product);
        }

        public async Task<bool> SaveAllasync()
        {
            //context.SaveChangesAsync() 
            //devuelve la cantidad de registros modificados 
            return await context.SaveChangesAsync() > 0;
        }


        public bool ProductExists(int id)
        {
            return context.Products.Any(p => p.Id == id);
        }
    }
}
