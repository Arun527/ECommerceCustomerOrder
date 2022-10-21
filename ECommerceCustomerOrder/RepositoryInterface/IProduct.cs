using ECommerceApi.Model;

namespace ECommerceApi.RepositoryInterface
{
    public interface IProduct
    {
        public IEnumerable<Product> GetProductDetail();
        Product GetProductDetailsById(int productId);
        Product GetProductDetailsByName(string Name);
        Message InsertProductDetail(Product Obj);

        Product Updateproduct(Product Obj);

        Message Deleteproduct(int productId);
    }
}
