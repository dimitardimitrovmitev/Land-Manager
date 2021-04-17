using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Land_Manager.Models.CustomerModels;
using System;
using System.Linq;

namespace Land_Manager.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILand _lands;
        private readonly ICustomer _customers;
        private readonly IPayment _payments;

        public CustomerController(ILand lands, ICustomer customers, IPayment payments)
        {
            _lands = lands;
            _customers = customers;
            _payments = payments;
        }

        public IActionResult Index(int id)
        {
            Customer customer = _customers.Get(id);

            if (customer != null)
            {
                CustomerIndexModel model = new CustomerIndexModel()
                {
                    CustomerId = customer.Id,
                    CustomerName = customer.FullName,
                    CustomerAddress = customer.RentedLand.Address,
                    DateOfRenting = customer.DateOfRenting.Date.ToString("dd/MM/yyyy"),
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                    MoneyOwed = _customers.GetMoneyOwed(customer.Id)
                };

                return View(model);
            }

            return RedirectToAction("All");
        }

        public IActionResult All()
        {
            CustomerListModel model = new CustomerListModel()
            {
                Customers = _customers.GetAll().Select(t => new CustomerItemModel()
                {
                    Id = t.Id,
                    FullName = t.FullName,
                    Address = t.RentedLand.Address,
                    Email = t.Email,
                    PhoneNumber = t.PhoneNumber,
                    DateOfRenting = t.DateOfRenting.ToString("dd/MM/yyyy"),
                    Debt = _customers.GetMoneyOwed(t.Id)

                })
            };

            return View(model);
        }

        public IActionResult Add()
        {
            Customer customer = new Customer()
            {
                DateOfRenting = DateTime.Now
            };

            AddCustomerModel model = new AddCustomerModel()
            {
                Customer = customer,
                Lands = _lands.GetAll()
            };

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            Customer customer = _customers.Get(id);

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer model)
        {
            if (ModelState.IsValid)
            {
                if (model.Email != _customers.Get(model.Id).Email && _customers.IsEmailTaken(model.Email))
                {
                    ModelState.AddModelError("Customer.Email", "This email is already taken.");
                    return View(model);
                }

                _customers.Update(model);

                return RedirectToAction("Index", new { id = model.Id });
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(AddCustomerModel model)
        {
            
            model.Lands = _lands.GetAll();

            if (ModelState.IsValid)
            {
                if (_customers.IsEmailTaken(model.Customer.Email))
                {
                    ModelState.AddModelError("Customer.Email", "This email is already taken.");
                    return View(model);
                }

                if (model.Customer.DateOfRenting > DateTime.Now)
                {
                    ModelState.AddModelError("Customer.DateOfMovingIn", "Date cannot be in the future.");
                    return View(model);
                }

                Customer newCustomer = new Customer()
                {
                    FirstName = model.Customer.FirstName,
                    LastName = model.Customer.LastName,
                    Email = model.Customer.Email,
                    PhoneNumber = model.Customer.PhoneNumber,
                    DateOfRenting = model.Customer.DateOfRenting
                };

                _customers.Add(newCustomer, model.RentedLandId);

                return RedirectToAction("All");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult PayRent(int id)
        {
            Payment payment = new Payment()
            {
                Customer = _customers.Get(id),
                Cost = _customers.GetMoneyOwed(id),
                Date = DateTime.Now
            };

            _payments.Add(payment);

            return RedirectToAction("Index", new { id = id });
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            _customers.Cancel(id);

            return RedirectToAction("All");
        }
    }
}
