using ECommerceApi.Model;
using ECommerceApi.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceCustomerOrder.Controllers
{
    public class ProductMvcController : Controller
    {

        private readonly ILogger<ProductMvcController> _logger;

        IProduct _IProduct;

        public ProductMvcController(ILogger<ProductMvcController> logger,IProduct obj)
        {
            _logger = logger;
            _IProduct = obj;
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
           
            return View("Add");
        }

        public IActionResult AddProduct(Product obj)
        {

            Message Msg=new Message();
      
            var  Product =_IProduct.GetProductDetailsByName(obj.Name);

            if (Product == null)
            {

                var insert = _IProduct.InsertProductDetail(obj);
                Msg.success = true;
                ViewBag.Message = Msg.message = "The product Added succesfully";
                return View("Add");
            }

            else
            {
                Msg.success = false;
                ViewBag.Message = Msg.message = "The product Already exist";


            }
            return View("Add");
        }
        public IActionResult ProductView()
        {
          var product=  _IProduct.GetProductDetail();
            return View(product);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var update = _IProduct.GetProductDetailsById(id);
            return View("Add", update);
        }

        [HttpPost]
        public IActionResult UpdateDetail(Product obj)
        {
            var updatedetail = _IProduct.Updateproduct(obj);
            return RedirectToAction("ProductView");
        }
        public IActionResult DeleteProduct(int  id)
        {
            var delete = _IProduct.Deleteproduct(id);
            return Json(delete);
        }

    }
}
