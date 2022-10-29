using ECommerceApi.Model;
using ECommerceApi.RepositoryInterface;
using ECommerceCustomerOrder.Model;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

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
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var user = _ICustomer.loginbyid(login.Name, login.Password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier , user.CustomerId.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.Password)



               };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");



                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return Redirect(login.ReturnUrl == null ? "/CustomerMvc/CustomerView" : login.ReturnUrl);
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

        public IActionResult AddCustomer(Customer obj)
        
        
        {
            var customer = _ICustomer.InsertCustomerDetail(obj);
            //TempData["AlertMessage"] = "Customer Created succesfully";
            return Json(customer);
           
        
        }


        public IActionResult CustomerView()
        {
            var customer=_ICustomer.GetCustomerDetail();
            return View(customer);
        }
        public IActionResult CustomerDetailView(int Id)
        {
            var customer = _IorderDetail.GetCustomerOrderDetailsById(Id);
            return View(customer);
 
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
