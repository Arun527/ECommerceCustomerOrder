using ECommerceApi.Model;
using ECommerceCustomerOrder.Model;

namespace ECommerceApi.RepositoryInterface
{
    public interface IOrders
    {
        public IEnumerable<Orders> GetOrder();
        public Orders GetOrderById(int productId);
        public Message InsertOrder(Orders Obj);
        public Orders UpdateOrder(Orders Obj);
        public Message DeleteOrder(int orderId);
    }
}
