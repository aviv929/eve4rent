using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Net;
using System.Net.Mail;

namespace everything4rent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }




        ///////////////////////panel1
        static bool logged = false;
        string username = "";
        private void login_btn_Click(object sender, EventArgs e)
        {
            if (user_txt.Text == "")
            {
                MessageBox.Show("empty username");
                return;
            }
            if (pass_txt.Text == "")
            {
                MessageBox.Show("empty password");
                return;
            }
            logged = Users.login(user_txt.Text, pass_txt.Text);
            if (logged)
            {
                username = user_txt.Text;
                welcome_bar_lbl.Text = "welcome: "+username;
                panel2_pnl.Visible = true;
                panel1_pnl.Visible = false;

                user_txt.Text = "";
                pass_txt.Text = "";
            }
            else
                MessageBox.Show("wrong usernemae or password");

            
            //move to main form
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 f = new Form2();
           
            f.Show();
            
        }


        ///////////////////////panel2
        private void log_off_bar_btn_Click(object sender, EventArgs e)
        {
            logged = false;
            username = "";
            panel2_pnl.Visible = false;
            panel1_pnl.Visible = true;

          

            panel5_pnl.Visible = false;
            panel3_pnl.Visible = true;
            panel4_pnl.Visible = false;
        }
        private void create_adv_bar_btn_Click(object sender, EventArgs e)
        {
            aID = -1;
            Aupdate_pnl4_btn.Visible = false;
            Pupdate_pnl4_btn.Visible = false;
            next_update_btn.Visible = false; 
            prev_update_btn.Visible = false;

           

            panel3_pnl.Visible = false;
            panel4_pnl.Visible = true;
            panel5_pnl.Visible = false;

            List<string> l= Products.getTitles();
            title_create_pnl4_ddl.Items.Clear();
            for (int i = 0; i < l.Count; i++)
                title_create_pnl4_ddl.Items.Add(l[i]);
            type_create_pnl4_ddl.SelectedIndex = 0;
            items = new List<string>();

            clearAdv();
            clearProduct();
            mini_pnl.Visible = false;
        }
        private void my_adv_bar_btn_Click(object sender, EventArgs e)
        {
            panel5_pnl.Visible = true;
            panel3_pnl.Visible = false;
            panel4_pnl.Visible = false;

            Advertisment.allAdv(list_my_pnl5_lv, username);
        }



        ///////////////////////panel3

        ///////////////////////panel4
        List<string> items;
        private void title_create_pnl4_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            mini_pnl.Visible = true;

            List<string> l=Products.getSubtitles( title_create_pnl4_ddl.Items[title_create_pnl4_ddl.SelectedIndex].ToString() );
            subtitle_create_pnl4_ddl.Items.Clear();
            subtitle_create_pnl4_ddl.Text = "";
            for (int i = 0; i < l.Count; i++)
                subtitle_create_pnl4_ddl.Items.Add(l[i]);

            l = Products.getfields(title_create_pnl4_ddl.Items[title_create_pnl4_ddl.SelectedIndex].ToString());
            Label[] lbl = { field1_create_pnl4_lbl, field2_create_pnl4_lbl, field3_create_pnl4_lbl, field4_create_pnl4_lbl, field5_create_pnl4_lbl };
            TextBox[] txt= { field1_create_pnl4_txt,field2_create_pnl4_txt,field3_create_pnl4_txt,field4_create_pnl4_txt,field5_create_pnl4_txt};
            for (int i = 0; i < 5; i++)
            {
                lbl[i].Visible = true;
                txt[i].Visible = true;
                if (l[i] != "")
                    lbl[i].Text = l[i];
                else
                {
                    lbl[i].Visible = false;
                    txt[i].Visible = false;
                }
            }
            
        }
        private void type_create_pnl4_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (type_create_pnl4_ddl.Items[type_create_pnl4_ddl.SelectedIndex].ToString()=="Lending")
                recieve_create_pnl4_lbl.Text = "Price";
            else if (type_create_pnl4_ddl.Items[type_create_pnl4_ddl.SelectedIndex].ToString() == "Donation")
                recieve_create_pnl4_lbl.Text = "Deposit";
            else if (type_create_pnl4_ddl.Items[type_create_pnl4_ddl.SelectedIndex].ToString() == "Trading")
                recieve_create_pnl4_lbl.Text = "Items";
        }
        private void picture_create_pnl4_txt_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
        private void addP_create_pnl4_btn_Click(object sender, EventArgs e)
        {
            

            string valid = Products.validation(Pname_create_pnl4_txt.Text, title_create_pnl4_ddl.SelectedIndex, subtitle_create_pnl4_ddl.SelectedIndex, null);
            if (valid != "")
            {
                MessageBox.Show(valid);
                return;
            }
            items.Add(Pname_create_pnl4_txt.Text);
            items.Add(title_create_pnl4_ddl.Items[title_create_pnl4_ddl.SelectedIndex].ToString());
            items.Add(subtitle_create_pnl4_ddl.Items[subtitle_create_pnl4_ddl.SelectedIndex].ToString());
            items.Add(field1_create_pnl4_txt.Text + "^" + field2_create_pnl4_txt.Text + "^" + field3_create_pnl4_txt.Text + "^" + field4_create_pnl4_txt.Text + "^" + field5_create_pnl4_txt.Text);

            clearProduct();
            mini_pnl.Visible = false;
        }
        private void add_create_pnl4_btn_Click(object sender, EventArgs e)
        {
            //validation
            string valid = Advertisment.validation(Aname_create_pnl4_txt.Text, type_create_pnl4_ddl.Items[type_create_pnl4_ddl.SelectedIndex].ToString(), recieve_create_pnl4_txt.Text, from_create_pnl4_txt.Text, to_create_pnl4_txt.Text);          
            if (valid != "")
            {
                MessageBox.Show(valid);
                return;
            }
            if (items.Count==0)
            {
                MessageBox.Show("must add at least 1 item");
                return;
            }


            int allow = 0;
            if (allow_create_pnl4_chk.Checked)
                 allow = 1;
            int advNum= Advertisment.add(username, DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year, Aname_create_pnl4_txt.Text, type_create_pnl4_ddl.Items[type_create_pnl4_ddl.SelectedIndex].ToString(), recieve_create_pnl4_txt.Text , from_create_pnl4_txt.Text, to_create_pnl4_txt.Text, allow, policy_create_pnl4_ddl.Items[policy_create_pnl4_ddl.SelectedIndex].ToString());
            for (int i = 0; i < items.Count; i=i+4)
            {
                Products.add(advNum, items[i], items[i+1], items[i+2], items[i+3], null);
            }
            items.Clear();
            MessageBox.Show("success");

            clearAdv();
        }

        private void clearAdv()
        {
            //clear
            Aname_create_pnl4_txt.Text = "";
            from_create_pnl4_txt.Text = "dd/mm/yyyy";        
            recieve_create_pnl4_txt.Text = "";
            to_create_pnl4_txt.Text = "dd/mm/yyyy";
            type_create_pnl4_ddl.SelectedIndex = 0;
            policy_create_pnl4_ddl.SelectedIndex = 0;
        }
        public void clearProduct()
        {
            field1_create_pnl4_lbl.Text = "field1";
            field2_create_pnl4_lbl.Text = "field2";
            field3_create_pnl4_lbl.Text = "field3";
            field4_create_pnl4_lbl.Text = "field4";
            field5_create_pnl4_lbl.Text = "field5";
            field1_create_pnl4_txt.Text = "";
            field2_create_pnl4_txt.Text = "";
            field3_create_pnl4_txt.Text = "";
            field4_create_pnl4_txt.Text = "";
            field5_create_pnl4_txt.Text = "";
            field1_create_pnl4_lbl.Visible = true;
            field2_create_pnl4_lbl.Visible = true;
            field3_create_pnl4_lbl.Visible = true;
            field4_create_pnl4_lbl.Visible = true;
            field5_create_pnl4_lbl.Visible = true;
            field1_create_pnl4_txt.Visible = true;
            field2_create_pnl4_txt.Visible = true;
            field3_create_pnl4_txt.Visible = true;
            field4_create_pnl4_txt.Visible = true;
            field5_create_pnl4_txt.Visible = true;
            Pname_create_pnl4_txt.Text = "";
            title_create_pnl4_ddl.SelectedIndex = 0;
            title_create_pnl4_ddl.Text = "";
            subtitle_create_pnl4_ddl.SelectedIndex = 0;
            subtitle_create_pnl4_ddl.Text = "";
        }

        //update
        int aID = -1;
        List<int> pID = new List<int>();
        int index = -1;
        public void bringAdv(object sender, EventArgs e)
        {
            List<string> adv = Advertisment.getAdv(aID);
            Aname_create_pnl4_txt.Text = adv[1];
            type_create_pnl4_ddl.Text = adv[2];
            for (int i = 0; i < type_create_pnl4_ddl.Items.Count; i++)
                if (type_create_pnl4_ddl.Items[i].ToString() == adv[2])
                    type_create_pnl4_ddl.SelectedIndex = i;

            if (adv[2] == "Lending")
                recieve_create_pnl4_lbl.Text = "Price";
            else if(adv[2] == "Donation")
                recieve_create_pnl4_lbl.Text = "Deposit";
            else
                recieve_create_pnl4_lbl.Text = "Items";
            recieve_create_pnl4_txt.Text = adv[3];
            from_create_pnl4_txt.Text = adv[4];
            to_create_pnl4_txt.Text = adv[5];
            if (adv[6] == "1")
                allow_create_pnl4_chk.Checked = true;
            else
                allow_create_pnl4_chk.Checked = false;
            for (int i = 0; i < policy_create_pnl4_ddl.Items.Count; i++)
                if (policy_create_pnl4_ddl.Items[i].ToString() == adv[7])
                    policy_create_pnl4_ddl.SelectedIndex = i;
            

            pID = Products.itemsPerAdv(aID);
            index = 0;
            bringProduct(sender, e);
        }
        public void bringProduct(object sender, EventArgs e)
        {
            List<string> item = Products.getProduct(pID[index]);
            Pname_create_pnl4_txt.Text = item[0];
            title_create_pnl4_ddl.Text = item[1];
            for (int i = 0; i < title_create_pnl4_ddl.Items.Count; i++)
                if (title_create_pnl4_ddl.Items[i].ToString() == item[1])
                    title_create_pnl4_ddl.SelectedIndex = i;

            title_create_pnl4_ddl_SelectedIndexChanged(sender, e);

            subtitle_create_pnl4_ddl.Text = item[2];
            for (int i = 0; i < subtitle_create_pnl4_ddl.Items.Count; i++)
                if (subtitle_create_pnl4_ddl.Items[i].ToString() == item[2])
                    subtitle_create_pnl4_ddl.SelectedIndex = i;

            string []values=item[3].Split('^');
            field1_create_pnl4_txt.Text = values[0];
            field2_create_pnl4_txt.Text = values[1];
            field3_create_pnl4_txt.Text = values[2];
            field4_create_pnl4_txt.Text = values[3];
            field5_create_pnl4_txt.Text = values[4];

        }
        private void Aupdate_pnl4_btn_Click(object sender, EventArgs e)
        {
            string valid = Advertisment.validation(Aname_create_pnl4_txt.Text, type_create_pnl4_ddl.Items[type_create_pnl4_ddl.SelectedIndex].ToString(), recieve_create_pnl4_txt.Text, from_create_pnl4_txt.Text, to_create_pnl4_txt.Text);
            if (aID==-1)
                return;
            if (valid != "")
            {
                MessageBox.Show(valid);
                return;
            }

            int allow = 0;
            if (allow_create_pnl4_chk.Checked)
                allow = 1;
            Advertisment.update(aID, DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year, Aname_create_pnl4_txt.Text, type_create_pnl4_ddl.Items[type_create_pnl4_ddl.SelectedIndex].ToString(), recieve_create_pnl4_txt.Text, from_create_pnl4_txt.Text, to_create_pnl4_txt.Text, allow, policy_create_pnl4_ddl.Items[policy_create_pnl4_ddl.SelectedIndex].ToString());
            MessageBox.Show("success");
        }
        private void Pupdate_pnl4_btn_Click(object sender, EventArgs e)
        {
            

            string valid = Products.validation(Pname_create_pnl4_txt.Text, title_create_pnl4_ddl.SelectedIndex, subtitle_create_pnl4_ddl.SelectedIndex, null);
            if (valid != "")
            {
                MessageBox.Show(valid);
                return;
            }

            Products.update(pID[index], Pname_create_pnl4_txt.Text, title_create_pnl4_ddl.Items[title_create_pnl4_ddl.SelectedIndex].ToString(), subtitle_create_pnl4_ddl.Items[subtitle_create_pnl4_ddl.SelectedIndex].ToString(), field1_create_pnl4_txt.Text + "^" + field2_create_pnl4_txt.Text + "^" + field3_create_pnl4_txt.Text + "^" + field4_create_pnl4_txt.Text + "^" + field5_create_pnl4_txt.Text, null);
            MessageBox.Show("success");
        }
        private void next_update_btn_Click(object sender, EventArgs e)
        {
            index = (index + 1) % pID.Count;
            bringProduct(sender, e);
        }
        private void prev_update_btn_Click(object sender, EventArgs e)
        {
            index = (index+ pID.Count - 1) % pID.Count;
            bringProduct(sender, e);
        }

        ///////////////////////panel5
        private void delete_my_pnl5_btn_Click(object sender, EventArgs e)
        {
            if (list_my_pnl5_lv.SelectedItems.Count == 0)
                return;
            for (int i = 0; i < list_my_pnl5_lv.Items.Count; i++)
                if (list_my_pnl5_lv.Items[i].Selected)
                {
                    list_my_pnl5_lv.Items[i].Remove();
                    i--;
                }
        }

        private void view_my_pnl5_btn_Click(object sender, EventArgs e)
        {
            if (list_my_pnl5_lv.SelectedItems.Count == 0)
                return;


            int index = 0;
            for (int i = 0; i < list_my_pnl5_lv.Items.Count; i++)
                if (list_my_pnl5_lv.Items[i].Selected)
                    index = i;


            Form1 f1 = new Form1();
            f1.Controls.Clear();
            f1.Show();
            f1.Size = new Size(1264, 648);
            f1.Visible = true;

            Label adv_show_lbl = new Label();
            adv_show_lbl.Location = new Point(12, 21);
            adv_show_lbl.Size = new Size(300, 400);
            f1.Controls.Add(adv_show_lbl);
            Label items_show_lbl = new Label();
            items_show_lbl.Location = new Point(385, 21);
            items_show_lbl.Size = new Size(600, 400);
            f1.Controls.Add(items_show_lbl);

            List<string> adv = Advertisment.getAdv(Convert.ToInt32(list_my_pnl5_lv.Items[index].SubItems[4].Text));
            adv_show_lbl.Text = "Name: " + adv[1] + "\n\n";
            adv_show_lbl.Text += "Date: " + adv[0] + "\n\n";
            adv_show_lbl.Text += "Type: " + adv[2] + "\n\n";
            if (adv[2] == "Lending")
                adv_show_lbl.Text += "Price: " + adv[3] + "\n\n";
            else if (adv[2] == "Donation")
                adv_show_lbl.Text += "Deposit: " + adv[3] + "\n\n";
            else
                adv_show_lbl.Text += "Items: " + adv[3] + "\n\n";
            adv_show_lbl.Text += "From: " + adv[4] + " - ";
            adv_show_lbl.Text += adv[5] + "\n\n";
            if (adv[6] == "1")
                adv_show_lbl.Text += "Canceling allowed \n\n";
            else
                adv_show_lbl.Text += "Canceling not allowed \n\n";
            adv_show_lbl.Text += "Confirmation policy: " + adv[7] + "\n\n";


            items_show_lbl.Text = "";
            List<int> items = Products.itemsPerAdv(Convert.ToInt32(list_my_pnl5_lv.Items[index].SubItems[4].Text));
            for (int i = 0; i < items.Count; i++)
            {
                List<string> item = Products.getProduct(items[i]);
                items_show_lbl.Text += "name: " + item[0] + ", title: " + item[1] + ", subtitle: " + item[2];
                List<string> fields = Products.getfields(item[1]);
                string[] values = item[3].Split('^');
                for (int j = 0; j < fields.Count; j++)
                {
                    if (fields[j] != "")
                        items_show_lbl.Text += ", " + fields[j] + ": " + values[j];
                }

                items_show_lbl.Text += "\n\n";
            }
        }

        private void update_my_pnl5_btn_Click(object sender, EventArgs e)
        {
            if (list_my_pnl5_lv.SelectedItems.Count == 0)
                return;

            int index = 0;
            for (int i = 0; i < list_my_pnl5_lv.Items.Count; i++)
                if (list_my_pnl5_lv.Items[i].Selected)
                    index = i;

            
            create_adv_bar_btn_Click(sender, e);//as an update
            Aupdate_pnl4_btn.Visible = true;
            Pupdate_pnl4_btn.Visible = true;
            next_update_btn.Visible = true;
            prev_update_btn.Visible = true;
            aID = Convert.ToInt32(list_my_pnl5_lv.Items[index].SubItems[4].Text);
            bringAdv(sender,e);
        }
    }
}
