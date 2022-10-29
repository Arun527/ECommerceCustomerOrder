using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace ECommerceCustomerOrder.Model
{
    public class LoginDto
    {
        public int CustomerId { get; set; }

        public int RollId { get; set; }


        public string Name { get; set; }

        public string ReturnUrl { get; set; }

        
        public string ContactNumber { get; set; }


     
        public string? Gender { get; set; }


        public string Password { get; set; }

        public string RollName { get; set; }

        public List<SelectListItem> RollList { get; set; }
    }
}
