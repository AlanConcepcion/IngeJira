using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            login f1 = new login();
            f1.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            historial his = new historial();
            his.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            prestamos pre = new prestamos();
            pre.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pagos pag = new Pagos();
            pag.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mensaje msg = new Mensaje();
            msg.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Cuentas cuent = new Cuentas();
            cuent.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Deudas deu = new Deudas();
            deu.Show();
        }
    }
}
