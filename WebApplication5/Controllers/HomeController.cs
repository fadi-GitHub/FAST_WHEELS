using WebApplication5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication5.Controllers
{

    //class createPost{
    //    public
    //    String CarName;
    //    String CarMake;
    //    String Color;
    //    String mobileno;
    //    int Model;
    //    String RegistrationNo;
    //    String CarType;
    //    String OwnerCNIC;
    //    String Location;
    //    String CarPrice;
    //    String Description;

    //    createPost(String CarName,String CarMake, String Color,String mobileno, int Model, String RegistrationNo, String CarType,String OwnerCNIC, String Location,String CarPrice, String Description)
    //    {

    //    }

    //};

    public class HomeController : Controller
    {
        class User
        {
            public static String CNIC="";
            public static String Email="";
            public static String Password="";
        }


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult signIN(String email, String password)
        {
            CRUD.LoginQueryInfo UserInfo = CRUD.signIN(email, password);
            if (UserInfo.Status == 1)
            {
                User.CNIC = UserInfo.CNIC;
                User.Email = UserInfo.Email;
                User.Password = UserInfo.Password;
                String data = "User exist";
                return View("index", (object)data);

            }
            else if (UserInfo.Status == 0)
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

        public ActionResult createPost()
        {
            return View();
        }
        public ActionResult creatingPost()
        {
            //int result = CRUD.creatingPost(CarName,CarMake,Color, mobileno,Model,RegistrationNo,CarType,OwnerCNIC,Location,CarPrice,Description);
            int result = CRUD.creatingPost("AudiR8", "Audi","Black", "0333-4595785",2020, "Lel=5561", "2400cc", "10101-4678367-9", "California", "50000000", "10/10 Genyoan");
            if (result == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("index", (object)data);
            }
            else if (result == 0)
            {

                String data = "Car Already Exists";
                return View("index", (object)data);
            }

            String data1 = "Post Created";
            return RedirectToAction("createPost");
        }

        public ActionResult UsedCar()
        {
            return View();
        }
        
        public ActionResult buyUsedCar(String UserEmail,String CarRegNo)
        {
            int result = CRUD.buyUsedCar("arslan111@gmail.comf", "GYZ-7512");
            if (result == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("UsedCar", (object)data);
            }
            else if (result == 0)
            {

                String data = "Car Cannot be bought";
                return View("index", (object)data);
            }
            String data1 = "Car Bought";
            return View("UsedCar",(object)data1);
        }


    }
}