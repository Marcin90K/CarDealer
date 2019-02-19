using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Rules()
        {
            return View();
        }


        public ActionResult Contact()
        {
            return View();
        }


	}
}