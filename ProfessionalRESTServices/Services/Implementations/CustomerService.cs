using ProfessionalRESTServices.Models;
using ProfessionalRESTServices.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfessionalRESTServices.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private static List<Customer> customers = default(List<Customer>);

        static CustomerService()
        {
            customers = new List<Customer>
            {
                new Customer { CustomerId = 11, Name = "Northwind", Address = "Bangalore", CreditLimit = 23000, Status = true },
                new Customer { CustomerId = 12, Name = "Southwind", Address = "Bangalore", CreditLimit = 23000, Status = true },
                new Customer { CustomerId = 13, Name = "Eastwind", Address = "Bangalore", CreditLimit = 23000, Status = true },
                new Customer { CustomerId = 14, Name = "Westwind", Address = "Bangalore", CreditLimit = 23000, Status = true },
                new Customer { CustomerId = 15, Name = "Oxyrich", Address = "Bangalore", CreditLimit = 23000, Status = true },
                new Customer { CustomerId = 16, Name = "Adventureworks", Address = "Bangalore", CreditLimit = 23000, Status = true }
            };
        }

        public IEnumerable<Customer> GetCustomers(string customerName = null)
        {
            var filteredCustomers = default(IEnumerable<Customer>);

            if (string.IsNullOrEmpty(customerName))
                filteredCustomers =
                   customers
                    .Where(customer => customer.Name.Contains(customerName))
                    .ToList();
            else filteredCustomers = customers;

            return filteredCustomers;
        }
    }
}
