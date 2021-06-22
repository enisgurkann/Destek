using Destek.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Destek.Controllers
{
    public class AdminCanliDestekController : Controller
    {
        // GET: AdminCanliDestek
             [AdminAuth]
        public ActionResult Index()
        {
            ViewBag.IFrameSrc = "https://dashboard.zopim.com/";
            return View();
        }
    }
}