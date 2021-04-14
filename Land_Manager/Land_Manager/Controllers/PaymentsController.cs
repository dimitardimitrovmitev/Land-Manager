using Data;
using Microsoft.AspNetCore.Mvc;
using Land_Manager.Models.PaymentsModels;
using System.Linq;

namespace Land_Manager.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly IPayment _payments;
        private readonly ICustomer _customers;

        public PaymentsController(IPayment payments, ICustomer customers)
        {
            _payments = payments;
            _customers = customers;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult All()
        {
            PaymentListModel model = new PaymentListModel()
            {
                Payments = _payments.GetAll().Select(c => new PaymentItemModel()
                {
                    CustomerId = c.Customer.Id,
                    CustomerName = c.Customer.FullName,
                    Cost = c.Amount,
                    Date = c.Date.ToString("dd/MM/yyyy")
                })
            };

            return View(model);
        }

        public IActionResult Customer(int id)
        {
            if (!_customers.HasPayments(id))
            {
                return RedirectToAction("All");
            }

            PaymentsFromCustomerListModel model = new PaymentsFromCustomerListModel()
            {
                Payments = _payments.GetAllFromCustomer(id).Select(t => new PaymentItemModel()
                {
                    CustomerId = t.Customer.Id,
                    CustomerName = t.Customer.FullName,
                    Cost = t.Amount,
                    Date = t.Date.ToString("dd/MM/yyyy")
                }),
                CustomerId = id,
                CustomerName = _customers.Get(id).FullName
            };

            return View(model);
        }
    }
}
