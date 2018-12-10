using FirstCoreMvc.Entities;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCoreMvc.TagHelpers
{
    [HtmlTargetElement("employee-list")]
    public class EmployeeListTagHelper:TagHelper
    {
        private List<Employee> _employees;
        public EmployeeListTagHelper()
        {
            _employees = new List<Employee>
            {
                new Employee{Id=1,CityId=63,FirstName="Ahmet",LastName="KARA"},
                new Employee{Id=2,CityId=63,FirstName="Hasan",LastName="BEYAZ"},
                new Employee{Id=3,CityId=63,FirstName="Derin",LastName="YAYLA"}
            };
        }
        private const string ListCountAttributeName = "count";
        [HtmlAttributeName(ListCountAttributeName)]
        public int ListCount { get; set; }
        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            StringBuilder sb = new StringBuilder();
            var query = _employees.Take(ListCount);
            foreach (var item in query)
            {
                sb.AppendFormat("<h2><a href='/employee/detail/{0}'>{1}</a></h2>",item.Id,item.FirstName);
            }
            output.Content.SetHtmlContent(sb.ToString());

            base.Process(context, output);
        }
    }
}
