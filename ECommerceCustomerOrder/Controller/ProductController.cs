using ECommerceApi.Model;
using ECommerceApi.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProduct _IProduct;

        public ProductController(IProduct Obj)
        {
            _IProduct = Obj;
        }


        [HttpGet("Get")]
        public IActionResult GetProduct()
        {
            var product = _IProduct.GetProductDetail();
            if (product == null)
            {
                Message obj = new Message();
                obj.success = false;
                obj.message = "The product list is empty";
                return Ok(obj);
              
            }
            return Ok(product);

        }

        [HttpGet("Get/{id}")]

        public IActionResult GetProduct(int id)
        {
            var product = _IProduct.GetProductDetailsById(id);
            if (product == null)
            {
                Message obj = new Message();
                obj.success = false;
                obj.message = "The product Not Registered";
                return Ok(obj);
        
            }
            return Ok(product);

        }

        [HttpPost("Add")]
        public IActionResult InsertProductDetail(Product Obj)
        {
            Message Msg = new Message();
            var insert=_IProduct.GetProductDetailsByName(Obj.Name);
            if(insert == null)
            {
                var product = _IProduct.InsertProductDetail(Obj);
                Msg.success = true;
                Msg.message = "The product Added Succsfully";
                return Ok(product);
            }
            else
            {
                Msg.success = false;
                Msg.message = "The product Already Exist";
            }
            return Ok(Msg);

        }

        [HttpPut("Update")]
        public IActionResult UpdateProduct(Product Obj)
        {
            var update = _IProduct.GetProductDetailsById(Obj.ProductId);
            if (update != null)
            {
                return Ok(update);
            }
            Message obj = new Message();
            obj.success = false;
            obj.message = "The product Not Registered";
            return Ok(obj);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _IProduct.GetProductDetailsById(id);

            if (product != null)
            {
                var del = _IProduct.Deleteproduct(id);
                return Ok(del);
            }

            Message obj = new Message();
            obj.success = false;
            obj.message = "The product Not Registered";
            return Ok(obj);
        }


    }
}
