using DeliveryWebApp.DataAccess;
using DeliveryWebApp.Models;
using DomainModels.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Utils;

namespace DeliveryWebApp.Controllers
{
    public class ArrivalDateController : Controller
    {
        private readonly ShipDBContext _dbContext;

        public ArrivalDateController(ShipDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            EstimatedArrivalDate? estArrivDate = _dbContext.EstimatedArrivalDate.FirstOrDefault(x => x.Id == id);

            if (estArrivDate == null)
            {
                return RedirectToAction("Index", "Home");
            }

            int numSpaces = StringFunctions.CountPrecedingSpaces(estArrivDate.FirstName);
            numSpaces += StringFunctions.CountTrailingSpaces(estArrivDate.FirstName);
            numSpaces += StringFunctions.CountPrecedingSpaces(estArrivDate.LastName);
            numSpaces += StringFunctions.CountTrailingSpaces(estArrivDate.LastName);

            ArrivalDateViewModel arrivalDateViewModel = new();
            arrivalDateViewModel.FullName = "[Full Name]";
            arrivalDateViewModel.NumberOfSpaces = numSpaces;
            arrivalDateViewModel.EstimatedArrivalDate = estArrivDate.EstimatedArrival_Date.ToString("MM-dd-yyyy");

            return View(arrivalDateViewModel);
        }
    }
}