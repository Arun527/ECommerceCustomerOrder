using ECommerceApi.Model;
using ECommerceApi.RepositoryInterface;
using ECommerceCustomerOrder.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Net.Mime.MediaTypeNames;

namespace ECommerceCustomerOrder.Controllers
{
    public class OrderDetailMvcController : Controller
    {

        private readonly ILogger<OrderDetailMvcController> _logger;
        IOrderDetail _IOrderDetail;
        IOrders _IOrders;
        ICustomer _ICustomer;
        IProduct _IProduct;     

        public OrderDetailMvcController(ILogger<OrderDetailMvcController> logger, IOrderDetail obj, IOrders iOrders, ICustomer iCustomer, IProduct iProduct)
        {
            _logger = logger;
            _IOrderDetail = obj;
            _IOrders = iOrders;
            _ICustomer = iCustomer;
            _IProduct = iProduct;
        }
        public ActionResult Add()
        {
            ProductDTO types = new ProductDTO();
            var productList = _IProduct.GetProductDetail().ToList();
            types.ProductList = new List<SelectListItem>();
            types.ProductList.Add(new SelectListItem() { Value = "0", Text = "Select Prodcut" });
            types.ProductList.AddRange(
            _IProduct.GetProductDetail().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.ProductId.ToString(),

            }));
            types.CustomerList = _ICustomer.GetCustomerDetail().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.CustomerId.ToString(),

            }).ToList();

            return View(types);

        }

        public IActionResult AddOrder([FromBody]OrderRequest request)
        {
            var Order = _IOrderDetail.InsertOrderDetail(request);
            return Json(Order);
        }

        public IActionResult OrderDetailView()
        {
            var customer= _IOrderDetail.GetOrderList();
            return View(customer);
        }

        public IActionResult Invoice()
        {
            var invoice = _IOrderDetail.GetCustomerOrderList();
            return View(invoice);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var update = _IOrderDetail.GetOrderDetailsById(id);
            return View("UpdateDetail", update);
        }
        [HttpPost]
        public IActionResult UpdateDetail(OrderDetail update)
        {
            var updatedetail = _IOrderDetail.UpdateOrderDetail(update);
            return RedirectToAction("OrderDetailView");
        }
        public IActionResult DeleteOrderDetail(int id)
        {
            var delete = _IOrderDetail.DeleteOrderDetail(id);
            return RedirectToAction("OrderDetailView");
        }
    }
}
