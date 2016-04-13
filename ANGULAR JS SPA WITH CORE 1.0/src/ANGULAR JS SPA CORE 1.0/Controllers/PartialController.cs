using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ANGULAR_JS_SPA_CORE_Controllers
{
    public class PartialController : Controller
    {
        // GET: /<controller>/
        public IActionResult Message() => PartialView();

        public IActionResult Numbers() => PartialView();
    }
}
