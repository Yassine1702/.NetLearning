using MiageCorp.AwesomeShop.Product.Models;
using MiageCorp.AwesomeShop.Product.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiageCorp.AwesomeShop.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
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
        public Produit Get(int productId)
        {
           var prod =  productService.getProductById(productId);
            if (prod == null) throw new InvalidDataException();
            return prod;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] Produit product)
        {
            try
            {
                productService.addProduct(product);
            }
            catch(InvalidDataException e )
            {
                e.GetBaseException();
            }
           
        }

        // PUT api/<ProductsController>/5
        [HttpPut()]
        public void Put([FromBody] Produit produit)
        {
            try { 
                 productService.updateProduct(produit);

            }catch(InvalidDataException e)
            {
                e.GetBaseException();
            }
}

        // DELETE api/<ProductsController>/5
        [HttpDelete("{productId}")]
        public void Delete(int productId)
        {
            productService.deleteProduct(productId);
        }
    }
}
