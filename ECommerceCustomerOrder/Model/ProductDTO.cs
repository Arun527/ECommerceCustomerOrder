using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerceApi.Model { 
    public class ProductDTO
    {
     
        public int OrderId { get; set; }

      
        public int CustomerId { get; set; }

        
        public int ProductId { get; set; }

       
        public int Quantity { get; set; }

       
       public List<SelectListItem> ProductList { get; set; }

       public List<SelectListItem> CustomerList { get; set; }

       public List<MultiSelectList> _productselect { get; set; }
    //   public List<SelectListItem> OrderList { get; set; }

    }
}
