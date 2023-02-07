using DeliveryWebApp.DataAccess;
using DeliveryWebApp.Models;
using DomainModels.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
using Utils;

namespace DeliveryWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShipDBContext _dbContext;

        public HomeController(ShipDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(HomeViewModel model)
        {
            DateTime orderDate;
            if (!DateTime.TryParseExact(model.OrderDate, "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out orderDate))
            {
                ModelState.AddModelError("OrderDate", "The date that you have provided is either incorrect or is not in the correct format MM-DD-YYYY");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            EstimatedArrivalDate estArrivDate = new();
            estArrivDate.FirstName = model.FirstName;
            estArrivDate.LastName = model.LastName;
            estArrivDate.EstimatedArrival_Date = DateFunctions.AddBusinessDays(orderDate, model.DaysToShip);

            _dbContext.EstimatedArrivalDate.Add(estArrivDate);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "ArrivalDate", new { id = estArrivDate.Id });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}