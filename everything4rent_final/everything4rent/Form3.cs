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
            adv_show_lbl.Text += "Confirmation policy: " + adv[7] + "\n\n";


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

     
        private void adv_update_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
