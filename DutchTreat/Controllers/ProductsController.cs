using DutchTreat.Data;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
    [ApiController]
    [Route( "api/[Controller]" )]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IDutchRepository _repo;

        public ProductsController(IDutchRepository repo, ILogger<ProductsController> logger)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Product>> Get()
        {
            _logger.LogInformation( $"ProductController.Get called" );

            try
            {
                return Ok( _repo.GetAllProducts() );

            }
            catch ( Exception ex )
            {
                _logger.LogError( $"Failed to get products: {ex}" );
                return BadRequest( "Failed to get any products" );
            }
        }
    }
}
