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
    class Searches
    {
        static string cs = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName + @"\Database1.mdf;";

        public static void add(string username,List<string> val)
        {
            SqlConnection con;
            SqlCommand cmd;

            string date = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            int cancle = 0;
            if (val[6] == "True")
                cancle=1;
            string qry = "insert into Searches (username,[date],[from],[to],[type],cancle,minprice,maxprice,[policy],name,title,subtitle) values('" + username + "','" + date + "','" + val[1] + "','" + val[2] + "','" + val[4] + "'," + cancle + "," + val[8] + "," + val[9] + ",'" + val[11] + "','" + val[13] + "','"  + val[15] + "','" + val[17] + "'); ";
            con = new SqlConnection(cs);

            con.Open();
            cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();


            cmd.Dispose();
            con.Close();
;
        }

    }
}
