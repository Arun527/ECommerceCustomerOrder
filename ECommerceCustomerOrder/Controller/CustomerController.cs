using ECommerceApi.Model;
using ECommerceApi.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomer _ICustomerOrderDetail;

        public CustomerController(ICustomer Obj)
        {
            _ICustomerOrderDetail = Obj;
        }

        [HttpGet("Get")]

        public IActionResult GetCustomerList()
        {
            var customer = _ICustomerOrderDetail.GetCustomerDetail();
            if (customer != null)
            {
                return Ok(customer);
            }
            Message obj = new Message();
            obj.success = false;
            obj.message = "The Customer list is empty";
            return Ok(obj);
           
        }

        [HttpGet("Get/{CustomerId}")]

        public IActionResult GetCustomerListById(int CustomerId)
        {
            var customer = _ICustomerOrderDetail.GetCustomerDetailsById(CustomerId);
            if (customer == null)
            {
                Message obj = new Message();
                obj.success = false;
                obj.message = "This customer id not registered";
                return Ok(obj);
            }

            return Ok(customer);
        }

        [HttpPost("Add")]
        public Message InsertCustomerDetail(Customer Obj)
        {
            var customer = _ICustomerOrderDetail.InsertCustomerDetail(Obj);
       
           
                return customer;
            
           
        }

        [HttpPut("Update")]
        public IActionResult UpdateCustomerDetail(Customer Obj)
        {
            var Update = _ICustomerOrderDetail.UpdateCustomerDetail(Obj);

            if (Update != null)
            {
                return Ok(Update);
            }
            Message obj = new Message();
            obj.success = false;
            obj.message = "This customer id not registered";
            return Ok(obj);
            

        }


        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteCustomerDetail(int id)
        {
            var customerid = _ICustomerOrderDetail.GetCustomerDetailsById(id);

            if (customerid != null)
            {
                var delete = _ICustomerOrderDetail.DeleteCustomerDetail(id);

                return Ok(delete);

            }
            Message obj = new Message();
            obj.success = false;
            obj.message = "This customer id not registered";
            return Ok(obj);

        }
    }
}
