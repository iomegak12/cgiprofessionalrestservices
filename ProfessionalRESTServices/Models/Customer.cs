using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfessionalRESTServices.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public int CreditLimit { get; set; }
        public bool Status { get; set; }

        public override string ToString()
        {
            return string.Format(@"{0}, {1}, {2}, {3}, {4}",
                this.CustomerId, this.Name, this.Address, this.CreditLimit, this.Status);
        }
    }
}
