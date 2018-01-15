using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Mail;

namespace everything4rent
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        private void Form2_Load(object sender, EventArgs e)
        {
        }
        private void register_btn_Click(object sender, EventArgs e)
        {
            //validation
            string valid= Users.validation(user_txt.Text, pass_txt.Text, email_txt.Text, name_txt.Text, last_txt.Text, dateTimePicker1.Value.ToString("dd-MM-yyy"), null, paypal_txt.Text);
            if (valid!="")
            {
                MessageBox.Show(valid);
                return;
            }

            try
            {
                Users.add(user_txt.Text, pass_txt.Text, email_txt.Text, name_txt.Text, last_txt.Text, dateTimePicker1.Value.ToString("dd-MM-yyy"), pictureBox1.Image, paypal_txt.Text);

            }
            catch (Exception)
            {
                MessageBox.Show("picture format are not supported");
            }


            string n1= email_txt.Text, n2= name_txt.Text, n3= last_txt.Text;
            Close();

            try
            {
                
                SmtpClient MailClient = new SmtpClient("smtp.gmail.com", 587);
                MailClient.EnableSsl = true;
                MailClient.Credentials = new NetworkCredential("eve4rent@gmail.com", "eve4rent!");
                MailMessage Msg = new MailMessage();

                Msg.From = new MailAddress("eve4rent@gmail.com");
                Msg.To.Add(new MailAddress(n1));
                Msg.Subject = "registretion approvment";
                Msg.Body = "Dear " + n2 + " " + n3 + "\n" + "You have successfully registered";
                MailClient.Send(Msg);
                
                
            }
            catch (Exception) {}

            MessageBox.Show("successful registration");          
        }


        
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            
            
            try
            {
                pictureBox1.Load(openFileDialog1.FileName);
                pictureBox1.Show();
            }
            catch (Exception)
            {

            }
        }

        private void name_lbl_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseDown)
            {
                mouseX = MousePosition.X - 200;
                mouseY = MousePosition.Y - 40;
                this.SetDesktopLocation(mouseX, mouseY);

            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void birth_txt_TextChanged(object sender, EventArgs e)
        {

        }


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }
    }
}
