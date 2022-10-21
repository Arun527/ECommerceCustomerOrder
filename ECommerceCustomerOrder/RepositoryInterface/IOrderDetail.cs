using ECommerceApi.Model;
using ECommerceCustomerOrder.Model;

namespace ECommerceApi.RepositoryInterface
{
    public interface IOrderDetail
    {
        public IEnumerable<OrderDetail> GetOrderList();

        public OrderDetail GetOrderDetailsById(int Id);

        public IEnumerable<InvoiceDetail> GetCustomerOrderDetailsById(int Id);

        public IEnumerable<InvoiceDetail> GetCustomerOrderList();
        public Message InsertOrderDetail(OrderRequest orderDetail);


        public OrderDetail UpdateOrderDetail(OrderDetail orderDetail);
        public OrderDetail DeleteOrderDetail(int orderDetailId);
    }
}
