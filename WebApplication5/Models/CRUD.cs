﻿using System;
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
                cout << "Helllo";
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
                //cmd.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataReader rdr = cmd.ExecuteReader();
                
                   // cmd.ExecuteNonQuery();
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

        public static int creatingPost(String CarName, String CarMake, String Color, String mobileno, int Model, String RegistrationNo, String CarType, String OwnerCNIC, String Location, String CarPrice, String Description)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result;
            try
            {
                cmd = new SqlCommand("CreatePost", con); //for running procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
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
    }
}
//hello just checking 