using ECommerceApi.Model;
using ECommerceApi.RepositoryInterface;
using ECommerceCustomerOrder.Model;
using Microsoft.AspNetCore.Http.Features;

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
                    msg.success = true;
                    msg.message = "Customer Added Succesfully";
                }
                else
                {

                    msg.message = "The Customer  Mobile Number  " + customer.ContactNumber + " Alrady Exist  ";
                }
                return msg;
            }

            catch (Exception ex)
            {
                msg.message = ex.Message;

                return msg;
            }


        }


        public Message UpdateCustomerDetail(Customer Obj)
        {
            Message msg = new Message();
            try
            {

                Customer cus = GetCustomerDetailsById(Obj.CustomerId);
                msg.success = false;
                if (Obj.CustomerId != null)
                {
                    cus.Name = Obj.Name;
                    cus.ContactNumber = Obj.ContactNumber;
                    cus.Password = Obj.Password;
                    cus.Gender = Obj.Gender;
                    Db.Update(cus);
                    Db.SaveChanges();
                    msg.success = true;
                    msg.message = "Customer Updated Succesfully";
                    return msg;
                }
                else
                {
                    msg.success = false;
                    msg.message = "Phone number already exist";
                    return msg;
                }

            }

            catch (Exception ex)
            {
                msg.message = ex.Message;
                return msg;
            }


        }

        public Message DeleteCustomerDetail(int id)
        {
            Message obj = new Message();
            obj.success = false;
            try
            {
                var delete = Db.Customer.FirstOrDefault(d => d.CustomerId == id);
                var deleteorder = Db.orders.FirstOrDefault(d => d.CustomerId == id);

                if (delete != null && deleteorder == null)
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
                obj.message = ex.Message;
                return obj;
            }


        }
        public IEnumerable<Roll> GetRoll()
        {
            return Db.Roll.ToList();
        }
        public Roll GetRollDetailsById(int RollId)
        {
          
            try
            {
                var roll = Db.Roll.Find(RollId);
                return roll;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public LoginDto loginbyid( string number, string password)
        {
            var Customer = (from customer in Db.Customer

                            join Roll in Db.Roll on customer.RollId equals Roll.RollId
            
                            where customer.Password == password && customer.ContactNumber == number 
                            
                            select new LoginDto()
                            {                               
                                ContactNumber = customer.ContactNumber,
                                Password = customer.Password,
                                CustomerId=customer.CustomerId,
                                Name = customer.Name,
                                RollId = Roll.RollId,
                                RollName =Roll.RollName,
                                Gender=customer.Gender,
                            }).FirstOrDefault();

            return Customer;
        }
    }
}

