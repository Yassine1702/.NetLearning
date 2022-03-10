using MiageCorp.AwesomeShop.Product.Models;
namespace MiageCorp.AwesomeShop.Product.Services
{
    public interface IProductService
    {
        void addProduct(Produit produit);
        Produit getProductById(int id);
        List<Produit> getProducts();
        void updateProduct(Produit produit);
        void deleteProduct(int produitId);
    }
}
