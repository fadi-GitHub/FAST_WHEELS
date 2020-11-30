using WebApplication5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult signIN(String email,String password)
        {
            int result = CRUD.signIN(email,password);
            if (result == 1)
            {
                String data = "User exist";
                return View("index", (object)data);

            }
            else if (result == 0)
            {

                String data = "User doesnot exist";
                return View("index", (object)data);
            }
            String data2 = "Something went wrong while connecting with the database.";
            return View("index", (object)data2);



        }
        public ActionResult signUP()
        {
            return View();
        }
        public ActionResult sup(String firstname, String lastname, String cnic, String email, String password)
        {
            int result = CRUD.sup(firstname, lastname, cnic, email, password);
            if (result == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("index", (object)data);
            }
            else if (result == 0)
            {

                String data = "Invalid Credentials";
                return View("index", (object)data);
            }

            String data1 = "User Registered";
            return RedirectToAction("Index");

        }

    }
}