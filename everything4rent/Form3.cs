using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace everything4rent
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                int aid = Convert.ToInt32(Form1.data[Form1.requestid * 20 + 1]);
                username_request_lbl.Text = "Username: " + Advertisment.getUsername(aid);
                rank_request_lbl.Text = "Owner Rank: 1";
                rank2_request_lbl.Text = "Package Rank: 5";

                pID = Products.itemsPerAdv(aid);
                for (int i = 0; i < pID.Count; i++)
                    if (pID[i] == Convert.ToInt32(Form1.data[Form1.requestid * 20]))
                        index = i;
                bringAdv(sender, e);
            }
            catch (Exception)
            {
                this.Close();
            }  
            
        }
        List<int> pID = new List<int>();
        int index = 0;
        public void bringAdv(object sender, EventArgs e)
        {
            int aid = Convert.ToInt32(Form1.data[Form1.requestid * 20 + 1]);
            List<string> adv = Advertisment.getAdv(aid);
            Aname_request_lbl.Text = "Name: " + adv[1];
            date_request_lbl.Text = "Date: " + adv[4] + "  -  " + adv[5];
            type_request_lbl.Text = "Type: " + adv[2];
            if (adv[6] == "1")
                cancle_request_lbl.Text = "Allow canceling: yes";
            else
                cancle_request_lbl.Text = "Allow canceling: no";

            if (adv[2] == "Lending")
                recieve_request_lbl.Text = "Price: " + adv[3];
            else if (adv[2] == "Donation")
                recieve_request_lbl.Text = "Deposit: " + adv[3];
            else
                recieve_request_lbl.Text = "addional price: " + adv[3] + "\n" + "exchange for: " + adv[8];


            pID = Products.itemsPerAdv(aid);
            bringProduct(sender, e);
        }

        private void send_request_pnl4_btn_Click(object sender, EventArgs e)
        {
            
            int aid = Convert.ToInt32(Form1.data[Form1.requestid * 20 + 1]);
            if (Advertisment.getUsername(aid)=="")//adv not exist
            {
                MessageBox.Show("This advertisment was already taken");
                return;
            }
            if (Form1.logged)
            {
                if (Form1.data[Form1.requestid * 20 + 18] == "First in first serve")
                {
                    Orders.add(aid, Form1.username, "Confirmed", message_request_txt.Text);
                    //Advertisment.delete(aid);
                }
                else
                {
                    Orders.add(aid, Form1.username, "Waiting", message_request_txt.Text);
                }
                MessageBox.Show("Your request was sent");
            }
            else
                MessageBox.Show("Please log in first");
            this.Close();
        }

        public void bringProduct(object sender, EventArgs e)
        { 

            List<string> item = Products.getProduct(pID[index]);
            Pname_request_lbl.Text = "Name: " + item[0];
            title_request_lbl.Text = "Title: " + item[1];

            subtitle_request_lbl.Text = "Subtitle: " + item[2];


            string[] values = item[3].Split('^');
            List<string> sub = Products.getfields(item[1]);

            field1_request_lbl.Text = values[0];
            if (sub.Count > 0 && field1_request_lbl.Text != "")
                field1_request_lbl.Text = sub[0] + ": " + field1_request_lbl.Text;
            field2_request_lbl.Text = values[1];
            if (sub.Count > 1 && field2_request_lbl.Text != "")
                field2_request_lbl.Text = sub[1] + ": " + field2_request_lbl.Text;
            field3_request_lbl.Text = values[2];
            if (sub.Count > 2 && field3_request_lbl.Text != "")
                field3_request_lbl.Text = sub[2] + ": " + field3_request_lbl.Text;
            field4_request_lbl.Text = values[3];
            if (sub.Count > 3 && field4_request_lbl.Text != "")
                field5_request_lbl.Text = sub[3] + ": " + field5_request_lbl.Text;
            field5_request_lbl.Text = values[4];
            if (sub.Count > 4 && field5_request_lbl.Text != "")
                field5_request_lbl.Text = sub[4] + ": " + field5_request_lbl.Text;

        }

        private void next_request_btn_Click(object sender, EventArgs e)
        {
            index = (index + 1) % pID.Count;
            bringProduct(sender, e);
        }
        private void prev_request_btn_Click(object sender, EventArgs e)
        {
            index = (index + pID.Count - 1) % pID.Count;
            bringProduct(sender, e);
        }

    }
}
