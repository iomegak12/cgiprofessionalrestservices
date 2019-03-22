using Microsoft.AspNetCore.Mvc;
using Moq;
using ProfessionalRESTServices.Controllers;
using ProfessionalRESTServices.Models;
using ProfessionalRESTServices.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ProfessionalRESTServices.Tests
{
    public class CustomersControllerTests
    {
        [Fact]
        public void Test1()
        {
            var mockRepository = new MockRepository(MockBehavior.Default);
            var mockCustomers = new List<Customer>
            {
                new Customer { CustomerId = 1, Name = "Mock Customer 1", Address = "Bangalore", CreditLimit = 23000, Status = true }
            };
            var mockCustomerService = mockRepository.Create<ICustomerService>();
            var customerName = default(string);

            mockCustomerService
                .Setup(customerService => customerService.GetCustomers(customerName))
                .Returns(mockCustomers);

            var customersController = new CustomersController(mockCustomerService.Object);
            var result = customersController.GetCustomers() as OkObjectResult;

            Assert.NotNull(result);

            var customers = result.Value as IEnumerable<Customer>;
            var expectedNoOfCustomers = 1;
            var actualNoOfCustomers = customers.Count();

            Assert.Equal(expectedNoOfCustomers, actualNoOfCustomers);
        }
    }
}
