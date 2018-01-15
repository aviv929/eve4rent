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
            Users.login("a", "b");
            
        }


        ///////////////////////panel1
        public static bool logged = false;
        public static string username = "";
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
                welcome_bar_lbl.Text = "Welcome "+username;
                panel2_pnl.Visible = true;
                panel1_pnl.Visible = false;

                user_txt.Text = "";
                pass_txt.Text = "";

                try
                {
                    //pictureBox3.Image =Users.getImage(username);
                    //pictureBox3.Visible = true;
                    //pictureBox3.Show();
                }
                catch (Exception){}
                
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


            panel6_pnl.Visible = false;
            panel5_pnl.Visible = false;
            panel3_pnl.Visible = true;
            panel4_pnl.Visible = false;
        }
        private void create_adv_bar_btn_Click(object sender, EventArgs e)
        {
            lockControls(true);
            aID = -1;
            Aupdate_pnl4_btn.Visible = false;
            Pupdate_pnl4_btn.Visible = false;
            next_update_btn.Visible = false; 
            prev_update_btn.Visible = false;

           

            panel3_pnl.Visible = false;
            panel4_pnl.Visible = true;
            panel5_pnl.Visible = false;
            panel6_pnl.Visible = false;

            List<string> l= Products.getTitles();
            title_create_pnl4_ddl.Items.Clear();
            for (int i = 0; i < l.Count; i++)
                title_create_pnl4_ddl.Items.Add(l[i]);
            type_create_pnl4_ddl.SelectedIndex = 0;
            items = new List<string>();
            pictures = new List<Image>();

            clearAdv();
            clearProduct();
            mini_pnl.Visible = false;
        }
        private void my_adv_bar_btn_Click(object sender, EventArgs e)
        {
            panel6_pnl.Visible = false;
            panel5_pnl.Visible = true;
            panel3_pnl.Visible = false;
            panel4_pnl.Visible = false;

            Advertisment.allAdv(list_my_pnl5_lv, username);
        }
        private void serach_adv_bar_btn_Click(object sender, EventArgs e)
        {
            clearSearch();

            panel6_pnl.Visible = true;
            panel5_pnl.Visible = false;
            panel3_pnl.Visible = false;
            panel4_pnl.Visible = false;

        }
        private void myorders_bar_btn_Click(object sender, EventArgs e)
        {

        }

        ///////////////////////panel3

        ///////////////////////panel4
        List<string> items;
        List<Image> pictures;
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

            //ddl
            ddl();
        }
        private void type_create_pnl4_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            orecieve_create_pnl4_lbl.Visible = false;
            orecieve_create_pnl4_txt.Visible = false;
            if (type_create_pnl4_ddl.Items[type_create_pnl4_ddl.SelectedIndex].ToString() == "Lending")
                recieve_create_pnl4_lbl.Text = "Price";
            else if (type_create_pnl4_ddl.Items[type_create_pnl4_ddl.SelectedIndex].ToString() == "Donation")
                recieve_create_pnl4_lbl.Text = "Deposit";
            else if (type_create_pnl4_ddl.Items[type_create_pnl4_ddl.SelectedIndex].ToString() == "Trading")
            {
                recieve_create_pnl4_lbl.Text = "addional price";
                orecieve_create_pnl4_lbl.Visible = true;
                orecieve_create_pnl4_txt.Visible = true;
            }
        }
        private void picture_create_pnl4_txt_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();


            try
            {
                pictureBox2.Load(openFileDialog1.FileName);
                pictureBox2.Show();
            }
            catch (Exception)
            {
            }
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
            if (pictureBox2.Image!=null)
                pictures.Add((Image)pictureBox2.Image.Clone());

            clearProduct();
            mini_pnl.Visible = false;
        }
        private void add_create_pnl4_btn_Click(object sender, EventArgs e)
        {
            //validation
            string valid = Advertisment.validation(Aname_create_pnl4_txt.Text, type_create_pnl4_ddl.Items[type_create_pnl4_ddl.SelectedIndex].ToString(), recieve_create_pnl4_txt.Text , orecieve_create_pnl4_txt.Text, dateTimePicker1.Value.ToString("dd-MM-yyyy"), dateTimePicker2.Value.ToString("dd-MM-yyyy"));          
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
            int advNum= Advertisment.add(username, DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year, Aname_create_pnl4_txt.Text, type_create_pnl4_ddl.Items[type_create_pnl4_ddl.SelectedIndex].ToString(),Convert.ToInt32(recieve_create_pnl4_txt.Text) , orecieve_create_pnl4_txt.Text, dateTimePicker1.Value.ToString("dd-MM-yyyy"), dateTimePicker2.Value.ToString("dd-MM-yyyy"), allow, policy_create_pnl4_ddl.Items[policy_create_pnl4_ddl.SelectedIndex].ToString());
            for (int i = 0; i < items.Count; i=i+4)
            {
                Products.add(advNum, items[i], items[i+1], items[i+2], items[i+3], null);
            }
            items.Clear();
            MessageBox.Show("success");

            clearAdv();
        }

        private void ddl()
        {
            field1_create_pnl4_txt.Text = "";
            field2_create_pnl4_txt.Text = "";
            field3_create_pnl4_txt.Text = "";
            field4_create_pnl4_txt.Text = "";
            field5_create_pnl4_txt.Text = "";

            adapter1_create_ddl.Visible = false;
            adapter2_create_ddl.Visible = false;
            adapter3_create_ddl.Visible = false;
            adapter4_create_ddl.Visible = false;
            if (title_create_pnl4_ddl.Text == "Pets")
            {
                adapter1_create_ddl.Visible = true;
                adapter1_create_ddl.Location = field1_create_pnl4_txt.Location;
                field1_create_pnl4_txt.Text = "Male";
            }
            else if (title_create_pnl4_ddl.Text == "Vehicles")
            {
                adapter2_create_ddl.Visible = true;
                adapter2_create_ddl.Location = field1_create_pnl4_txt.Location;
                field1_create_pnl4_txt.Text = "Yes";

                adapter3_create_ddl.Visible = true;
                adapter3_create_ddl.Location = field2_create_pnl4_txt.Location;
                field2_create_pnl4_txt.Text = "Audi";
            }
            else if (title_create_pnl4_ddl.Text == "Second Hand")
            {
                adapter4_create_ddl.Visible = true;
                adapter4_create_ddl.Location = field1_create_pnl4_txt.Location;
                field1_create_pnl4_txt.Text = "New";
            }
        }
        private void adapter1_create_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            field1_create_pnl4_txt.Text = adapter1_create_ddl.Text;
        }
        private void adapter2_create_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            field1_create_pnl4_txt.Text = adapter2_create_ddl.Text;
        }
        private void adapter3_create_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            field2_create_pnl4_txt.Text = adapter3_create_ddl.Text;
        }
        private void adapter4_create_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            field1_create_pnl4_txt.Text = adapter4_create_ddl.Text;
        }

        private void clearAdv()
        {
            //clear
            Aname_create_pnl4_txt.Text = "";        
            recieve_create_pnl4_txt.Text = "";
            orecieve_create_pnl4_txt.Text = "";
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

            pictureBox2.Hide();
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
                recieve_create_pnl4_lbl.Text = "addional price";
            recieve_create_pnl4_txt.Text = adv[3];
            dateTimePicker1.Text = adv[4];
            dateTimePicker2.Text = adv[5];
            if (adv[6] == "1")
                allow_create_pnl4_chk.Checked = true;
            else
                allow_create_pnl4_chk.Checked = false;
            for (int i = 0; i < policy_create_pnl4_ddl.Items.Count; i++)
                if (policy_create_pnl4_ddl.Items[i].ToString() == adv[7])
                    policy_create_pnl4_ddl.SelectedIndex = i;
            orecieve_create_pnl4_txt.Text = adv[8];

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
            //ddl
            ddl();

            string[] values = item[3].Split('^');
            field1_create_pnl4_txt.Text = values[0];
            field2_create_pnl4_txt.Text = values[1];
            field3_create_pnl4_txt.Text = values[2];
            field4_create_pnl4_txt.Text = values[3];
            field5_create_pnl4_txt.Text = values[4];

            for (int i = 0; i < adapter1_create_ddl.Items.Count; i++)
                if (adapter1_create_ddl.Items[i].ToString() == values[0])
                    adapter1_create_ddl.SelectedIndex = i;
            for (int i = 0; i < adapter2_create_ddl.Items.Count; i++)
                if (adapter2_create_ddl.Items[i].ToString() == values[0])
                    adapter2_create_ddl.SelectedIndex = i;
            for (int i = 0; i < adapter3_create_ddl.Items.Count; i++)
                if (adapter3_create_ddl.Items[i].ToString() == values[0])
                    adapter3_create_ddl.SelectedIndex = i;
            for (int i = 0; i < adapter4_create_ddl.Items.Count; i++)
                if (adapter4_create_ddl.Items[i].ToString() == values[0])
                    adapter4_create_ddl.SelectedIndex = i;
        }
        private void Aupdate_pnl4_btn_Click(object sender, EventArgs e)
        {
            string valid = Advertisment.validation(Aname_create_pnl4_txt.Text, type_create_pnl4_ddl.Items[type_create_pnl4_ddl.SelectedIndex].ToString(), recieve_create_pnl4_txt.Text , orecieve_create_pnl4_txt.Text, dateTimePicker1.Value.ToString("dd-MM-yyyy"), dateTimePicker2.Value.ToString("dd-MM-yyyy"));
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
            Advertisment.update(aID, DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year, Aname_create_pnl4_txt.Text, type_create_pnl4_ddl.Items[type_create_pnl4_ddl.SelectedIndex].ToString(), Convert.ToInt32(recieve_create_pnl4_txt.Text) , orecieve_create_pnl4_txt.Text, dateTimePicker1.Value.ToString("dd-MM-yyyy"), dateTimePicker2.Value.ToString("dd-MM-yyyy"), allow, policy_create_pnl4_ddl.Items[policy_create_pnl4_ddl.SelectedIndex].ToString());
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
                    Advertisment.delete(Convert.ToInt32(list_my_pnl5_lv.Items[i].SubItems[4].Text));
                    list_my_pnl5_lv.Items[i].Remove();                   
                    i--;
                }

            
        }
        private void view_my_pnl5_btn_Click(object sender, EventArgs e)
        {
            update_my_pnl5_btn_Click(sender, e);
            lockControls(false);

        }
        private void lockControls(bool l)
        {
            field1_create_pnl4_txt.Enabled = l;
            field2_create_pnl4_txt.Enabled = l;
            field3_create_pnl4_txt.Enabled = l;
            field4_create_pnl4_txt.Enabled = l;
            field5_create_pnl4_txt.Enabled = l;
            Pname_create_pnl4_txt.Enabled = l;
            policy_create_pnl4_ddl.Enabled = l;
            Aname_create_pnl4_txt.Enabled = l;
            recieve_create_pnl4_txt.Enabled = l;
            orecieve_create_pnl4_txt.Enabled = l;
            dateTimePicker1.Enabled = l;
            dateTimePicker2.Enabled = l;
            subtitle_create_pnl4_ddl.Enabled = l;
            title_create_pnl4_ddl.Enabled = l;
            type_create_pnl4_ddl.Enabled = l;
            allow_create_pnl4_chk.Enabled = l;
            picture_create_pnl4_btn.Visible = l;
            addP_create_pnl4_btn.Visible = l;
            add_create_pnl4_btn.Visible = l;
            Aupdate_pnl4_btn.Visible = l;
            Pupdate_pnl4_btn.Visible = l;

            adapter1_create_ddl.Enabled = l;
            adapter2_create_ddl.Enabled = l;
            adapter3_create_ddl.Enabled = l;
            adapter4_create_ddl.Enabled = l;
        }
        public void update_my_pnl5_btn_Click(object sender, EventArgs e)
        {
            if (list_my_pnl5_lv.SelectedItems.Count == 0)
                return;
            lockControls(true);

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

        ///////////////////////panel6

        public static List<string> data = new List<string>();
        public static int requestid = -1;
        private void search_search_pnl6_btn_Click(object sender, EventArgs e)
        {
            if (type_search_pnl6_ddl.SelectedIndex == -1)
                type_search_pnl6_ddl.SelectedIndex = 0;
            if (policy_search_pnl6_ddl.SelectedIndex == -1)
                policy_search_pnl6_ddl.SelectedIndex = 0;
            if (title_search_pnl6_ddl.SelectedIndex == -1)
                title_search_pnl6_ddl.SelectedIndex = 0;
            if (subtitle_search_pnl6_ddl.SelectedIndex == -1)
                subtitle_search_pnl6_ddl.SelectedIndex = 0;

            List<string> val = new List<string>();
            val.Add(r1_search_pnl6_chk.Checked + "");
            val.Add(dateTimePicker3.Text);
            val.Add(dateTimePicker4.Text);
            val.Add(r2_search_pnl6_chk.Checked + "");
            val.Add(type_search_pnl6_ddl.Items[type_search_pnl6_ddl.SelectedIndex].ToString());
            val.Add(r3_search_pnl6_chk.Checked + "");
            val.Add(allow_search_pnl6_chk.Checked + "");
            val.Add(r4_search_pnl6_chk.Checked + "");
            val.Add(min_search_pnl6_txt.Text);
            val.Add(max_search_pnl6_txt.Text);
            val.Add(r5_search_pnl6_chk.Checked + "");
            val.Add(policy_search_pnl6_ddl.Items[policy_search_pnl6_ddl.SelectedIndex].ToString());
            val.Add(r6_search_pnl6_chk.Checked + "");
            val.Add(name_search_pnl6_txt.Text);
            val.Add(r7_search_pnl6_chk.Checked + "");
            val.Add(title_search_pnl6_ddl.Items[title_search_pnl6_ddl.SelectedIndex].ToString());
            val.Add(r8_search_pnl6_chk.Checked + "");
            val.Add(subtitle_search_pnl6_ddl.Items[subtitle_search_pnl6_ddl.SelectedIndex].ToString());
            val.Add(r9_search_pnl6_chk.Checked + "");
            val.Add(field1_search_pnl6_txt.Text);
            val.Add(r10_search_pnl6_chk.Checked + "");
            val.Add(field2_search_pnl6_txt.Text);
            val.Add(r11_search_pnl6_chk.Checked + "");
            val.Add(field3_search_pnl6_txt.Text);
            val.Add(r12_search_pnl6_chk.Checked + "");
            val.Add(field4_search_pnl6_txt.Text);
            val.Add(r13_search_pnl6_chk.Checked + "");
            val.Add(field5_search_pnl6_txt.Text);

            //validation
            string error = Advertisment.searchValidation(val);
            if (error != "")
            {
                MessageBox.Show(error);
                return;
            }

            data = Advertisment.searchAll(val);
            //pid,aid,pname,title,sub,f1,f2,f3,f4,f5,user,date,aname,type,recieve,from,to,cancle,policy//19

            results_search_pnl6_lv.Items.Clear();
            for (int i = 0; i < data.Count; i = i + 20)
            {
                ListViewItem tmp = new ListViewItem(data[i + 12]);
                tmp.SubItems.Add(data[i + 2]);
                tmp.SubItems.Add(data[i + 11]);
                tmp.SubItems.Add(data[i + 13]);
                tmp.SubItems.Add(data[i + 14]);
                tmp.SubItems.Add(data[i]);
                results_search_pnl6_lv.Items.Add(tmp);
            }

            //add history
            if (logged)
                Searches.add(username,val);
            
        }
        private void title_search_pnl6_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            mini_pnl2.Visible = true;

            List<string> l = Products.getSubtitles(title_search_pnl6_ddl.Items[title_search_pnl6_ddl.SelectedIndex].ToString());
            subtitle_search_pnl6_ddl.Items.Clear();
            subtitle_search_pnl6_ddl.Text = "";
            for (int i = 0; i < l.Count; i++)
                subtitle_search_pnl6_ddl.Items.Add(l[i]);

            l = Products.getfields(title_search_pnl6_ddl.Items[title_search_pnl6_ddl.SelectedIndex].ToString());
            Label[] lbl = { field1_search_pnl6_lbl, field2_search_pnl6_lbl, field3_search_pnl6_lbl, field4_search_pnl6_lbl, field5_search_pnl6_lbl };
            TextBox[] txt = { field1_search_pnl6_txt, field2_search_pnl6_txt, field3_search_pnl6_txt, field4_search_pnl6_txt, field5_search_pnl6_txt };
            CheckBox[] chk = { r9_search_pnl6_chk, r10_search_pnl6_chk, r11_search_pnl6_chk, r12_search_pnl6_chk, r13_search_pnl6_chk };
            for (int i = 0; i < 5; i++)
            {
                lbl[i].Visible = true;
                txt[i].Visible = true;
                //chk[i].Visible = true;
                chk[i].Checked = false;
                if (l[i] != "")
                    lbl[i].Text = l[i];
                else
                {
                    lbl[i].Visible = false;
                    txt[i].Visible = false;
                    //chk[i].Visible = false;
                }
            }

            //ddl
            ddl2();
        }
        private void type_search_pnl6_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            price_search_pnl6_lbl.Visible = true;
            min_search_pnl6_txt.Visible = true;
            max_search_pnl6_txt.Visible = true;
            label7.Visible = true;
            r4_search_pnl6_chk.Visible = true;
            r4_search_pnl6_chk.Checked = false;
            if (type_search_pnl6_ddl.Items[type_search_pnl6_ddl.SelectedIndex].ToString() == "Lending")
                price_search_pnl6_lbl.Text = "Price";
            else if (type_search_pnl6_ddl.Items[type_search_pnl6_ddl.SelectedIndex].ToString() == "Donation")
                price_search_pnl6_lbl.Text = "Deposit";
            else if (type_search_pnl6_ddl.Items[type_search_pnl6_ddl.SelectedIndex].ToString() == "Trading")
            {
                price_search_pnl6_lbl.Text = "addional price";
                price_search_pnl6_lbl.Visible = false;
                min_search_pnl6_txt.Visible = false;
                max_search_pnl6_txt.Visible = false;
                min_search_pnl6_txt.Text = "0";
                max_search_pnl6_txt.Text = "0";
                label7.Visible = false;
                r4_search_pnl6_chk.Visible = false;
            }
        }
        private void results_search_pnl6_lv_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            for (int i = 0; i < results_search_pnl6_lv.Items.Count; i++)
                if (results_search_pnl6_lv.Items[i].Selected)
                    requestid = i;
            Form3 f = new Form3();
            f.Show();


            //results_search_pnl6_lv.Items.Clear();
            //serach_adv_bar_btn_Click(sender, e);
            search_search_pnl6_btn_Click(sender, e);


        }
        private void clearSearch()
        {
            results_search_pnl6_lv.Items.Clear();
            r1_search_pnl6_chk.Checked = false;
            r2_search_pnl6_chk.Checked = false;
            r3_search_pnl6_chk.Checked = false;
            r4_search_pnl6_chk.Checked = false;
            r5_search_pnl6_chk.Checked = false;
            r6_search_pnl6_chk.Checked = false;
            r7_search_pnl6_chk.Checked = false;
            r8_search_pnl6_chk.Checked = false;
            r9_search_pnl6_chk.Checked = false;
            r10_search_pnl6_chk.Checked = false;
            r11_search_pnl6_chk.Checked = false;
            r12_search_pnl6_chk.Checked = false;
            r13_search_pnl6_chk.Checked = false;

            allow_search_pnl6_chk.Checked = false;
            min_search_pnl6_txt.Text = "0";
            max_search_pnl6_txt.Text = "0";          
            name_search_pnl6_txt.Clear();            
            field1_search_pnl6_txt.Text = "";
            field2_search_pnl6_txt.Text = "";
            field3_search_pnl6_txt.Text = "";
            field4_search_pnl6_txt.Text = "";
            field5_search_pnl6_txt.Text = "";
            dateTimePicker3.Value = DateTime.Now;
            dateTimePicker4.Value = DateTime.Now;
            type_search_pnl6_ddl.Text = "Lending";
            policy_search_pnl6_ddl.Text = "Safe";

            //title_search_pnl6_ddl.SelectedIndex = 0;
            //subtitle_search_pnl6_ddl.SelectedIndex = 0;
            title_search_pnl6_ddl.Text = "";
            subtitle_search_pnl6_ddl.Text = "";
            mini_pnl2.Visible = false;
        }

        private void ddl2()
        {
            field1_search_pnl6_txt.Text = "";
            field2_search_pnl6_txt.Text = "";
            field3_search_pnl6_txt.Text = "";
            field4_search_pnl6_txt.Text = "";
            field5_search_pnl6_txt.Text = "";

            adapter1_search_ddl.Visible = false;
            adapter2_search_ddl.Visible = false;
            adapter3_search_ddl.Visible = false;
            adapter4_search_ddl.Visible = false;
            if (title_search_pnl6_ddl.Text == "Pets")
            {
                adapter1_search_ddl.Visible = true;
                adapter1_search_ddl.Location = field1_search_pnl6_txt.Location;
                field1_search_pnl6_txt.Text = "Male";
            }
            else if (title_search_pnl6_ddl.Text == "Vehicles")
            {
                adapter2_search_ddl.Visible = true;
                adapter2_search_ddl.Location = field1_search_pnl6_txt.Location;
                field1_search_pnl6_txt.Text = "Yes";

                adapter3_search_ddl.Visible = true;
                adapter3_search_ddl.Location = field2_search_pnl6_txt.Location;
                field2_search_pnl6_txt.Text = "Audi";
            }
            else if (title_search_pnl6_ddl.Text == "Second Hand")
            {
                adapter4_search_ddl.Visible = true;
                adapter4_search_ddl.Location = field1_search_pnl6_txt.Location;
                field1_search_pnl6_txt.Text = "New";
            }
        }
        private void adapter1_search_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            field1_search_pnl6_txt.Text = adapter1_search_ddl.Text;
        }
        private void adapter2_search_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            field1_search_pnl6_txt.Text = adapter2_search_ddl.Text;
        }
        private void adapter3_search_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            field2_search_pnl6_txt.Text = adapter3_search_ddl.Text;
        }
        private void adapter4_search_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            field1_search_pnl6_txt.Text = adapter4_search_ddl.Text;
        }
    }
}
