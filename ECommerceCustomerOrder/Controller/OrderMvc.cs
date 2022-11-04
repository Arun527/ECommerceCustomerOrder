using ECommerceApi.Model;
using ECommerceApi.RepositoryInterface;
using ECommerceCustomerOrder.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceCustomerOrder.Controllers
{
    public class OrderMvc : Controller
    {
        private readonly ILogger<OrderMvc> _logger;
        IOrders _IOrder;
        ICustomer _ICustomer;
        public OrderMvc(ILogger<OrderMvc> logger, IOrders obj, ICustomer iCustomer)
        {
            _logger = logger;
            _IOrder = obj;
            _ICustomer = iCustomer;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Add()
        {

            return View("Add");
        }
        [Authorize]
        public IActionResult AddOrder(Orders obj)
        {
            Message Msg = new Message();
            var order = _IOrder.GetOrderById(obj.OrderId);
            if(order ==null){
              
                Msg.message = "The Order Added succesfully ";
                var customer = _IOrder.InsertOrder(obj);
                return RedirectToAction("OrderView");
            }
            else
            {
                Msg.message = "The Customer Id not Registerex";
            }
            return RedirectToAction("OrderView");
        }

        [Authorize]
        public IActionResult OrderView()
        {
            var customer = _IOrder.GetOrder();
            return View(customer);
        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            var delete = _IOrder.DeleteOrder(id);
            return Json(delete);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Update(int id)
        {
            var update = _IOrder.GetOrderById(id);
            return View("Updatedetail", update);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Updatedetail(Orders update)
        {
            var upd = _IOrder.UpdateOrder(update);
            return RedirectToAction("OrderView");
        }

    }
}
