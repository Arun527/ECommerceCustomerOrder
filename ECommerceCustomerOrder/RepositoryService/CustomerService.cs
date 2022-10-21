using ECommerceApi.Model;
using ECommerceApi.RepositoryInterface;
using ECommerceCustomerOrder.Model;

namespace ECommerceApi.RepositoryService
{
    public class CustomerService : ICustomer
    {
        public ECommmerceDbContext Db;

        public CustomerService(ECommmerceDbContext Obj)
        {
            Db = Obj;
        }




        public IEnumerable<Customer> GetCustomerDetail()
        {

            try
            {
                var Cus = Db.Customer.ToList();
                return Cus;
            }

            catch (Exception)
            {
                throw;
            }



        }

        public Customer GetCustomerDetailsById(int customerId)
        {

            Customer _Obj;
            try
            {
                var o = Db.Customer.Find(customerId);
                return o;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Message InsertCustomerDetail(Customer Obj)
        {
            Message msg = new Message();
            try
            {
                var customer = Db.Customer.FirstOrDefault(x => x.ContactNumber == Obj.ContactNumber);
                msg.success = false;
                if (customer == null)
                {
                    Db.Customer.Add(Obj);
                    Db.SaveChanges();
                    msg.message="Customer Added Succesfully";
                }
                else
                {
                    msg.success = false;
                    msg.message = "The Customer  Mobile Number  "+ customer.ContactNumber + " Alrady Exist  ";
                }
                return msg; 
            }
           
           


              catch (Exception ex)
            {
                msg.message = ex.Message;

                return msg;
            }

            
        }


        public Customer UpdateCustomerDetail(Customer Obj)
        {
            try
            {

                Customer cus = GetCustomerDetailsById(Obj.CustomerId);
                if (Obj.CustomerId != null)
                {
                    cus.Name = Obj.Name;
                    cus.ContactNumber = Obj.ContactNumber;
                    Db.Update(cus);
                    Db.SaveChanges();

                }
                return Obj;

            }

            catch (Exception)
            {
                throw new Exception("This customer id not registered");
            }


        }

        public Message DeleteCustomerDetail(int id)
        {
            Message obj=new Message();
            obj.success = false;
            try
            {
                var delete = Db.Customer.FirstOrDefault(d => d.CustomerId == id);
                var deleteorder=Db.orders.FirstOrDefault(d => d.CustomerId == id);  

                if(delete !=null && deleteorder == null)
                {
                    Db.Remove(delete);
                    Db.SaveChanges();
                    obj.message = "Customer Succesfully deleted";
                    obj.success = true;
                    return obj;
                }
                else
                {
                    obj.success = false;
                    obj.message = "This customer order the  product so the customer id not removable";
                }
              return obj;
            }

            catch (Exception ex)
            {
               obj.message=ex.Message;
                return obj;
            }


        }

    }
}
