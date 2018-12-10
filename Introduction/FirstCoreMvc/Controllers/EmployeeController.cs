using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstCoreMvc.Controllers.Model;
using FirstCoreMvc.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstCoreMvc.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Add()
        {
            var employeeAddViewModel = new EmployeeAddViewModel
            {
                Employee = new Employee(),
                Cities = new List<SelectListItem>
                {
                    new SelectListItem{Text="Şanlıurfa",Value="63" },
                    new SelectListItem{Text="Izmir",Value="35" }
                }

            };
            return View(employeeAddViewModel);
        }
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            return View();
        }
    }
}