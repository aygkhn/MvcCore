using FirstCoreMvc.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FirstCoreMvc.Controllers.Model
{
    public class EmployeeAddViewModel
    {
        public Employee Employee { get; set; }
        public List<SelectListItem> Cities { get; set; }
    }
}