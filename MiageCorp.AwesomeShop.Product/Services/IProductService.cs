using MiageCorp.AwesomeShop.Product.Models;
namespace MiageCorp.AwesomeShop.Product.Services
{
    public interface IProductService
    {
        void addProduct(Produit produit);
        Produit getProductById(String id);
        List<Produit> getProducts();
        void updateProduct(String id,Produit produit);
        void deleteProduct(String produitId);
    }
}
