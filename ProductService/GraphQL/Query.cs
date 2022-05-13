using System.Security.Claims;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ProductService.Models;

namespace ProductService.GraphQL
{
    public class Query
    {
        [Authorize]
        public IQueryable<Product> GetProducts([Service] studycaseContext context, ClaimsPrincipal claimsPrincipal)
        {
            var userName = claimsPrincipal.Identity.Name;

            // check manager role ?
            var managerRole = claimsPrincipal.Claims.Where(o => o.Type == ClaimTypes.Role && o.Value == "MANAGER").FirstOrDefault();
            var product = context.Users.Where(o => o.Username == userName).FirstOrDefault();
            if (product != null)
            {
                if (managerRole != null)
                    return context.Products;

                var products = context.Products.Where(o => o.Id == product.Id);
                return products.AsQueryable();
            }
            return new List<Product>().AsQueryable();
        }
    }
}
