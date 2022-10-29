using ECommerceApi.Model;
using ECommerceApi.RepositoryInterface;
using ECommerceCustomerOrder.Model;

namespace ECommerceApi.RepositoryService
{
    public class OrderService:IOrders
    {
        public ECommmerceDbContext Db;

        public OrderService(ECommmerceDbContext Obj)
        {
            Db = Obj;
        }

        public IEnumerable<Orders> GetOrder()
        {
            var order = Db.orders.ToList();
            return order;
        }

        public Orders GetOrderById(int OrderId)
        {
            try
            {
                var Order = Db.orders.Find(OrderId);
                return Order;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Message InsertOrder(Orders obj)
        {    
            Message msg = new Message();
            var ord = Db.Customer.FirstOrDefault(x => x.CustomerId == obj.CustomerId);
            if (ord != null)
            {
                msg.success = true;
                msg.message = "Order added succesfully";
                Db.orders.Add(obj);
                Db.SaveChanges();
            }
            else
            {
                msg.success = false;
                msg.message = "The customer id not registered";
            }
            return msg;
        }

        public Orders UpdateOrder(Orders obj)
        {
            var Upd = GetOrderById(obj.OrderId);
            if (Upd.OrderId != null)
            {
                var order = Db.orders.Update(obj);
                Db.Update(order);
                Db.SaveChanges();
                return obj;
            }
            throw new Exception("This order id not registered");
        }

        public Message DeleteOrder(int orderId)
        {

            Message obj = new Message();
            obj.success = false;
            try
            {
            var delete = Db.orders.Find(orderId);
            Db.Remove(delete);
            Db.SaveChanges();
                obj.message = "Customer Succesfully deleted";
                obj.success = true;
                return obj;
            }

            catch (Exception ex)
            {
                obj.message = ex.Message;
                return obj;
            }
        }

    }
}
