using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreMvc.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        [Route("")]
        [Route("save")]
        [Route("~/save")]
        public string Save()
        {
            return "Saved";
        }
        [Route("List/{id?}")]
        public string List(int id=0)
        {
            return String.Format("Listed {0}",id);
        }
        [Route("Delete")]
        public string Delete()
        {
            return "Deleted";
        }
    }
}