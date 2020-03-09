using DutchTreat.Data.Entities;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Data
{
    public class DutchSeeder
    {
        private readonly DutchContext _context;
        private readonly IHostEnvironment _env;

        public DutchSeeder(DutchContext context, IHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            if (!_context.Products.Any())
            {
                // Need to create sample data
                var pathName = Path.Combine( _env.ContentRootPath,  "Data/art.json" );
                var json = File.ReadAllText(pathName);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>( json );

                _context.Products.AddRange( products );

                var order = _context.Orders.Where( o => o.Id == 1 ).FirstOrDefault();

                if (order != null)
                {
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
