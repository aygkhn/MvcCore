using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstCoreMvc.Entities;
using FirstCoreMvc.Views;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2(string key)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee{Id=1,CityId=63,FirstName="Ahmet",LastName="KARA"},
                new Employee{Id=1,CityId=63,FirstName="Hasan",LastName="BEYAZ"},
                new Employee{Id=1,CityId=63,FirstName="Derin",LastName="YAYLA"}
            };
            List<City> cities = new List<City> { new City { CityId = 1, CityName = "Urfa" }, new City { CityId = 35, CityName = "Izmir" } };

            EmployeeListViewModel empList = new EmployeeListViewModel {
                Employees = employees,
                Cities=cities
            };

            if(String.IsNullOrEmpty(key))
            {
                return Json(employees);
            }
            var result = employees.Where(e=>e.FirstName.ToLower().Contains(key));
            return Json(result);
        }
        public ViewResult EmployeeForm()
        {
            return View();
        }
        public string RouteData(int id)
        {
            return id.ToString();
        }
    }
}