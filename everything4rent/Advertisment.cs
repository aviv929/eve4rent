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
    class Advertisment
    {
        static string cs = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName + @"\Database1.mdf;";

        public static int add(string username,string date, string name, string type, int recieve , string orecieve, string from, string to, int cancle, string policy)
        {
            SqlConnection con;
            SqlCommand cmd;

            string qry = "insert into Advertisments (username, [date],name,[type],recieve,orecieve,[from],[to],cancle,[policy]) values('" + username + "','" + date + "','" + name + "','" + type + "',"+ recieve + ",'" + orecieve + "','" + from + "','" + to + "',"+cancle+",'" + policy + "');";
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

        public static void delete(int advID)
        {

            SqlConnection con;
            SqlCommand cmd;

            string qry = "DELETE FROM Products WHERE advertismentID="+advID+";";
            con = new SqlConnection(cs);

            con.Open();
            cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();


            qry = "DELETE FROM Advertisments WHERE advertismentID=" + advID + ";";
            cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            con.Close();

        }
        public static string getUsername(int advID)
        {
            string ans = "";
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dataReader;

            string qry = "select username FROM Advertisments WHERE advertismentID=" + advID + ";";
            con = new SqlConnection(cs);

            con.Open();
            cmd = new SqlCommand(qry, con);
            dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    ans = (string)dataReader.GetValue(0);
                }
            }

            dataReader.Close();

            cmd.Dispose();
            con.Close();

            return ans;
        }
        public static string validation(string name, string title , string recieve,string orecieve, string from, string to)
        {
            string errors = "";
            if (name.Length ==0)
                errors += "You have to insert name\n";


            try{Convert.ToDouble(recieve);}
            catch (Exception){errors += "Price must be a number\n";}
            


            try
            {
                DateTime d1 = Convert.ToDateTime(from);
                DateTime d2 = Convert.ToDateTime(to);
                if (d1.CompareTo(d2) >= 0)
                    errors += "Start date is later that end date\n";
                if (d1.CompareTo(DateTime.Now)<0)
                    errors += "Date must be in the future\n";

            }
            catch (Exception)
            {
                errors += "Invalid date\n";
            }


            return errors;
        }

        public static void allAdv(ListView list,string username)
        {
            list.Items.Clear();
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dataReader;
            string qry = "select advertismentID,date ,name,type,recieve,orecieve from Advertisments where username='" + username+"';";
            con = new SqlConnection(cs);

            con.Open();
            cmd = new SqlCommand(qry, con);
            dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    ListViewItem l = new ListViewItem((string)dataReader.GetValue(2));
                    l.SubItems.Add((string)dataReader.GetValue(1));
                    l.SubItems.Add((string)dataReader.GetValue(3));
                    l.SubItems.Add(""+(int)dataReader.GetValue(4)+" , "+ (string)dataReader.GetValue(5));
                    l.SubItems.Add(""+(int)dataReader.GetValue(0));
                    list.Items.Add(l);
                }
            }

            dataReader.Close();
            cmd.Dispose();
            con.Close();

            
        }

        public static List<string> getAdv(int advID)
        {
            List<string> ans= new List<string>();
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dataReader;
            string qry = "select date ,name,[type],recieve, [from],[to],cancle,[policy],orecieve from Advertisments where advertismentID=" + advID + ";";
            con = new SqlConnection(cs);

            con.Open();
            cmd = new SqlCommand(qry, con);
            dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    ans.Add((string)dataReader.GetValue(0));
                    ans.Add((string)dataReader.GetValue(1));
                    ans.Add((string)dataReader.GetValue(2));
                    ans.Add(""+(int)dataReader.GetValue(3));
                    ans.Add((string)dataReader.GetValue(4));
                    ans.Add((string)dataReader.GetValue(5));
                    ans.Add("" + (int)dataReader.GetValue(6));
                    ans.Add((string)dataReader.GetValue(7));
                    ans.Add((string)dataReader.GetValue(8));
                }
            }

            dataReader.Close();
            cmd.Dispose();
            con.Close();

            return ans;
        }

        public static void update(int advID, string date, string name, string type, int recieve, string orecieve, string from, string to, int cancle, string policy)
        {
            SqlConnection con;
            SqlCommand cmd;

            string qry = "update  Advertisments set [date]='"+date+"',name='"+name+"',[type]='"+ type+ "', recieve="+ recieve + ", orecieve='" + orecieve + "',[from]='"+ from+"',[to]='"+to+"',cancle="+ cancle+",[policy]='"+ policy+ "' where advertismentID="+advID+";";
            con = new SqlConnection(cs);

            con.Open();
            cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            con.Close();
        }




        public static List<string> searchAll(List<string> val)
        {
            DateTime d = new DateTime(2000, 5, 7);
            string qry = "select * from Products join Advertisments on Products.advertismentID= Advertisments.advertismentID left join Orders on Advertisments.advertismentID = Orders.advertismentID where (Orders.status is NULL or Orders.status != 'Confirmed') AND ";

            if (val[4]!="none")
                qry += " Advertisments.type='" + val[4] + "' AND ";//type
            qry += " Products.title='" + val[15] + "' AND ";//title
            qry += " Products.subtitle='" + val[17] + "' AND ";//subtitle

            qry = qry.Substring(0, qry.Length - 4);
            qry += "ORDER BY Advertisments.date DESC;";

            //query
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dataReader;
            con = new SqlConnection(cs);

            con.Open();
            cmd = new SqlCommand(qry, con);
            dataReader = cmd.ExecuteReader();

            List<string> first = new List<string>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    first.Add(""+(int)dataReader.GetValue(0));//pid
                    first.Add("" + (int)dataReader.GetValue(1));//aid
                    first.Add((string)dataReader.GetValue(2));//pname
                    first.Add((string)dataReader.GetValue(3));//title
                    first.Add((string)dataReader.GetValue(4));//sub
                    first.Add(((string)dataReader.GetValue(5)).Split('^')[0]);//info1
                    first.Add(((string)dataReader.GetValue(5)).Split('^')[1]);//info2
                    first.Add(((string)dataReader.GetValue(5)).Split('^')[2]);//info3
                    first.Add(((string)dataReader.GetValue(5)).Split('^')[3]);//info4
                    first.Add(((string)dataReader.GetValue(5)).Split('^')[4]);//info5
                    //first.Add((Image)dataReader.GetValue(6));//pic
                    //first.Add((string)dataReader.GetValue(7));//aid
                    first.Add((string)dataReader.GetValue(8));//user
                    first.Add((string)dataReader.GetValue(9));//date
                    first.Add((string)dataReader.GetValue(10));//aname
                    first.Add((string)dataReader.GetValue(11));//type
                    first.Add(""+(int)dataReader.GetValue(12));//recieve
                    first.Add((string)dataReader.GetValue(13));//from
                    first.Add((string)dataReader.GetValue(14));//to
                    first.Add(""+(int)dataReader.GetValue(15));//cancle
                    first.Add((string)dataReader.GetValue(16));//policy
                    first.Add((string)dataReader.GetValue(17));//orecieve
                }
            }
            dataReader.Close();
            cmd.Dispose();
            con.Close();


            List<string> ans = new List<string>();
            bool flag = true;
            for (int i = 0; i < first.Count(); i=i+20)
            {
                flag = true;

                    if (Convert.ToDateTime(first[i+15]).CompareTo(Convert.ToDateTime(val[1])) > 0)//date
                        flag = false;
                    if (Convert.ToDateTime(first[i+16]).CompareTo(Convert.ToDateTime(val[2])) < 0)//date
                        flag = false;
                
                if ((val[8] != "0"|| val[9] != "0") && val[4] == "Lending")//price
                {
                    if (Convert.ToInt32(val[8]) > Convert.ToInt32(first[i+14]) || Convert.ToInt32(val[9]) < Convert.ToInt32(first[i+14]))
                        flag = false;
                }
                if (val[19] != "" && first[i+5].Contains(val[19]) == false)//field1
                    flag = false;
                if (val[21] != "" && first[i+6].Contains(val[21]) == false)//field2
                    flag = false;
                if (val[23] != "" && first[i+7].Contains(val[23]) == false)//field3
                    flag = false;
                if (val[25] != "" && first[i+8].Contains(val[25]) == false)//field4
                    flag = false;
                if (val[27] != "" && first[i+9].Contains(val[27]) == false)//field5
                    flag = false;

                if (flag)               
                    for (int j = i; j < i+20; j++)                  
                        ans.Add(first[j]);
            }


            return ans;
        }

        public static string searchValidation(List<string> val)
        {
            string ans = "";


                try
                {
                    DateTime d1 = Convert.ToDateTime(val[1]);
                    DateTime d2 = Convert.ToDateTime(val[2]);
                    if(d1.CompareTo(d2)>0)
                        ans += "ilegal range of dates\n";
                }
                catch (Exception){ans += "Wrong format of date\n";}
            

                try
                {
                    int d1 = Convert.ToInt32(val[8]);
                    int d2 = Convert.ToInt32(val[9]);
                    if (d1.CompareTo(d2) > 0)
                        ans += "ilegal range of price\n";
                }
                catch (Exception) { ans += "Wrong format of date\n"; }
            

            return ans;
        }
    }
}
