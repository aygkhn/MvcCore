using System.Collections.Generic;
using FirstCoreMvc.Entities;

namespace FirstCoreMvc.Views
{
    public class EmployeeListViewModel
    {
        public List<Employee> Employees { get;  set; }
        public List<City> Cities { get;  set; }
    }
}