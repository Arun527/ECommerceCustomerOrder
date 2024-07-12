using ECommerceApi.Controller;
using ECommerceApi.Model;
using ECommerceApi.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Food_Test
{
    public class UnitTest1
    {
        private Mock<ICustomer> Mock()
        {
            var mockservice = new Mock<ICustomer>();
            return mockservice;
        }
        private Mock<ICustomer> GetallMock(List<Customer> Lisobj)
        {

            var mockservice = Mock();
            mockservice.Setup(x => x.GetCustomerDetail()).Returns(Lisobj);
            return mockservice;
        }
        private Customer TestData = new Customer()
        {
            CustomerId = 1,
            Name = "Balaji",
            ContactNumber = "9791225793",
            Gender = "male",
            
        };
        [Fact]
        public void GetAllCustomerOk()
        {
            List<Customer> Lisobj = new List<Customer>();
            Lisobj.Add(TestData);
            var controller = new CustomerController(GetallMock(Lisobj).Object);
            var okresult = controller.GetCustomerList();
            var output = okresult as OkObjectResult;
            Assert.IsType<OkObjectResult>(okresult);
            Assert.StrictEqual(200, output.StatusCode);
            Assert.NotNull(okresult);
        }

    }
}