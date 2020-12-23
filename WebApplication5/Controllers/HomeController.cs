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
        public ActionResult aboutUs()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult profile()
        {
            ViewData["userPassword"] = User.Password;
            ViewData["boughtList"] = TempData["boughtList"];
            ViewData["soldList"] = TempData["soldList"];
            ViewData["userDetails"] = TempData["userDetails"];
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
        
        public ActionResult buyUsedCar(String CarRegNo)
        {
            if (User.Email == "")
            {
                String data = "Please Login first";
                return View("index", (object)data);
            }
            int result = CRUD.buyUsedCar(User.Email, CarRegNo);
            if (result == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("Homepage", (object)data);
            }
            else if (result == 0)
            {

                String data = "Car Cannot be bought";
                return View("index", (object)data);
            }
            return RedirectToAction("getAllUsedCars");
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
            if (TempData["newCarsList"] != null)
                ViewData["newCarsList"] = TempData["newCarsList"];

            return View();
        }
        public ActionResult getAllNewCars()
        {
            List<newCars> newCarList = CRUD.getAllNewCar();
            TempData["newCarsList"] = newCarList;
            return RedirectToAction("newCars");
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
            TempData["newCarsList"] = newCarsList;

            return RedirectToAction("newCars");
        }

        public ActionResult postanAdd()
        {
            if (User.Email == "")
            {
                String data = "Please Login first";
                return View("index", (object)data);
            }
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
            if (User.Email == "")
            {
                String data = "Please Login first";
                return View("index", (object)data);
            }
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
            
            return RedirectToAction("getAllAutoParts");
        }


        ////// Dealer Methods /////////
        public ActionResult getAllDealers()
        {
            List<Dealers> dealersList = CRUD.getAllDealers();
            TempData["dealersList"] = dealersList;
            return RedirectToAction("Dealers");
        }

        //Profile //
        public ActionResult updatePassword(String oldPassword, String newPassword)
        {

            int result = CRUD.updatePassword(oldPassword, newPassword, User.CNIC);
            Userdetails obj = CRUD.getUserDetails(User.CNIC);
            List<carRecords> BoughtList = CRUD.getBoughtdetails(User.CNIC);
            List<carRecords> SoldList = CRUD.getsolddetails(User.CNIC);
            TempData["boughtList"] = BoughtList;
            TempData["soldList"] = SoldList;
            TempData["userDetails"] = obj;
            return RedirectToAction("profile");
        }
        public ActionResult getUserdetails()
        {
            Userdetails obj = CRUD.getUserDetails(User.CNIC);
            List<carRecords> BoughtList = CRUD.getBoughtdetails(User.CNIC);
            List<carRecords> SoldList = CRUD.getsolddetails(User.CNIC);
            TempData["boughtList"] = BoughtList;
            TempData["soldList"] = SoldList;
            TempData["userDetails"] = obj;
            return RedirectToAction("profile");
        }
    }
}