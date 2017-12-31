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
    class Products
    {
        static string cs = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName + @"\Database1.mdf;";

        public static void add(int advID, string name, string title, string subtitle, string info, Image image)
        {
            SqlConnection con;
            SqlCommand cmd;

            string qry = "INSERT INTO Products (advertismentID, name, title,subtitle,info,picture) VALUES('" + advID + "', '" + name + "', '" + title + "', '" + subtitle + "', '" + info + "',NULL); ";
            con = new SqlConnection(cs);

            con.Open();
            cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();

            if (image != null)
            {
                //update Users set name='abc' where username='a'
            }

            cmd.Dispose();
            con.Close();
        }
        public static string validation(string name,int title ,int subltitle, Image image)
        {
            string errors = "";
            if (name.Length == 0)
                errors += "you have to insert name\n";

            if (title==-1)
                errors += "you must choose title\n";

            if (subltitle == -1)
                errors += "you must choose subltitle\n";

            return errors;
        }



        public static List<string> getTitles()
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dataReader;
            string qry = "select title from Titles;";
            con = new SqlConnection(cs);

            con.Open();
            cmd = new SqlCommand(qry, con);
            dataReader = cmd.ExecuteReader();//cmd.ExecuteNonQuery;

            List<string> l = new List<string>();
            if (dataReader.HasRows)
            {
                while(dataReader.Read())
                l.Add( (string)dataReader.GetValue(0) );
            }

            dataReader.Close();
            cmd.Dispose();
            con.Close();

            return l;
        }
        public static List<string> getfields(string title)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dataReader;
            string qry = "select field1,field2,field3,field4,field5 from Titles where title='"+title+"';";
            con = new SqlConnection(cs);

            con.Open();
            cmd = new SqlCommand(qry, con);
            dataReader = cmd.ExecuteReader();//cmd.ExecuteNonQuery;

            List<string> l = new List<string>();
            if (dataReader.HasRows)
            {
                dataReader.Read();
                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        l.Add((string)dataReader.GetValue(i));
                    }
                    catch (Exception)
                    {
                        l.Add("");
                    }
                }

            }

            dataReader.Close();
            cmd.Dispose();
            con.Close();

            return l;
        }
        public static List<string> getSubtitles(string title)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dataReader;
            string qry = "select subtitles from Subtitles where title='"+ title + "';";
            con = new SqlConnection(cs);

            con.Open();
            cmd = new SqlCommand(qry, con);
            dataReader = cmd.ExecuteReader();//cmd.ExecuteNonQuery;

            List<string> l = new List<string>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                    l.Add((string)dataReader.GetValue(0));
            }

            dataReader.Close();
            cmd.Dispose();
            con.Close();

            return l;
        }
    }
}
