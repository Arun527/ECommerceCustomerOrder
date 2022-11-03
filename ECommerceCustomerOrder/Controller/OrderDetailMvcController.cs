using ECommerceApi.Model;
using ECommerceApi.RepositoryInterface;
using ECommerceCustomerOrder.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
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



        [Authorize]
        public ActionResult Add()
        {
            string role = User.Identity.GetClaimRole();
            string Id = User.Identity.GetClaimValue();
            ProductDTO types = new ProductDTO();
            if (User.Identity.IsAuthenticated)
            {
               
                var productList = _IProduct.GetProductDetail().ToList();
                types.ProductList = new List<SelectListItem>();
                types.ProductList.Add(new SelectListItem() { Value = "0", Text = "Select Prodcut" });
                types.ProductList.AddRange(
                _IProduct.GetProductDetail().Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.ProductId.ToString(),

                }));
                if (role == "Admin")
                {
                    types.CustomerList = _ICustomer.GetCustomerDetail().Select(a => new SelectListItem
                    {
                        Text = a.Name,
                        Value = a.CustomerId.ToString(),

                    }).ToList();
              
                }
                else
                {
                    types.CustomerList = _ICustomer.GetCustomerDetail().Where(x => x.CustomerId.ToString() == Id).Select(a => new SelectListItem
                    {
                        Text = a.Name,
                        Value = a.CustomerId.ToString(),

                    }).ToList();
                   
                }
               
                return View(types);
            }

            return View(types);
        }
        [Authorize]
        public IActionResult AddOrder([FromBody]OrderRequest request)
        {
            var role = User.Identity.GetClaimRole();
            if (role == "Admin")
            {
                request.Role=true;
            }
            else
            {
                request.Role = false;
            }
            var Order = _IOrderDetail.InsertOrderDetail(request);

            return Json(Order);
          //  return View("Add");
        }
        [Authorize]
        public IActionResult OrderDetailView()
        {
            var customer= _IOrderDetail.GetOrderList();
            return View(customer);
        }
        [Authorize]
        public IActionResult Invoice()
        {
            var invoice = _IOrderDetail.GetCustomerOrderList();
            return View(invoice);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Update(int id)
        {
            var update = _IOrderDetail.GetOrderDetailsById(id);
            return View("UpdateDetail", update);
        }
        [HttpPost]
        [Authorize]
        public IActionResult UpdateDetail(OrderDetail update)
        {
            var updatedetail = _IOrderDetail.UpdateOrderDetail(update);
            return RedirectToAction("OrderDetailView");
        }
        [Authorize]
        public IActionResult DeleteOrderDetail(int id)
        {
            var delete = _IOrderDetail.DeleteOrderDetail(id);
            var role = User.Identity.GetClaimRole();
            if (role == "Admin")
            {

                return Json(delete);
            }
            else
            {
                return Json(delete);
            }
        }
    }
}
