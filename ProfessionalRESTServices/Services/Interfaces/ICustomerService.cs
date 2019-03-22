using ProfessionalRESTServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfessionalRESTServices.Services.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers(string customerName = default(string));
    }
}
