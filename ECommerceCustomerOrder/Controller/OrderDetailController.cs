using ECommerceApi.Model;
using ECommerceApi.RepositoryInterface;
using ECommerceCustomerOrder.Model;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        IOrderDetail _IOrderDetail;
        ICustomer _ICustomer;
        IProduct _IProduct;
        IOrders _IOrders;

        public OrderDetailController(IOrderDetail Obj, ICustomer customer, IProduct product, IOrders orders)
        {
            _IOrderDetail = Obj;
            _ICustomer = customer;
            _IProduct = product;
            _IOrders = orders;

        }

        [HttpGet("Get")]
        public IActionResult GetAllOrdersDetail()
        {
            var orderlist = _IOrderDetail.GetOrderList();
            if (orderlist.Count() == 0)
            {

                throw new Exception("order list is empty");

            }
            return Ok(orderlist);

        }

        [HttpGet("Get/{OrderId}")]
        public IActionResult GetOrderDetailById(int OrderId)
        {
            var order = _IOrderDetail.GetOrderDetailsById(OrderId);
            if (order == null)
            {
                Message obj = new Message();
                obj.success = false;
                obj.message = "This customer id not registered";
                return Ok(obj);
               
            }
            return Ok(order);

        }

        [HttpGet("GetInvoice/{CustomerId}")]
        public IActionResult GetCustomerOrderDetailById(int CustomerId)
        {


            var order = _IOrderDetail.GetCustomerOrderDetailsById(CustomerId);
            if (order.Count() == 0)
            {
                Message obj = new Message();
                obj.success = false;
                obj.message = "This customer id not registered";
                return Ok(obj);
              
            }
            return Ok(order);

        }

        [HttpPost("Add")]
        public IActionResult InsertOrderDetail(OrderRequest obj)
        {
            Message Obj = new Message();
            //var order = _IOrders.GetOrderById(obj.OrderId);
            //if (order == null)
            //{
            //    Obj.success = false;
            //    Obj.message = "This Order id not registered";
            //    return Ok(Obj);
        
            //}
            //var Custmer = _ICustomer.GetCustomerDetailsById(obj.CustomerId);
            //if (Custmer == null)
            //{
            //    Obj.success = false;
            //    Obj.message = "This Customer not registered Please signup a customer detail";
            //    return Ok(Obj);
               
            //}

            //var product = _IProduct.GetProductDetailsById(obj.ProductId);
            //if (product == null)
            //{
            //    Obj.success = false;
            //    Obj.message = "This product  Not registered";
            //    return Ok(Obj);
               
            //}

            var Order = _IOrderDetail.InsertOrderDetail(obj);
            Obj.success = true;
            Obj.message = "This Order  Added succesfully";
            return Ok(Order);
        }

        [HttpPut("Update")]
        public IActionResult UpdateOrderDetail(OrderDetail Order)
        {
            Message obj = new Message();
            var order = _IOrderDetail.GetOrderDetailsById(Order.OrderDetailId);

            if (order != null)
            {
                var upd = _IOrderDetail.UpdateOrderDetail(Order);
                obj.success = true;
                obj.message = "This Order  updated succesfully";
                return Ok(upd);
            }
          
            obj.success = false;
            obj.message = "This Order  not registered";
            return Ok(obj);
          


        }

        [HttpDelete("Delete/{OrderDetaileId}")]
        public IActionResult DeleteOrderDetail(int OrderDetaileId)
        {
            Message obj = new Message();
            var order = _IOrderDetail.GetOrderDetailsById(OrderDetaileId);

            if (order != null)
            {
                var orders = _IOrderDetail.DeleteOrderDetail(OrderDetaileId);
                obj.success = true;
                obj.message = "This Order   registered succesfully";
                return Ok(orders);

            }
            else
            {
              
                obj.success = false;
                obj.message = "This Order  not registered";
                return Ok(obj);
              
            }
        }
    }
}
