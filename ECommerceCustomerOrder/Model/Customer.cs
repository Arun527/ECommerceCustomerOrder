using ECommerceCustomerOrder.Model;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ForeignKeyAttribute = System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;


namespace ECommerceApi.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [ForeignKey("Roll")]
        public int RollId { get; set; } = 1;


        public string Name { get; set; }

       
        [System.ComponentModel.DataAnnotations.StringLength(13, MinimumLength = 10)]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter the Correct Customer Number")]
        [Unique]
        public string ContactNumber { get; set; }


        [Required]
        [MaxLength(100)]
        public string? Gender { get; set; }

        [Required]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,}", 
        ErrorMessage = "Must contain at least one number and one uppercase and lowercase letter, and at least 8 or more characters")]
        public string Password { get; set; }

    }
}
