namespace ECommerceCustomerOrder.Model
{
    public class OrderRequest
    {
        public int CustomerId { get; set; }
        public List<ProductDetail> Products { get; set; }

        public bool Role { get; set; }
    }

    public class ProductDetail
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
