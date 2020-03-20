using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DutchTreat.Data
{
    public class DutchRepository : IDutchRepository
    {
        private readonly DutchContext _context;
        private readonly ILogger _logger;

        public DutchRepository(DutchContext context, ILogger<DutchRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddEntity(object model)
        {
            _context.Add(model);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .ToList();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("GetAllProducts was called");

                return _context.Products
                    .OrderBy( p => p.Title )
                    .ToList();
            }
            catch ( Exception ex )
            {
                _logger.LogError( $"Failed to get all products: {ex}" );

                return null;
            }
        }

        public Order GetOrderById( int id )
        {
            return _context.Orders
                .Include( o => o.Items )
                .ThenInclude( i => i.Product )
                .Where( o => o.Id == id )
                .FirstOrDefault();
        }

        public IEnumerable<Product> GetProductsByCategory( string category )
        {
            try
            {
                _logger.LogInformation( "GetProductsByCategory was called" );

                return _context.Products
                    .Where( p => p.Category == category )
                    .ToList();
            }
            catch ( Exception ex )
            {
                _logger.LogError( $"Failed to get products by category: {ex}" );

                return null;
            }
        }

        public bool SaveAll()
        {
            try
            {
                _logger.LogInformation( "SaveAll was called" );

                return _context.SaveChanges() > 0;
            }
            catch ( Exception ex )
            {
                _logger.LogError( $"Failed save all: {ex}" );

                return false;
            }
        }

        public bool SaveChanges()
        {
            try
            {
                _logger.LogInformation( "SaveChanges was called" );

                return _context.SaveChanges() > 0;
            }
            catch ( Exception ex )
            {
                _logger.LogError( $"Failed to save changed: {ex}" );

                return false;
            }
        }
    }
}

