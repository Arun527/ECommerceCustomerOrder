using System.ComponentModel.DataAnnotations;

namespace ECommerceCustomerOrder.Model
{
    public class Roll
    {

        [Key]
        public int RollId { get; set; }

        public string RollName { get; set; }

        public Boolean IsActive { get; set; }
    }
}
