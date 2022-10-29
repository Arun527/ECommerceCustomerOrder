using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Unique]
        [System.ComponentModel.DataAnnotations.StringLength(30, MinimumLength = 2)]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter the product name")]
        public string Name { get; set; }


        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Range(1, 2147483647)]
        public int Price { get; set; }

    }
}
