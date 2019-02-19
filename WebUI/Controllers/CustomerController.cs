using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/
        public ActionResult Form()
        {
            return View();
        }

        public string Email(string firstName, string lastName, DateTime date, int phoneNum,
                            string message)
        {
            string temp = "";

            //To be done - email handling


            return temp;
        }
	}
}