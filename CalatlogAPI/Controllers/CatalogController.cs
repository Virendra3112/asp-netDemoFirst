using CalatlogAPI.Entities;
using CalatlogAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CalatlogAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private IProductRepository _repository;
        private ILogger _logger;

        public CatalogController(IProductRepository repository, ILogger logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _repository.GetProducts();

            return Ok(products);
        }

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProductById(string id)
        {
            var product = await _repository.GetProduct(id);

            if (product == null)
            {
                _logger.LogError($"Product with id : {id}  not found.");
                return NotFound();
            }
            return Ok(product);

        }

        [Route("[action]/category", Name = "GetProductByCategory")]
        [HttpGet]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProductByCategory(string Category)
        {
            var product = await _repository.GetProductsByCategory(Category);

            if (product == null)
            {
                _logger.LogError($"Product with Category : {Category}  not found.");
                return NotFound();
            }
            return Ok(product);
        }

        //[HttpPost]
        //[ProducesResponseType(typeof(Product), (int)HttpStatusCode.Created)]
        //public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        //{
        //    await _repository.CreateProduct(product);
        //    return CreatedAtRoute("GetProduct", new { id, product.Id }, product);
        //}

        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> UpdateProduct([FromBody] Product product)
        {
            return Ok(await _repository.UpdateProduct(product));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> DeleteProduct([FromBody] string id)
        {
            return Ok(await _repository.DeleteProduct(id));
        }
    }
}
