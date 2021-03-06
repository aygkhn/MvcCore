﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstCoreMvc.Entities;
using FirstCoreMvc.ExtensionMethods;
using FirstCoreMvc.Services;
using FirstCoreMvc.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreMvc.Controllers
{
    public class HomeController : Controller
    {

        private ICalculator _calculator;
        public HomeController(ICalculator calculator)
        {
            _calculator = calculator;
        }
        public string Index()
        {
            if (HttpContext.Session!=null)
            {
                return HttpContext.Session.GetObject().ToString();
            }
            return "";
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
        public string Calculate()
        {
            return _calculator.Calculate(100).ToString();
        }
    }
}