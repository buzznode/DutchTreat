using DutchTreat.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IDutchRepository _repo;

        public OrdersController(IDutchRepository repo, ILogger<OrdersController> logger)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok( _repo.GetAllOrders() );
            }
            catch ( Exception ex )
            {
                _logger.LogError( $"Failed to get orders: {ex}" );
                return BadRequest( "Failed to get orders" );
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var order = _repo.GetOrderById( id );

                if (order != null)
                {
                    return Ok( order );
                }
                else
                {
                    return NotFound();
                }
            }
            catch ( Exception ex )
            {
                _logger.LogError( $"Failed to get orders: {ex}" );
                return BadRequest( "Failed to get orders" );
            }
        }
    }
}
