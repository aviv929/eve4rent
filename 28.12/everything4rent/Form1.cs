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
            
            //move to main form
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pic_btn f = new pic_btn();
           
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
            panel3_pnl.Visible = false;
            panel4_pnl.Visible = true;
            panel5_pnl.Visible = false;

            List<string> l= Products.getTitles();
            title_create_pnl4_ddl.Items.Clear();
            for (int i = 0; i < l.Count; i++)
                title_create_pnl4_ddl.Items.Add(l[i]);
            type_create_pnl4_ddl.SelectedIndex = 0;
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
        private void title_create_pnl4_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            if (type_create_pnl4_ddl.Items[type_create_pnl4_ddl.SelectedIndex].ToString()=="rent")
                recieve_create_pnl4_lbl.Text = "amount";
            else if (type_create_pnl4_ddl.Items[type_create_pnl4_ddl.SelectedIndex].ToString() == "charity")
                recieve_create_pnl4_lbl.Text = "amount";
            else if (type_create_pnl4_ddl.Items[type_create_pnl4_ddl.SelectedIndex].ToString() == "trade")
                recieve_create_pnl4_lbl.Text = "items";
        }
        private void picture_create_pnl4_txt_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
        private void add_create_pnl4_btn_Click(object sender, EventArgs e)
        {
            //validation
            string valid = Advertisment.validation(Aname_create_pnl4_txt.Text, type_create_pnl4_ddl.Items[type_create_pnl4_ddl.SelectedIndex].ToString(), recieve_create_pnl4_txt.Text, from_create_pnl4_txt.Text, to_create_pnl4_txt.Text);
            valid += Products.validation(Pname_create_pnl4_txt.Text,title_create_pnl4_ddl.SelectedIndex,subtitle_create_pnl4_ddl.SelectedIndex, null);
            if (valid != "")
            {
                MessageBox.Show(valid);
                return;
            }


            int allow = 0;
            if (allow_create_pnl4_chk.Checked)
                 allow = 1;
            int advNum= Advertisment.add(username, DateTime.Now.Day + "/" + DateTime.Now.Month + DateTime.Now.Year, Aname_create_pnl4_txt.Text, type_create_pnl4_ddl.Items[type_create_pnl4_ddl.SelectedIndex].ToString(), recieve_create_pnl4_txt.Text , from_create_pnl4_txt.Text, to_create_pnl4_txt.Text, allow,policy_create_pnl4_txt.Text);
            Products.add(advNum, Pname_create_pnl4_txt.Text, title_create_pnl4_ddl.Items[title_create_pnl4_ddl.SelectedIndex].ToString(), subtitle_create_pnl4_ddl.Items[subtitle_create_pnl4_ddl.SelectedIndex].ToString(), field1_create_pnl4_txt.Text+"^"+ field2_create_pnl4_txt.Text + "^" + field3_create_pnl4_txt.Text + "^" + field4_create_pnl4_txt.Text + "^" + field5_create_pnl4_txt.Text, null);
            MessageBox.Show("success");

            //clear
            Aname_create_pnl4_txt.Text = "";
            field1_create_pnl4_txt.Text = "";
            field2_create_pnl4_txt.Text = "";
            field3_create_pnl4_txt.Text = "";
            field4_create_pnl4_txt.Text = "";
            field5_create_pnl4_txt.Text = "";
            from_create_pnl4_txt.Text = "";
            picture_create_pnl4_txt.Text = "";
            Pname_create_pnl4_txt.Text = "";
            policy_create_pnl4_txt.Text = "";
            recieve_create_pnl4_txt.Text = "";
            to_create_pnl4_txt.Text = "";
        }


        ///////////////////////panel5
        
        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem("q");
            lvi.SubItems.Add("w");
            lvi.SubItems.Add("e");
            lvi.SubItems.Add("r");
            list_my_pnl5_lv.Items.Add(lvi);

            delete_my_pnl5_btn.Text = list_my_pnl5_lv.Items[1].SubItems[3].Text;
        }

        private void delete_my_pnl5_btn_Click(object sender, EventArgs e)
        {
            if (list_my_pnl5_lv.SelectedItems!=null)
            {
                //delete_my_pnl5_btn.Text = list_my_pnl5_lv.SelectedItems[0].Text;

                label1.Text = list_my_pnl5_lv.SelectedItems .Count+ "";
            }
        }
    }
}
