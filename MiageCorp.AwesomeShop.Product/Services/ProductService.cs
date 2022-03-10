using MiageCorp.AwesomeShop.Product.Models;
using MiageCorp.AwesomeShop.Product.Exceptions;
namespace MiageCorp.AwesomeShop.Product.Services
{
    public class ProductService : IProductService
    {
        private static List<Produit> produits = new List<Produit>();
        public void addProduct(Produit produit)
        {
            var prod = produits.SingleOrDefault(p => p.Id == produit.Id);
            if (prod == null)
            {
                produits.Add(produit);
            }
            else
            {
                throw new ProductNotFoundException();
            }

        }

        public void deleteProduct(String produitId)
        {
            var prod = produits.SingleOrDefault(p => p.Id == produitId);
            produits.Remove(prod);
           
        }

        public Produit getProductById(String produitId)
        {
            return  produits.SingleOrDefault(p => p.Id == produitId);
        }

        public List<Produit> getProducts()
        {
            return produits;
        }

        public void updateProduct(String id, Produit produit)
        {
            var prod = produits.SingleOrDefault(p => p.Id == id);
            if(prod != null)
            {
                if(produit.Name !=null) prod.Name = produit.Name;
                if (produit.Price != null) prod.Price = produit.Price;
                if (produit.Description != null) prod.Description = produit.Description;

            }
            else
            {
                throw new ProductNotFoundException();
            }
        }
    }
}
