using ECommerceApi.Model;
using ECommerceApi.RepositoryInterface;
using ECommerceCustomerOrder.Model;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Security.Principal;
using System.Xml.Linq;

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

        [Authorize]
        public IActionResult Index()
        {
            return RedirectToAction("CustomerView");
        }

        public IActionResult Login()
       {
            return View();
        }

        //public ActionResult Details()
        //{
        //    // reading a claim
        //    var key2 = Claim.ClaimTypes("key2");
        //}
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var user = _ICustomer.loginbyid(login.ContactNumber, login.Password);
           // var r = _ICustomer.loginbyid(login.RollId);
            if (user != null)
            {
              
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier , user.CustomerId.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.RollName)
              

                };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
              
                    return Redirect(login.ReturnUrl == null ? "/CustomerMvc/CustomerlView" : login.ReturnUrl);
              

                
            
               
            }
            else
                return View(login);
        }

        
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "CustomerMvc");
        }
        public ActionResult Add()
        {

            LoginDto types = new LoginDto();
            var RollList = _ICustomer.GetRoll().ToList();
            types.RollList = new List<SelectListItem>();
            types.RollList.Add(new SelectListItem() { Value = "0", Text = "Select Type" });
            types.RollList.AddRange(
            _ICustomer.GetRoll().Select(a => new SelectListItem
            {
                Text = a.RollName,
                Value = a.RollId.ToString(),

            }));
           

            return View(types);

        }
        public ActionResult LoginAdd()
        {

            LoginDto types = new LoginDto();
            var RollList = _ICustomer.GetRoll().ToList();
            types.RollList = new List<SelectListItem>();
            types.RollList.Add(new SelectListItem() { Value = "0", Text = "Select Type" });
            types.RollList.AddRange(
            _ICustomer.GetRoll().Select(a => new SelectListItem
            {
                Text = a.RollName,
                Value = a.RollId.ToString(),

            }));


            return View(types);

        }
        public IActionResult AddCustomer(Customer obj)
        
        
        {
            var customer = _ICustomer.InsertCustomerDetail(obj);
            //TempData["AlertMessage"] = "Customer Created succesfully";
            return Json(customer);
           
        
        }

        [Authorize]
        public IActionResult CustomerView()
        {
            var customer=_ICustomer.GetCustomerDetail();
            return View(customer);
        }

        [Authorize]
        public IActionResult CustomerDetailView(int Id)
        {
            var customer = _IorderDetail.GetCustomerOrderDetailsById(Id);
            return View(customer);
 
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var delete = _ICustomer.DeleteCustomerDetail(id);
            return Json(delete);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Update(int id)
        {
            var update=_ICustomer.GetCustomerDetailsById(id);
            return View("Updatedetail",update);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Updatedetail(Customer update)
        { 
            var upd=_ICustomer.UpdateCustomerDetail(update);
            return RedirectToAction("CustomerView");
        }

    }
}
