using ECommerceApi.Model;
using ECommerceApi.RepositoryInterface;
using ECommerceCustomerOrder.Model;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        ICustomer _ICustomer;
        IOrders _IOrders;
        public OrdersController(IOrders Obj,ICustomer customer)
        {
            _IOrders = Obj;
            _ICustomer = customer;
        }

        [HttpGet("Get")]

        public IActionResult GetOrder()
        {

            var orders = _IOrders.GetOrder();
            if (orders.Count() != 0)
            {
                var insert = _IOrders.GetOrder();
                return Ok(insert);
            }
            else
            {
                Message obj = new Message();
                obj.success = false;
                obj.message = "Order list is empty";
                return Ok(obj);
                


            }
        }

        [HttpGet("Get/{OrderId}")]
        public IActionResult GetOrderById(int OrderId)
        {
            var order = _IOrders.GetOrderById(OrderId);
            if (order == null)
            {
                Message obj = new Message();
                obj.success = false;
                obj.message = "This order Not  Registered";
                return Ok(obj);

            }
            return Ok(order);

        }


        [HttpPost("Add")]
        public IActionResult InsertOrder(Orders obj)
        {

            var Custmer = _ICustomer.GetCustomerDetailsById(obj.CustomerId);
            if (Custmer == null)
            {
                Message msg = new Message();
                msg.success = false;
                msg.message = "This Customer not registered Please signup a customer detail";
                return Ok(msg);

             
            }
            var insert = _IOrders.InsertOrder(obj);
            return Ok(insert);  
        }

        [HttpPut("Update")]
        public IActionResult UpdateOrder(Orders Obj)
        {
            var update = _IOrders.GetOrderById(Obj.OrderId);
            if (update != null)
            {
                 return Ok(update);

            }
            else
            {
                Message msg = new Message();
                msg.success = false;
                msg.message = "This Order not registered";
                return Ok(msg);
            }
        }

        [HttpDelete("Delete/{OrderId}")]
        public IActionResult DeleteOrder(int OrderId)
        {
            var id = _IOrders.GetOrderById(OrderId);
            if (id != null)
            {
                var delete = _IOrders.DeleteOrder(OrderId);
                return Ok(delete);
            }

            Message msg = new Message();
            msg.success = false;
            msg.message = "This Order not registered";
            return Ok(msg);
        }
    }
}
