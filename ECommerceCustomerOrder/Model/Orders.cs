using ECommerceApi.Model;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceCustomerOrder.Model
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }

        [Display(Name ="Customer")]
        public virtual int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customerid { get; set; }

        [DefaultValue("Orderdate")]
        public DateTime Orderdate { get; set; } = DateTime.Now;


    }
}
