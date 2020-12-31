using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRegistration.Models;
using EmployeeRegistration.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRegistration.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployee();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        
        public IActionResult Create(Employee  employee)
        {
            _employeeRepository.AddEmployee(employee);
           
            ViewBag.message = "The employee " + employee.FirstName + " is saved successfully";
            return View();
        }
        [AllowAnonymous]
        public ViewResult Details(int? id)
        {

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(id ?? 1),
                PageTitle = "Employee Detasil"

            };
            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public IActionResult Edit()
        {

            return View();
        }
    }
}