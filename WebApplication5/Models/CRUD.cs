using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApplication5.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using System.Data.SqlClient;
    using System.Data.Sql;
    using System.Data;
    public class CRUD
    {

        public static string connectionString = "data source=localhost; Initial Catalog=fast_wheels;Integrated Security=true";
        public static int sup(string signin_firstname_bt, string signin_lastname_bt, string signin_cnic_bt, string signin_mail_bt, string signin_pass_bt)   //updated 27
        {
            
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result;
            try
            {
                cmd = new SqlCommand("signup", con); //for running procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@firstname", SqlDbType.VarChar, 15).Value = signin_firstname_bt;
                cmd.Parameters.Add("@lastname", SqlDbType.VarChar, 15).Value = signin_lastname_bt;
                cmd.Parameters.Add("@cnic", SqlDbType.VarChar, 15).Value = signin_cnic_bt;
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 40).Value = signin_mail_bt;
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 15).Value = signin_pass_bt;

                //SqlDataReader rdr = cmd.ExecuteReader();
                cmd.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                result = Convert.ToInt32(cmd.Parameters["@status"].Value);
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }

        public struct LoginQueryInfo
        {
            public String CNIC;
            public String Email;
            public String Password;
            public int Status;
        };

        public static LoginQueryInfo signIN(String email, String password)   //updated 27
        {
            LoginQueryInfo UserInfo = new LoginQueryInfo();
            UserInfo.CNIC = "xyz";
            UserInfo.Email = "xyz";
            UserInfo.Password = "xyz";
            UserInfo.Status=0;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result;
            try
            {
                cmd = new SqlCommand("login", con); //for running procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 40).Value = email;
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 15).Value = password;

                //SqlDataReader rdr = cmd.ExecuteReader();
               // cmd.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;
                //SqlDataReader rdr = cmd.ExecuteReader();

                SqlDataReader rdr = cmd.ExecuteReader();
                //UserInfo.Status = Convert.ToInt32(cmd.Parameters["@status"].Value);
                
                    while (rdr.Read())
                    {
                        UserInfo.CNIC = rdr["CNIC"].ToString();
                        UserInfo.Email = rdr["Email"].ToString();
                        UserInfo.Password = rdr["Password"].ToString();
                    }
                   if(UserInfo.CNIC!="xyz")
                   {
                       UserInfo.Status = 1;
                   }
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                UserInfo.Status = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return UserInfo;
        }

        public static int creatingPost(String fileName,String Path,String CarName, String CarMake, String Color, String mobileno, int Model, String RegistrationNo, String CarType, String OwnerCNIC, String Location, String CarPrice, String Description)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result;
            try
            {
                cmd = new SqlCommand("CreatePost", con); //for running procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@imageName", SqlDbType.VarChar, 50).Value = fileName;
                cmd.Parameters.Add("@imagePath", SqlDbType.VarChar, 100).Value = Path;
                cmd.Parameters.Add("@CarName", SqlDbType.VarChar, 30).Value = CarName;
                cmd.Parameters.Add("@CarMake", SqlDbType.VarChar, 30).Value = CarMake;
                cmd.Parameters.Add("@Color", SqlDbType.VarChar, 20).Value = Color;
                cmd.Parameters.Add("@mobileno", SqlDbType.VarChar, 12).Value = mobileno;
                cmd.Parameters.Add("@Model", SqlDbType.Int).Value = Model;
                cmd.Parameters.Add("@RegistrationNo", SqlDbType.VarChar, 10).Value = RegistrationNo;
                cmd.Parameters.Add("@CarType", SqlDbType.VarChar, 30).Value = CarType;
                cmd.Parameters.Add("@OwnerCNIC", SqlDbType.VarChar, 15).Value = OwnerCNIC;
                cmd.Parameters.Add("@Location", SqlDbType.VarChar, 30).Value = Location;
                cmd.Parameters.Add("@CarPrice", SqlDbType.VarChar, 30).Value = CarPrice;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar, 200).Value = Description;

                //SqlDataReader rdr = cmd.ExecuteReader();
                cmd.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                result = Convert.ToInt32(cmd.Parameters["@status"].Value);
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;


        }

        public static int buyUsedCar(String Email,String RegNo)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result;
            try
            {
                cmd = new SqlCommand("BuyAndSell", con); //for running procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@buyerEmail", SqlDbType.VarChar, 40).Value = Email;
                cmd.Parameters.Add("@licenceNo", SqlDbType.VarChar, 10).Value = RegNo;
                
                //SqlDataReader rdr = cmd.ExecuteReader();
                cmd.Parameters.Add("@Flag", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                result = Convert.ToInt32(cmd.Parameters["@Flag"].Value);
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static List<usedCars> getAllUsedCar()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            List<usedCars> usedCarsList = new List<usedCars>();
            try
            {
                cmd = new SqlCommand("search_all_usedCars", con); //for running procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    usedCars carObj = new usedCars();
                    carObj.imageName = rdr["images"].ToString();
                    carObj.CarMake = rdr["CarMake"].ToString();
                    carObj.CarName = rdr["CarName"].ToString();
                    carObj.Color = rdr["Color"].ToString();
                    carObj.mobileno = rdr["mobileno"].ToString();
                    carObj.Location = rdr["Location"].ToString();
                    carObj.Model = Convert.ToInt32(rdr["Model"].ToString());
                    carObj.Description = rdr["Description"].ToString();
                    carObj.CarPrice = rdr["CarPrice"].ToString();
                    carObj.CarType = rdr["CarType"].ToString();
                    carObj.OwnerCNIC = rdr["OwnerCNIC"].ToString();
                    carObj.RegistrationNo = rdr["RegistrationNo"].ToString();
                    usedCarsList.Add(carObj);
                }

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return usedCarsList;

        }

        

        public static List<usedCars> searchUsedCar(String make, int model, String Location, String minRange, String maxRange)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            List<usedCars> usedCarsList = new List<usedCars>();
            try
            {
                cmd = new SqlCommand("search_used_cars", con); //for running procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@CarMake", SqlDbType.VarChar, 30).Value = make;
                cmd.Parameters.Add("@Model", SqlDbType.Int).Value =model;
                cmd.Parameters.Add("@Location", SqlDbType.VarChar, 30).Value = Location;
                cmd.Parameters.Add("@Min_range", SqlDbType.VarChar,30).Value = minRange;
                cmd.Parameters.Add("@Max_range", SqlDbType.VarChar,30).Value = maxRange;

                SqlDataReader rdr = cmd.ExecuteReader();
                

                while (rdr.Read())
                {
                    usedCars carObj=new usedCars();
                    carObj.imageName = rdr["images"].ToString();
                    carObj.CarMake = rdr["CarMake"].ToString();
                    carObj.CarName = rdr["CarName"].ToString();
                    carObj.Color = rdr["Color"].ToString();
                    carObj.mobileno = rdr["mobileno"].ToString();
                    carObj.Location = rdr["Location"].ToString();
                    carObj.Model = Convert.ToInt32(rdr["Model"].ToString());
                    carObj.Description = rdr["Description"].ToString();
                    carObj.CarPrice= rdr["CarPrice"].ToString();
                    carObj.CarType = rdr["CarType"].ToString();
                    carObj.OwnerCNIC = rdr["OwnerCNIC"].ToString();
                    carObj.RegistrationNo = rdr["RegistrationNo"].ToString();
                    usedCarsList.Add(carObj);
                }

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return usedCarsList;

        }
        ///////////////////////////////////
        public static List<newCars> getAllNewCar()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            List<newCars> newCarsList = new List<newCars>();
            try
            {
                cmd = new SqlCommand("search_allnew_cars", con); //for running procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    newCars carObj = new newCars();
                    carObj.image = rdr["images"].ToString();
                    carObj.CarMake = rdr["Make"].ToString();
                    carObj.CarName = rdr["CarName"].ToString();
                    carObj.Color = rdr["Color"].ToString();
                    carObj.Model = Convert.ToInt32(rdr["Model"].ToString());
                    carObj.Description = rdr["Description"].ToString();
                    carObj.CarPrice = rdr["Price"].ToString();
                    carObj.CarType = rdr["CarType"].ToString();
                    carObj.Status = rdr["Status"].ToString();
                    newCarsList.Add(carObj);
                }

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return newCarsList;

        }
        public static List<newCars> searchNewCars(String make, int model, String minRange, String maxRange)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            List<newCars> newCarsList = new List<newCars>();
            try
            {
                cmd = new SqlCommand("search_new_cars", con); //for running procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@CarMake", SqlDbType.VarChar, 30).Value = make;
                cmd.Parameters.Add("@Model", SqlDbType.Int).Value = model;
                cmd.Parameters.Add("@Min_range", SqlDbType.VarChar, 30).Value = minRange;
                cmd.Parameters.Add("@Max_range", SqlDbType.VarChar, 30).Value = maxRange;

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    newCars carObj = new newCars();
                    carObj.image = rdr["images"].ToString();
                    carObj.CarMake = rdr["Make"].ToString();
                    carObj.CarName = rdr["CarName"].ToString();
                    carObj.Color = rdr["Color"].ToString();
                    carObj.Model = Convert.ToInt32(rdr["Model"].ToString());
                    carObj.Description = rdr["Description"].ToString();
                    carObj.CarPrice = rdr["Price"].ToString();
                    carObj.CarType = rdr["CarType"].ToString();
                    carObj.Status = rdr["Status"].ToString();
                    newCarsList.Add(carObj);
                }

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return newCarsList;

        }

        ////// Auto Partss Methods ////////////
        public static List<autopart> searchAutoPart(String carMake, String carName, String itemName) 
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            List<autopart> autopartList = new List<autopart>();
            try
            {
                cmd = new SqlCommand("search_autoparts", con); //for running procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@CarMake", SqlDbType.VarChar, 20).Value = carMake;
                cmd.Parameters.Add("@CarName", SqlDbType.VarChar,20).Value = carName;
                cmd.Parameters.Add("@ItemName", SqlDbType.VarChar, 20).Value = itemName;

                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    autopart partObj = new autopart();
                    partObj.imageName = rdr["images"].ToString();
                    partObj.carMake = rdr["car_Make"].ToString();
                    partObj.carName = rdr["car_Name"].ToString();
                    partObj.itemName = rdr["item_Name"].ToString();
                    partObj.Color = rdr["Color"].ToString();

                    partObj.price = Convert.ToInt32(rdr["Price"].ToString());
                    partObj.quantity = Convert.ToInt32(rdr["Quantity"].ToString());
                 
                    autopartList.Add(partObj);
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return autopartList;
        }

        public static List<autopart> getAllAutoParts()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            List<autopart> autopartList = new List<autopart>();
            try
            {
                cmd = new SqlCommand("getall_autoparts", con); //for running procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    autopart partObj = new autopart();
                    partObj.imageName = rdr["images"].ToString();
                    partObj.carMake = rdr["car_Make"].ToString();
                    partObj.carName = rdr["car_Name"].ToString();
                    partObj.itemName = rdr["item_Name"].ToString();
                    partObj.Color= rdr["Color"].ToString();
                    partObj.price = Convert.ToInt32(rdr["Price"].ToString());
                    partObj.quantity = Convert.ToInt32(rdr["Quantity"].ToString());

                    autopartList.Add(partObj);
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return autopartList;
        }

        public static List<Dealers> getAllDealers()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            List<Dealers> dealersList = new List<Dealers>();
            try
            {
                cmd = new SqlCommand("getall_dealers", con); //for running procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    Dealers dObj = new Dealers();
                    dObj.Name = rdr["Name"].ToString();
                    dObj.PhoneNo = rdr["PhoneNo"].ToString();
                    dObj.City = rdr["City"].ToString();
                    dObj.Address = rdr["Address"].ToString();
                    dObj.ImageName = rdr["Images"].ToString();
                    dealersList.Add(dObj);
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return dealersList;
        }

        public static int buyAutoPart(String carMake, String carName, String itemName, String Color)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result;

            try
            {
                cmd = new SqlCommand("buy_autoparts", con); //for running procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@CarMake", SqlDbType.VarChar, 20).Value = carMake;
                cmd.Parameters.Add("@CarName", SqlDbType.VarChar, 20).Value = carName;
                cmd.Parameters.Add("@ItemName", SqlDbType.VarChar, 20).Value = itemName;
                cmd.Parameters.Add("@Color", SqlDbType.VarChar, 10).Value = Color;


                //SqlDataReader rdr = cmd.ExecuteReader();
                cmd.Parameters.Add("@Flag", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                result = Convert.ToInt32(cmd.Parameters["@Flag"].Value);
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }

            return result;
        }

        ////// Profile functions /////////
        public static int updatePassword(String oldpassword, String newpassword,String cnic) {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result;
            try
            {
                cmd = new SqlCommand("update_password", con); //for running procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@cnic", SqlDbType.VarChar, 15).Value = cnic;
                cmd.Parameters.Add("@currentpassword", SqlDbType.VarChar, 15).Value = oldpassword;
                cmd.Parameters.Add("@newpassword", SqlDbType.VarChar, 15).Value = newpassword;
                cmd.Parameters.Add("@Flag", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                result = Convert.ToInt32(cmd.Parameters["@Flag"].Value);
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }

            return result;
        }

        public static Userdetails getUserDetails(String cnic)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            Userdetails obj =new Userdetails();

            try
            {
                cmd = new SqlCommand("getall_userdetails", con); //for running procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@cnic", SqlDbType.VarChar, 15).Value = cnic;

                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    obj.firstName = rdr["FirstName"].ToString();
                    obj.lastName = rdr["LastName"].ToString();
                    obj.cnic = rdr["CNIC"].ToString();
                    obj.email = rdr["Email"].ToString();
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return obj;
        }

        public static List<carRecords> getBoughtdetails(String cnic)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            List<carRecords> boughtlist = new List<carRecords>();

            try
            {
                cmd = new SqlCommand("getall_boughtdetails", con); //for running procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@cnic", SqlDbType.VarChar, 15).Value = cnic;

                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    carRecords obj = new carRecords();
                    obj.carRegNo = rdr["RegNo"].ToString();
                    obj.carMake = rdr["CarMake"].ToString();
                    obj.carName = rdr["CarName"].ToString();
                    obj.carModel = rdr["Model"].ToString();
                    obj.carType= rdr["CarType"].ToString();
                    obj.carColor= rdr["Color"].ToString();
                    obj.carPrice= rdr["CarPrice"].ToString();
                    boughtlist.Add(obj);
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return boughtlist;
        }

        public static List<carRecords> getsolddetails(String cnic)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            List<carRecords> soldlist = new List<carRecords>();

            try
            {
                cmd = new SqlCommand("getall_solddetails", con); //for running procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@cnic", SqlDbType.VarChar, 15).Value = cnic;

                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    carRecords obj = new carRecords();
                    obj.carRegNo = rdr["RegNo"].ToString();
                    obj.carMake = rdr["CarMake"].ToString();
                    obj.carName = rdr["CarName"].ToString();
                    obj.carModel = rdr["Model"].ToString();
                    obj.carType = rdr["CarType"].ToString();
                    obj.carColor = rdr["Color"].ToString();
                    obj.carPrice = rdr["CarPrice"].ToString();
                    soldlist.Add(obj);
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return soldlist;
        }
    }
    
}
//hello just checking 