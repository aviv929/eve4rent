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
    class Advertisment
    {
        static string cs = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName + @"\Database1.mdf;";

        public static int add(string username,string date, string name, string type, string recieve, string from, string to, int cancle, string policy)
        {
            SqlConnection con;
            SqlCommand cmd;

            string qry = "insert into Advertisments (username, [date],name,[type],recieve,[from],[to],cancle,[policy]) values('" + username + "','" + date + "','" + name + "','" + type + "','" + recieve + "','" + from + "','" + to + "',"+cancle+",'" + policy + "');";
            con = new SqlConnection(cs);

            con.Open();
            cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();


            qry = "select advertismentID from Advertisments where username='"+username+"' AND [date]='"+date+ "' AND name='"+name+"' AND [type]='"+type+ "' AND recieve='"+recieve+ "' AND [from]='"+from+ "' AND [to]='"+to+ "' AND cancle="+cancle+ " AND [policy]='"+policy+"';";

            cmd = new SqlCommand(qry, con);
            SqlDataReader dataReader = cmd.ExecuteReader();

            int ans = 0;
            if (dataReader.HasRows)
            {
                dataReader.Read();
                ans=(int)dataReader.GetValue(0);               
            }

            dataReader.Close();
            cmd.Dispose();
            con.Close();

            return ans;
        }


    }
}
