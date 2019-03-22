using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfessionalRESTServices.Controllers.Interfaces
{
    public interface ICustomersApiController
    {
        IActionResult GetCustomers();
        IActionResult FindCustomers(string customerName);

        IActionResult GetConfigurationData();
    }
}
