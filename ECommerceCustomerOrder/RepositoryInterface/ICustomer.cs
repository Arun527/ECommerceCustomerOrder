using ECommerceApi.Model;

namespace ECommerceApi.RepositoryInterface
{
    public interface ICustomer
    {
        public IEnumerable<Customer> GetCustomerDetail();
        public Customer GetCustomerDetailsById(int customerId);
        public Message InsertCustomerDetail(Customer Obj);

        public Customer UpdateCustomerDetail(Customer Obj);

        public Message DeleteCustomerDetail(int customerId);
    }
}
