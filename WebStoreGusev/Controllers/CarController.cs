using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStoreGusev.Models;

namespace WebStoreGusev.Controllers
{
    public class CarController : Controller
    {
        private readonly List<CarViewModel> cars;

        public CarController()
        {
            cars = new List<CarViewModel>
            {
                new CarViewModel
                {
                    Id = 100010,
                    Company = "Porshe",
                    Model = "911 Carrera",
                    Color = "Красный",
                    Price = 10_000_000
                },

                new CarViewModel
                {
                    Id = 200010,
                    Company = "BMW",
                    Model = "Z4 Roadster",
                    Color = "Синий",
                    Price = 4_500_000
                }
            };
        }

        public IActionResult Index()
        {
            return View(cars);
        }

        public IActionResult Buy(int id)
        {
            return View(cars.FirstOrDefault(x => x.Id == id));
        }
    }
}