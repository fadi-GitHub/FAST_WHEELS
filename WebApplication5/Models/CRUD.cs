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
        public static string connectionString = "data source=localhost; Initial Catalog=Project;Integrated Security=true";
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
        public static int signIN(String email, String password)   //updated 27
        {

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

    }
}
//hello just checking 