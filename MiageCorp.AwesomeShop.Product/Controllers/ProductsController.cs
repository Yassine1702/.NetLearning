using MiageCorp.AwesomeShop.Product.Models;
using MiageCorp.AwesomeShop.Product.Services;
using MiageCorp.AwesomeShop.Product.Exceptions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiageCorp.AwesomeShop.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        // Dependency Injection 

        private IProductService productService;

        public ProductsController(IProductService productservice)
        {
            this.productService = productservice;
        }




        // GET: api/<ProductsController>
        [HttpGet]
        public List<Produit> Get()
        {
            return productService.getProducts();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{productId}")]
        public IActionResult Get(String productId)
        {
           var prod =  productService.getProductById(productId);
            if (prod == null) return NotFound();
            return Ok(prod);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Produit product)
        {
            String id = Guid.NewGuid().ToString();
           
            try
            {
                productService.addProduct(product);
                return Ok();
            }
            catch(ProductAlreadyExists e )
            {
                return Conflict();
            }
           
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(String id, [FromBody] Produit produit)
        {
            try { 
                 productService.updateProduct(id, produit);
                return Ok();

            }catch(ProductNotFoundException e)
            {
           
                return NotFound();
            }
}

        // DELETE api/<ProductsController>/5
        [HttpDelete("{productId}")]
        public IActionResult Delete(String productId)
        {
            productService.deleteProduct(productId);
            return Ok();
        }
    }
}
