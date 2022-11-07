using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApi.Model
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }


        [ForeignKey("Customer")]
        public virtual int CustomerId { get; set; }

        
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }


        [ForeignKey("Orders")]
        public int OrderId { get; set; }

       

        [ForeignKey("Product")]

        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please Enter Minimum Quanity")]
        [Range(1, 999)]


        public int Quantity { get; set; }
    }
}
