using Microsoft.AspNetCore.Identity;

namespace ECommerceApi.Model
{
    public class Message
    {
        public string message { get; set; } = String.Empty;
        public bool success { get; set; }   

        public bool  Role { get; set; }

    }
}
