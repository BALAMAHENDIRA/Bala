using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCCOREAPP1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MVCCOREAPP1.Models;
using Microsoft.EntityFrameworkCore;

namespace MVCCOREAPP1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        NextTurnDBContext _myContext = new NextTurnDBContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult DispEmployees()
        {   
            List<Employee> list = _myContext.Employees.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<Department> list = _myContext.Departments.ToList();
            list.Insert(0, new Department { DeptId = 0, DeptName = "--Select Department--" });
            ViewBag.message = list;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            _myContext.Employees.Add(emp);
            _myContext.SaveChanges();
            return RedirectToAction("DispEmployees");
        }


        [HttpGet]
        public IActionResult Edit(int EmpId)
        {
            Employee emp = _myContext.Employees.Where(x => x.EmpId == EmpId).SingleOrDefault();
            List<Department> list = _myContext.Departments.ToList();
            list.Insert(0, new Department { DeptId = 0, DeptName = "--Select Department--" });
            ViewBag.message = list;
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            _myContext.Entry(emp).State = EntityState.Modified;
            _myContext.SaveChanges();
            return RedirectToAction("DispEmployees");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
