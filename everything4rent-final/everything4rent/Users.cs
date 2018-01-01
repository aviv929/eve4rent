using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

namespace everything4rent
{
    class Users
    {//Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aviv9_000\Desktop\everything4rent\everything4rent\Database1.mdf;Integrated Security=True
        static string cs= @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename="+Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName+ @"\Database1.mdf;Integrated Security=True";
        public static bool login(string username,string password)
        {
            bool ans = false;

            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dataReader;
            //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aviv9_000\Desktop\everything4rent\everything4rent\Database1.mdf;Integrated Security=True
            string qry = "select [password] from Users where username= '"+ username + "';";
            con = new SqlConnection(cs);

            con.Open();
            cmd = new SqlCommand(qry, con);
            dataReader = cmd.ExecuteReader();//cmd.ExecuteNonQuery;

            ans = dataReader.HasRows;

            if (ans)
            {
                dataReader.Read();
                string pass = (string)dataReader.GetValue(0);
                if (pass==password)
                    ans= true;
                else
                    ans = false;
            }
            else
            {
                return false;
            }
            
            dataReader.Close();
            cmd.Dispose();
            con.Close();

            return ans;
        }
        public static void add(string username, string password, string email, string name, string lastname, string birthdate,Image image, string paypal)
        {
            SqlConnection con;
            SqlCommand cmd;

            string qry = "INSERT INTO Users (username, [password], email,name,lastname,birthdate,picture,paypal) VALUES('"+username+ "', '"+password+ "', '"+email+ "', '"+name+ "', '"+lastname+ "', '"+birthdate+ "','"+@image+"', '"+paypal+"'); ";
            con = new SqlConnection(cs);

            con.Open();
            cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();


            if (image!=null)
            {
                cmd.Parameters.Add("@photo", image);
            }

            cmd.Dispose();
            con.Close();
        }


        public static bool isExist(string username)
            {
            bool ans = false;

            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dataReader;
            //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aviv9_000\Desktop\everything4rent\everything4rent\Database1.mdf;Integrated Security=True
            string qry = "select * from Users where username= '" + username + "';";
            con = new SqlConnection(cs);

            con.Open();
            cmd = new SqlCommand(qry, con);
            dataReader = cmd.ExecuteReader();//cmd.ExecuteNonQuery;

            if (dataReader.HasRows)
                ans = true;

            dataReader.Close();
            cmd.Dispose();
            con.Close();

            return ans;
        }
        public static string validation(string username, string password, string email, string name, string lastname, string birthdate, Image image, string paypal)
        {
            string errors = "";
            if (username.Length<4)
                errors +="Username must be at least 4 characters\n";
            else if (char.IsLetter(username[0]) == false)
                errors += "Username must start letter\n";
            else if (isExist(username) == true)
                errors += "Username "+ username + " is already exist\n";

            if (password.Length < 8)
                errors += "Password must be at least 8 characters\n";

            try
            {
                System.Net.Mail.MailAddress m = new System.Net.Mail.MailAddress(email);
                if (m.Address!=email)
                {
                    errors += "Invalid email \n";
                }
            }
            catch (Exception)
            {
                errors += "Invalid email \n";
            }


            if (name.Length<3)
                errors += "Name should be longer than 2 characters\n";

            if (lastname.Length < 3)
                errors += "Lastname should be longer than 2 characters\n";

            try
            {
                DateTime d = Convert.ToDateTime(birthdate);
                if (d.CompareTo(DateTime.Now)>=0)
                    errors += "Invalid birth date\n";
         
            }
            catch (Exception)
            {
                errors += "Invalid birth date\n";
            }

            //image

            try
            {
                System.Net.Mail.MailAddress m = new System.Net.Mail.MailAddress(email);
                if (m.Address != email)
                {
                    errors += "Invalid paypal account \n";
                }
            }
            catch (Exception)
            {
                errors += "Invalid paypal account \n";
            }

            return errors;
        }
    }
}
