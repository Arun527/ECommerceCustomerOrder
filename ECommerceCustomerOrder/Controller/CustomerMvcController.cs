using ECommerceApi.Model;
using ECommerceApi.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceCustomerOrder.Controllers
{
    public class CustomerMvcController : Controller
    {

        private readonly ILogger<CustomerMvcController> _logger;
        ICustomer _ICustomer;
        IOrderDetail _IorderDetail;
        public CustomerMvcController(ILogger<CustomerMvcController> logger, ICustomer obj, IOrderDetail obj2)
        {
            _logger = logger;
            _ICustomer= obj;
            _IorderDetail= obj2;    
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            
            return View("Add");

        }

        public IActionResult AddCustomer(Customer obj)
        
        
        {
            var customer = _ICustomer.InsertCustomerDetail(obj);
            //return Json("CustomerView");
            return Json(customer);
           
        
        }


        public IActionResult CustomerView()
        {
            var customer=_ICustomer.GetCustomerDetail();
            return View(customer);
        }

        public IActionResult CustomerDetailViewshow(int Id)
        {
            //var customer = _IorderDetail.GetCustomerOrderDetailsById(Id);

            return View();
        }
        public IActionResult CustomerDetailView(int Id)
        {
            var customer = _IorderDetail.GetCustomerOrderDetailsById(Id);
            return View(customer);
           // return RedirectToAction("CustomerDetailViewshow");
        }
        public IActionResult Delete(int id)
        {
            var delete = _ICustomer.DeleteCustomerDetail(id);
            return Json(delete);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var update=_ICustomer.GetCustomerDetailsById(id);
            return View("Updatedetail",update);
        }

        [HttpPost]
        public IActionResult Updatedetail(Customer update)
        { 
            var upd=_ICustomer.UpdateCustomerDetail(update);
            return RedirectToAction("CustomerView");
        }

    }
}
