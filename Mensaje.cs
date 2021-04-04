using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Mensaje : Form
    {
        public Mensaje()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MailMessage mmsg = new MailMessage();

            mmsg.To.Add("pruebasprog244@gmail.com");
            mmsg.Subject = textBox1.Text;
            mmsg.SubjectEncoding = Encoding.UTF8;
            mmsg.Body = textBox2.Text;
            mmsg.BodyEncoding = Encoding.UTF8;
            mmsg.IsBodyHtml = true;
            mmsg.From = new MailAddress("pruebasprog245@gmail.com");

            SmtpClient cliente = new SmtpClient();
            cliente.UseDefaultCredentials = false;
            cliente.Credentials = new NetworkCredential("pruebasprog245@gmail.com","Pruebas@245.");
            cliente.Port = 587;
            cliente.EnableSsl = true;

            cliente.Host = "smtp.gmail.com";

            try{
                cliente.Send(mmsg);
                MessageBox.Show("Se envio el mensaje correctamente. \n \nResponderemos tan pronto como podamos.");
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu men = new menu();
            men.Show();
        }
    }
}
