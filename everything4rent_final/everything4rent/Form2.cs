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
        private void Form2_Load(object sender, EventArgs e)
        {
        }
        private void register_btn_Click(object sender, EventArgs e)
        {
            //validation
            string valid= Users.validation(user_txt.Text, pass_txt.Text, email_txt.Text, name_txt.Text, last_txt.Text, birth_txt.Text, null, paypal_txt.Text);
            if (valid!="")
            {
                MessageBox.Show(valid);
                return;
            }

            try
            {
                Users.add(user_txt.Text, pass_txt.Text, email_txt.Text, name_txt.Text, last_txt.Text, birth_txt.Text, pictureBox1.Image, paypal_txt.Text);

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
    }
}
