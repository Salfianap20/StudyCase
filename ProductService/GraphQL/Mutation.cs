using HotChocolate.AspNetCore.Authorization;
using ProductService.Models;

namespace ProductService.GraphQL
{
    public class Mutation
    {
        //Add
        [Authorize(Roles = new[] { "MANAGER" })]
        public async Task<Product> AddProductAsync(
            ProductInput input,
            [Service] studycaseContext context)
        {

            // EF
            var product = new Product
            {
                Name = input.Name,
                Stock = input.Stock,
                Price = input.Price,
                Created = DateTime.Now
            };

            var ret = context.Products.Add(product);
            await context.SaveChangesAsync();

            return ret.Entity;
        }
        //Update 
        [Authorize(Roles = new[] { "MANAGER" })]
        public async Task<Product> UpdateProductAsync(
            ProductInput input,
            [Service] studycaseContext context)
        {
            var product = context.Products.Where(o => o.Id == input.Id).FirstOrDefault();
            if (product != null)
            {
                product.Name = input.Name;
                product.Stock = input.Stock;
                product.Price = input.Price;

                context.Products.Update(product);
                await context.SaveChangesAsync();
            }
            return await Task.FromResult(product);
        }

        //Delete
        [Authorize(Roles = new[] { "MANAGER" })]
        public async Task<Product> DeleteProductByIdAsync(
            int id,
            [Service] studycaseContext context)
        {
            var product = context.Products.Where(o => o.Id == id).FirstOrDefault();
            if (product != null)
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync();
            }
            return await Task.FromResult(product);
        }
    }
}
