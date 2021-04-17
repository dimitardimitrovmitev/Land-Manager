using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Land_Manager.Models.LandModels;
using Land_Manager.Models.CustomerModels;
using System.Linq;

namespace Land_Manager.Controllers
{
    public class LandController : Controller
    {
        private readonly ILand _lands;
        private readonly ICustomer _customers;

        public LandController(ILand lands, ICustomer customers)
        {
            _lands = lands;
            _customers = customers;
        }

        public IActionResult Index(int id)
        {
            Land land = _lands.Get(id);

            LandIndexModel model = new LandIndexModel()
            {
                Id = land.Id,
                Address = land.Address,
                Area = land.Area,
                Rent = land.Rent,
                Customers = _customers.GetAllFromLand(id).Select(t => new CustomerItemModel() 
                {
                    Id = t.Id,
                    FullName = t.FullName,
                    Address = t.RentedLand.Address,
                    Email = t.Email,
                    PhoneNumber = t.PhoneNumber,
                    DateOfRenting = t.DateOfRenting.ToString("dd/MM/yyyy")
                })
            };

            return View(model);
        }

        public IActionResult All()
        {
            LandListModel model = new LandListModel()
            {
                Lands = _lands.GetAll().Select(p => new LandItemModel
                {
                    Id = p.Id,
                    Address = p.Address,
                    NumberOfCustomers = _customers.GetAllFromLand(p.Id).Count()                
                })
            };

            return View(model);
        }

        public IActionResult Add()
        {
            Land model = new Land()
            {
                Area = 100,
                Rent = 100
            };       

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            Land model = _lands.Get(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Land land)
        {
            if (ModelState.IsValid) 
            { 
                _lands.Update(land);

                return RedirectToAction("Index", new { id = land.Id });
            }

            return View(land);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Land model)
        {
            if (ModelState.IsValid)
            {
                _lands.Add(model);

                return RedirectToAction("All", "Land");
            }

            return View(model);
        }
    }
}
