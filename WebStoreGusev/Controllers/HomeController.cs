using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStoreGusev.Models;

namespace WebStoreGusev.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<EmployeeViewModel> employees;

        public HomeController()
        {
            employees = new List<EmployeeViewModel>
            {
                new EmployeeViewModel
                {
                    Id = 1,
                    FirstName = "Иван",
                    SurName = "Иванов",
                    Patronymic = "Иванович",
                    Age = 22,
                    Position = "Начальник"
                },

                new EmployeeViewModel
                {
                    Id = 2,
                    FirstName = "Петр",
                    SurName = "Петров",
                    Patronymic = "Петрович",
                    Age = 35,
                    Position = "Программист"
                }
            };
        }

        public IActionResult Index()
        {
            return View(employees);
        }

        public IActionResult Details(int id)
        {
            return View(employees.FirstOrDefault(x => x.Id == id));
        }
    }
}