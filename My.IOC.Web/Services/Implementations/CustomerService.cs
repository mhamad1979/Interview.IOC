using My.IOC.Web.Models;
using My.IOC.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace My.IOC.Web.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        public Customer GetCustomer()
        {
            Customer customer = new Customer();
            customer.Id = 1;
            customer.CustomerName = "John Smith";

            return customer;
        }
    }
}