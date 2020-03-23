using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Data
{
    public class DutchSeeder
    {
        private readonly DutchContext _context;
        private readonly IHostEnvironment _env;
        private readonly UserManager<StoreUser> _userManager;

        public DutchSeeder(DutchContext context, IHostEnvironment env, UserManager<StoreUser> userManager)
        {
            _context = context;
            _env = env;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _context.Database.EnsureCreated();

            StoreUser user = await _userManager.FindByEmailAsync("buzznode@yahoo.com");

            if (user == null)
            {
                user = new StoreUser()
                {
                    FirstName = "Buzz",
                    LastName = "Node",
                    Email = "buzznode@yahoo.com",
                    UserName = "buzznode@yahoo.com"
                };

                var result = await _userManager.CreateAsync(user, "Kon26Kon!");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException($"Could not create new user: {user.UserName} in seeder");
                }
            }

            if (!_context.Products.Any())
            {
                // Need to create sample data
                var pathName = Path.Combine(_env.ContentRootPath,  "Data/art.json");
                var json = File.ReadAllText(pathName);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);

                _context.Products.AddRange(products);

                var order = _context.Orders.Where(o => o.Id == 1).FirstOrDefault();

                if (order != null)
                {
                    order.User = user;
                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product = products.First(),
                            Quantity = 5,
                            UnitPrice = products.First().Price
                        }
                    };
                }
                _context.SaveChanges();
            }
        }
    }
}
