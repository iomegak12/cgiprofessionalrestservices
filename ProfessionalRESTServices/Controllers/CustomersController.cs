using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfessionalRESTServices.Configuration;
using ProfessionalRESTServices.Controllers.Interfaces;
using ProfessionalRESTServices.Services.Interfaces;

namespace ProfessionalRESTServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase, ICustomersApiController
    {
        private const int MIN_SEARCH_LENGTH = 3;
        private const string BUSINESS_VALIDATION_FAILED = "Customer Search Business Validation Failed!";

        private ICustomerService customerService = default(ICustomerService);

        public CustomersController(ICustomerService customerService)
        {
            if (customerService == default(ICustomerService))
                throw new ArgumentNullException(nameof(customerService));

            this.customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = this.customerService.GetCustomers();

            return Ok(customers);
        }

        [HttpGet("search/{customerName}")]
        public IActionResult FindCustomers(string customerName)
        {
            var validation = !string.IsNullOrEmpty(customerName) &&
                customerName.Length >= MIN_SEARCH_LENGTH;

            if (!validation)
                throw new ApplicationException(BUSINESS_VALIDATION_FAILED);

            var filteredCustomers = this.customerService.GetCustomers(customerName);

            return Ok(filteredCustomers);
        }

        [HttpGet("env")]
        public IActionResult GetConfigurationData()
        {
            var configurationKey = "ConnectionString";
            var configurationData = ConfigProvider.GetConfigurationData(configurationKey);

            return Ok(configurationData);
        }
    }
}