using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApi.Model
{
    public class Orders
    {

        [Key]
        public int OrderId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [DefaultValue("Orderdate")]
        public DateTime Orderdate { get; set; } = DateTime.Now;
    }
}
