namespace ECommerceApi.Model
{
    public class InvoiceDetail
    {
        public int InVoiceNo { get; set; }

        public int OrderId { get; set; }
 
        public DateTime OrderDate { get; set; }
        public String? CustomerName { get; set; }
        public String? ProductName { get; set; }

        public string Contactnumber { get; set; }
        public int price { get; set; }

        public int Quantity { get; set; }

        public int TotalPrice { get; set; }
    }
}
