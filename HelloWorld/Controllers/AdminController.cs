using DotNetNuke.Web.Mvc.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockY.Dnn.HelloWorld.Controllers
{
    public class AdminController : DnnController
    {
        // GET: Admin
        public ActionResult Open()
        {
            return View("Admin");
        }
    }
}