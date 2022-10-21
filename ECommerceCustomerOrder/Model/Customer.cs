using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }


        public string Name { get; set; }




        //[System.ComponentModel.DataAnnotations.StringLength(30, MinimumLength = 2)]
        //[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter the Customer name")]

       
        [System.ComponentModel.DataAnnotations.StringLength(13, MinimumLength = 10)]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter the Correct Customer Number")]
        [Unique]
        public string ContactNumber { get; set; }

    }
}
