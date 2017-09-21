using My.IOC.Web.Models;
using My.IOC.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My.IOC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerService _customerService;

        public HomeController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public ActionResult Index()
        {
            Customer customerModel = new Customer();
            customerModel = _customerService.GetCustomer();
            return View(customerModel);
        }


    }
}