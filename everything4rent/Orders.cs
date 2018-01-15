using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace everything4rent
{
    class Orders
    {
        static string cs = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName + @"\Database1.mdf;";

        public static void add(int advID,string username,string status,string description)
        {
            SqlConnection con;
            SqlCommand cmd;

            string date = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            string qry = "insert into Orders (advertismentID,username, [date],status,description) values(" + advID + ",'" + username + "','" + date + "','"+status+"','" + description + "');";
            con = new SqlConnection(cs);

            con.Open();
            cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();


            cmd.Dispose();
            con.Close();
        }

    }
}
