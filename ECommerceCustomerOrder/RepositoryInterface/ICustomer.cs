using ECommerceApi.Model;
using ECommerceCustomerOrder.Model;

namespace ECommerceApi.RepositoryInterface
{
    public interface ICustomer
    {
        public IEnumerable<Customer> GetCustomerDetail();
        public Customer GetCustomerDetailsById(int customerId);
        public Message InsertCustomerDetail(Customer Obj);
        public Message UpdateCustomerDetail(Customer Obj);
        public Message DeleteCustomerDetail(int customerId);

        public IEnumerable<Roll> GetRoll();

        public LoginDto loginbyid(string password, string number);
    }
}
