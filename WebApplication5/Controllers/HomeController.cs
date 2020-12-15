using WebApplication5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Linq;

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

        public ActionResult HomePage()
        {
            return View();
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
                return View("HomePage");

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
       public struct cla1
        {
           public String filename;
            public String Path;
        };


        public ActionResult creatingPost(HttpPostedFileBase img, String CarName, String CarMake, String Color, String mobileno, String Model,  String RegistrationNo, String CarType, String OwnerCNIC, String Location, String CarPrice, String Description)
        {
            int model =Convert.ToInt32(Model);
            String fileName = "";
            String path = "";
            if (img.ContentLength <= 0 || img == null)
                TempData["temp"] = "Error while uploading";
            else
            {
                fileName = Path.GetFileName(img.FileName);
                path = Path.Combine(Server.MapPath("~/usedCarImages"), fileName);
                img.SaveAs(path);
                // TempData["temp"] = "Successfuly uploaded";
                //TempData["picname"] = fileName;
            }
            int result = CRUD.creatingPost(fileName,path,CarName,CarMake,Color, mobileno,model,RegistrationNo,CarType,OwnerCNIC,Location,CarPrice,Description);
            //int result = CRUD.creatingPost("AudiR8", "Audi","Black", "0333-4595785",2020, "Lel=5561", "2400cc", "10101-4678367-9", "California", "50000000", "10/10 Genyoan");
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
            return RedirectToAction("postanAdd");
        }
        

        public ActionResult UsedCar()
        {
            if(TempData["usedCarsList"]!=null)
            ViewData["usedCarsList"] = TempData["usedCarsList"];
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

        public ActionResult searchUsedCars(String make,String model,String Location,String range)
        {
            int Model = Convert.ToInt32(model);
            String minRange = "";
            String maxRange = "";
            if(range== "upto 1,000,000")
            {
                minRange = "0";
                maxRange = "1000000";
            }
            else if (range == "1,000,001 to 2,000,000") 
            {
                minRange = "1000001";
                maxRange = "2000000";
            }
            else if (range == "2,000,001 to 4,000,000")
            {
                minRange = "2000001";
                maxRange = "4000000";
            }
            if (range == "4,000,001 to 8,000,000")
            {
                minRange = "4000001";
                maxRange = "8000000";
            }
            if (range == ">8,000,000")
            {
                minRange = "8000001";
                maxRange = "200000000";
            }
            List<usedCars> usedCarsList = CRUD.searchUsedCar(make,Model,Location,minRange,maxRange);
            TempData["usedCarsList"] = usedCarsList;
            return RedirectToAction("UsedCar");
        }

        public ActionResult getAllUsedCars()
        {
            List<usedCars> usedCarsList = CRUD.getAllUsedCar();
            TempData["usedCarsList"] = usedCarsList;
            return RedirectToAction("UsedCar");
        }

         public ActionResult newCars()
         {
            return View();
         }
         
        public ActionResult searchNewCars(String make, int model, String range)
        {
            String minRange = "";
            String maxRange = "";
            if (range == "upto 1,000,000")
            {
                minRange = "0";
                maxRange = "1000000";
            }
            else if (range == "1,000,001 to 2,000,000")
            {
                minRange = "1000001";
                maxRange = "2000000";
            }
            else if (range == "2,000,001 to 4,000,000")
            {
                minRange = "2000001";
                maxRange = "4000000";
            }
            if (range == "4,000,001 to 8,000,000")
            {
                minRange = "4000001";
                maxRange = "8000000";
            }
            if (range == ">8,000,000")
            {
                minRange = "8000001";
                maxRange = "200000000";
            }
            List<newCars> newCarsList = CRUD.searchNewCars(make, model, minRange, maxRange);
            ViewData["newCarsList"] = newCarsList;

            return View("newCars");
        }

        public ActionResult postanAdd()
        {
            return View();
        }

        public ActionResult Dealers()
        {
            if (TempData["dealersList"] != null)
                ViewData["dealersList"] = TempData["dealersList"];
            return View();
        }

        public ActionResult Autostore()
        {
            if (TempData["autopartList"] != null)
                ViewData["autopartList"] = TempData["autopartList"];
            return View();
        }



        public ActionResult searchAutoPart(String carMake,String carName,String itemName) 
        {
            List<autopart> autopartList = CRUD.searchAutoPart(carMake,carName,itemName);
            TempData["autopartList"] = autopartList;

            return RedirectToAction("Autostore");
        }

        public ActionResult getAllAutoParts()
        {
            List<autopart> autopartList = CRUD.getAllAutoParts();
            TempData["autopartList"] = autopartList;
            return RedirectToAction("Autostore");
        }
        public ActionResult buyAutoPart(String carMake, String carName, String itemName, String Color)
        {
            int result = CRUD.buyAutoPart(carMake, carName, itemName, Color);
            if (result == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("Autostore", (object)data);
            }
            else if (result == 0)
            {

                String data = "Auto Part Cannot be bought";
                return View("Autostore", (object)data);
            }
            String data1 = "AutoPart Bought";
            return View("Autostore", (object)data1);
        }


        ////// Dealer Methods /////////
        public ActionResult getAllDealers()
        {
            List<Dealers> dealersList = CRUD.getAllDealers();
            TempData["dealersList"] = dealersList;
            return RedirectToAction("Dealers");
        }
    }
}