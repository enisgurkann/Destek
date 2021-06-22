using Destek.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Destek.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: AdminHome
             [AdminAuth]
        public ActionResult Index()
        {
            return View();
        }
    }
}