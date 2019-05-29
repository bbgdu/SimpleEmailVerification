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



namespace Verify
{   
    public partial class Veification : Form
   {


       static Random rnd = new Random();

        int vnumber = rnd.Next(10000, 99999);
        public Veification()
        {
            InitializeComponent();
        }

        private void Veification_Load(object sender, EventArgs e)
        {

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Int32.Parse(textBox1.Text.Trim()) == vnumber)
            {
                MessageBox.Show("Congratulations!\nYour Account is verified!");
                this.Close();
            }
            else if(textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Cannot be empty!");
            }
            else
            {
                MessageBox.Show("Wrong Code!");
                this.Close();
            }
            
        }


        private void emailbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            textBox1.ReadOnly = false;

            try
            {
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.Credentials = new NetworkCredential("deepak654123@gmail.com", "renukadeepak67");
                client.EnableSsl = true;
                
                
                
                MailMessage msg = new MailMessage();
                msg.To.Add(emailbox.Text.Trim()+".com");
                msg.From = new MailAddress("deepak654123@gmail.com");
                msg.Subject = "Verification from Deepak:";
                //msg.Body = "Dear Google User,\n\t\t\tThis mail is for the verification process you opted from the software in Deepak's pc.If you initiated the verification process, please enter the verification code below.\nYour verification code is\n"+ 1234 + "\nSincerely,\nThe Deepak's PC.";
                msg.Body = string.Format("Dear Google User,\n\tThis mail is for the verification process you opted from the software in Deepak's pc.If you initiated the verification process, please enter the verification code below.\nYour verification code is \n\n{0}\n\nSincerely,\nThe DEEPAK's PC.",vnumber);
                client.Send(msg);
                MessageBox.Show("Message has been send Succesfully!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Couldn't Send Gmail." + ex.Message);
            }
        }
    }
}
