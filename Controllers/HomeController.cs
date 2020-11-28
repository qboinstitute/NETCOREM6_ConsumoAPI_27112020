using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ERP.BusinessObject;
using ERP.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NETCOREM6_ConsumoAPI.Models;

namespace NETCOREM6_ConsumoAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

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

        public async Task<IActionResult> Employees()
        {
            ViewBag.Listado = await EmployeeService.Listado();
            return View();
        }

        public async Task<IActionResult> Insertar(EmployeeBO employee)
        {
            EmployeeBO employeeDB = await EmployeeService.Insertar(employee);
            return RedirectToAction("Employees");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
