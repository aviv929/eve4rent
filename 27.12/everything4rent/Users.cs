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
    {
        static string cs= @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename="+Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName+@"\Database1.mdf;";
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

            string qry = "INSERT INTO Users (username, [password], email,name,lastname,birthdate,picture,paypal) VALUES('"+username+ "', '"+password+ "', '"+email+ "', '"+name+ "', '"+lastname+ "', '"+birthdate+ "',NULL, '"+paypal+"'); ";
            con = new SqlConnection(cs);

            con.Open();
            cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();

            if (image!=null)
            {
                //update Users set name='abc' where username='a'
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
                errors +="username must be at least 4 characters\n";
            else if (char.IsLetter(username[0]) == false)
                errors += "username must start letter\n";
            else if (isExist(username) == true)
                errors += "username "+ username + " is already exist\n";

            if (password.Length < 8)
                errors += "password must be at least 8 characters\n";

            if (email.Contains("@")==false)
                errors += "email must contain @\n";
            else if (email.Contains(".")==false)
                errors += "email must contain .\n";

            if (name.Length<3)
                errors += "name should be longer than 2 characters\n";

            if (lastname.Length < 3)
                errors += "lastname should be longer than 2 characters\n";

            if (birthdate.Length != 10)
                errors += birthdate.Length+"the format of the birthday is dd/mm/yyyy\n";

            //image

            if (paypal.Contains("@") == false)
                errors += "paypal must contain @\n";
            else if (paypal.Contains(".")==false)
                errors += "paypal must contain .\n";

            return errors;
        }
    }
}
