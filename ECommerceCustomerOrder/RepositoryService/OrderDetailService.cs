using ECommerceApi.Model;
using ECommerceApi.RepositoryInterface;

using ECommerceCustomerOrder.Model;

namespace ECommerceApi.RepositoryService
{
    public class OrderDetailService:IOrderDetail
    {
        public ECommmerceDbContext Db;

        public OrderDetailService(ECommmerceDbContext Obj)
        {
            Db = Obj;
        }

        public IEnumerable<OrderDetail> GetOrderList()
        {
            try
            {
                var ordlist = Db.OrderDetail.ToList();

                return ordlist;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public OrderDetail GetOrderDetailsById(int Id)
        {

            var obj = Db.OrderDetail.FirstOrDefault(x => x.OrderDetailId == Id);
            return obj;
        }

        public IEnumerable<InvoiceDetail> GetCustomerOrderDetailsById(int CustomerId)
        {

            var orderDetails = (from orderDetail in Db.OrderDetail
                                join customer in Db.Customer on orderDetail.CustomerId equals customer.CustomerId
                                join product in Db.Product on orderDetail.ProductId equals product.ProductId
                                join order in Db.orders on orderDetail.OrderId equals order.OrderId
                                where orderDetail.CustomerId == CustomerId
                                select new InvoiceDetail
                                {
                                    InVoiceNo = orderDetail.OrderDetailId,
                                    OrderId = orderDetail.OrderId,
                                    CustomerName = customer.Name,
                                    ProductName = product.Name,
                                    Contactnumber=customer.ContactNumber,
                                    OrderDate = order.Orderdate,
                                    price = product.Price,
                                    Quantity = orderDetail.Quantity,
                                    TotalPrice = product.Price * orderDetail.Quantity
                                }).ToList();

            return orderDetails;
        }

        public IEnumerable<InvoiceDetail> GetCustomerOrderList()
        {
            var orderDetails = (from orderDetail in Db.OrderDetail

                                join customer in Db.Customer on orderDetail.CustomerId equals customer.CustomerId

                                join product in Db.Product on orderDetail.ProductId equals product.ProductId
                           
                                join order in Db.orders on orderDetail.OrderId equals order.OrderId
                                select new InvoiceDetail
                                {
                                    InVoiceNo = orderDetail.OrderDetailId,
                                    OrderId= orderDetail.OrderId,
                                    OrderDate=order.Orderdate,
                                    CustomerName = customer.Name,
                                    Contactnumber=customer.ContactNumber,
                                    ProductName = product.Name,
                                    
                                    price = product.Price,
                                    Quantity = orderDetail.Quantity,
                                    TotalPrice = product.Price * orderDetail.Quantity
                                }).ToList();

            return orderDetails;
        }

        public Message InsertOrderDetail(OrderRequest orderDetail)
        {
            Message Msg = new Message();
            try
            {
                Orders orders = new Orders();
                orders.CustomerId = orderDetail.CustomerId;
                Db.Add(orders);
                Db.SaveChanges();
                var orderId = orders.OrderId;

                foreach (var producs in orderDetail.Products)
                {
                    var details = new OrderDetail()
                    {
                        OrderId = orderId,
                        CustomerId = orderDetail.CustomerId,
                        ProductId = producs.ProductId,
                        Quantity = producs.Quantity
                    };
                    Db.Add(details);
                }                

                Db.SaveChanges();
                Msg.success = true;
                Msg.message = "The order Added Succesfully";
                Msg.Role=orderDetail.Role;
                return Msg;
            }
            catch (Exception)
            {
                throw;
               
            }
            return Msg;
        }

        public OrderDetail UpdateOrderDetail(OrderDetail obj)
        {

            var _orddet = GetOrderDetailsById(obj.OrderDetailId);

            if (obj.OrderDetailId != null)
            {

               
                _orddet.CustomerId = obj.CustomerId;
                _orddet.ProductId = obj.ProductId;
                _orddet.Quantity = obj.Quantity;

                Db.Update(_orddet);
                Db.SaveChanges();

            }

            return obj;




        }

        public Message DeleteOrderDetail(int OrderDetaileId)
        {
            Message obj = new Message();
            obj.success = false;
            try
            {
                var order = Db.OrderDetail.Find(OrderDetaileId);
                Db.Remove(order);
                Db.SaveChanges();
                obj.message = "Order deleted Succesfully";
                obj.success = true;
                return obj;
            }
            catch (Exception)
            {
                obj.message = "Order delete Failed";
                obj.success = false;
                throw new Exception("This id not registered in order table");
            }
        }
    }
}
