using Data;
using Microsoft.AspNetCore.Mvc;
using Land_Manager.Models;
using System;

namespace Land_Manager.Controllers
{
    public class RentCollectedController : Controller
    {
        private readonly IPayment _payments;

        public RentCollectedController(IPayment payments)
        {
            _payments = payments;
        }

        public IActionResult Index()
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            RentCollectedIndexModel model = new RentCollectedIndexModel()
            {
                MonthlyProfits = _payments.GetAmountFromMonth(month),
                YearlyProfits = _payments.GetAmountFromYear(year),
                AllTimeProfits = _payments.GetAmountFromAllTime()
            };

            return View(model);
        }
    }
}
