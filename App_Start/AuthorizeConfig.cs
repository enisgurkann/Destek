using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Destek.App_Start
{
    public class AuthorizeConfig : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            PreCore core = new PreCore();
            bool? status = core.CariLoginDurumu() as bool?;
            if (status == null || status == false)
                filterContext.Result = new RedirectResult("~/Login");
        }
    }
}