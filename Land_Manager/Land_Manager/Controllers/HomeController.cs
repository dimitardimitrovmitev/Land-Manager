using Data;
using Microsoft.AspNetCore.Mvc;
using Land_Manager.Models;
using Land_Manager.Models.PaymentsModels;
using System;
using System.Diagnostics;
using System.Linq;

namespace Land_Manager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILand _lands;
        private readonly ICustomer _customers;
        private readonly IPayment _payments;

        public HomeController(ILand properties, ICustomer customers, IPayment payments)
        {
            _lands = properties;
            _customers = customers;
            _payments = payments;
        }

        public IActionResult Index()
        {
            int month = DateTime.Now.Month;
            HomeViewModel model = new HomeViewModel
            {
                LandCount = _lands.GetNumberOfLands(),
                CustomerCount = _customers.GetNumberOfCustomers(),
                RentCollectedThisMonth = _payments.GetAmountFromMonth(month),
                PaymentsThisMonth = _payments.GetAllFromMonth(month).Select(p => new PaymentItemModel()
                {
                    CustomerId = p.Customer.Id,
                    CustomerName = p.Customer.FullName,
                    Cost = p.Cost,
                    Date = p.Date.ToString("dd/MM/yyyy")
                })
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
