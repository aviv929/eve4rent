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

        }
        int aID = -1;
        List<int> pID = new List<int>();
        int index = -1;
        
        public void showAdv(int advID)
        {
            Show();
            Size = new Size(1264, 648);
            show_pnl.Visible = true;
            update_pnl.Visible = false;

            List<string> adv = Advertisment.getAdv(advID);
            adv_show_lbl.Text = "Name: " + adv[1] + "\n\n";
            adv_show_lbl.Text += "Date: " + adv[0] + "\n\n";
            adv_show_lbl.Text += "Type: " + adv[2] + "\n\n";
            if (adv[2]== "Landing")
                adv_show_lbl.Text += "Price: " + adv[3] + "\n\n";
            else if(adv[2] == "Donation")
                adv_show_lbl.Text += "Deposit: " + adv[3] + "\n\n";
            else
                adv_show_lbl.Text += "Items: " + adv[3] + "\n\n";
            adv_show_lbl.Text += "From: " + adv[4] + " - ";
            adv_show_lbl.Text +=  adv[5] + "\n\n";
            if (adv[6]=="1")
                adv_show_lbl.Text += "Canceling allowed \n\n";
            else
                adv_show_lbl.Text += "Canceling not allowed \n\n";
            adv_show_lbl.Text += "Policy: " + adv[7] + "\n\n";


            items_show_lbl.Text = "";
            List<int> items= Products.itemsPerAdv(advID);
            for (int i = 0; i < items.Count; i++)
            {
                List<string> item = Products.getProduct(items[i]);
                items_show_lbl.Text += "name: " + item[0] + ", title: " + item[1] + ", subtitle: " + item[2];
                List<string> fields = Products.getfields(item[1]);
                string[] values = item[3].Split('^');
                for (int j = 0; j < fields.Count; j++)
                {
                    if (fields[j] != "")
                        items_show_lbl.Text += ", " + fields[j]+": " + values[j];
                }          
                
                items_show_lbl.Text += "\n\n";
            }
        }

        public void bringAdv(int advID)
        {
            Show();
            Size = new Size(802, 506);
            show_pnl.Visible = false;
            update_pnl.Visible = true;

            

            List<string> adv = Advertisment.getAdv(advID);
            Aname_update_txt.Text = adv[1] ;
            type_update_ddl.Text =  adv[2] ;
            for (int i = 0; i < type_update_ddl.Items.Count; i++)
                if (type_update_ddl.Items[i].ToString()== adv[2])
                    type_update_ddl.SelectedIndex = i;

            if (adv[2] == "Landing" )
                recieve_update_lbl.Text = "Price";
            else if ( adv[2] == "Donation")
                recieve_update_lbl.Text = "Deposit";
            else
                recieve_update_lbl.Text = "Items";
            recieve_update_txt.Text = adv[3];
            from_update_txt.Text =adv[4];
            to_update_txt.Text = adv[5] ;
            if (adv[6] == "1")
                allow_update_chk.Checked = true;
            else
                allow_update_chk.Checked = false;
            policy_update_txt.Text =adv[7];

            aID = advID;
            pID = Products.itemsPerAdv(advID);
            bringProduct(aID, pID[index]);
        }

        public void bringProduct(int advID, int productID)
        {
            List<string> l = Products.getTitles();
            title_update_ddl.Items.Clear();
            for (int i = 0; i < l.Count; i++)
                title_update_ddl.Items.Add(l[i]);
            type_update_ddl.SelectedIndex = 0;



            List<string> item = Products.getProduct(productID);
            Pname_update_txt.Text = item[0];
            title_update_ddl.Text = item[1];
            for (int i = 0; i < title_update_ddl.Items.Count; i++)
                if (title_update_ddl.Items[i].ToString() == item[1])
                    title_update_ddl.SelectedIndex = i;





            List<string> sub = Products.getSubtitles(item[1]);
            subtitle_update_ddl.Items.Clear();
            for (int i = 0; i < sub.Count; i++)
                subtitle_update_ddl.Items.Add(sub[i]);
            subtitle_update_ddl.Text = item[2];
            for (int i = 0; i < subtitle_update_ddl.Items.Count; i++)
                if (subtitle_update_ddl.Items[i].ToString() == item[2])
                    subtitle_update_ddl.SelectedIndex = i;


           
        }

        private void adv_update_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
