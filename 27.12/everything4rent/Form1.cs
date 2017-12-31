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
        static bool logged = false;
        string username = "";

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }




        ///////////////////////panel1
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
        }
        private void create_adv_bar_btn_Click(object sender, EventArgs e)
        {
            panel3_pnl.Visible = false;
            panel4_pnl.Visible = true;

            List<string> l= Products.getTitles();
            title_create_pnl4_ddl.Items.Clear();
            for (int i = 0; i < l.Count; i++)
                title_create_pnl4_ddl.Items.Add(l[i]);
        }



        ///////////////////////panel3

        ///////////////////////panel4
        private void title_create_pnl4_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> l=Products.getSubtitles( title_create_pnl4_ddl.Items[title_create_pnl4_ddl.SelectedIndex].ToString() );
            subtitle_create_pnl4_ddl.Items.Clear();
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



            //add_create_pnl4_btn.Text=""+ Advertisment.add("a", "a", "a", "a", "a", "a", "a", 1, "a");
        }
    }
}
