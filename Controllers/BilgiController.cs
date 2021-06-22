using Destek.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Destek.Controllers
{
    public class BilgiController : Controller
    {
        // GET: Bilgi
         [AuthorizeConfig]
        public ActionResult Index()
        {
            return View();
        }
    }
}