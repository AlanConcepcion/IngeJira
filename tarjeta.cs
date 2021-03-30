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
    public partial class tarjeta : Form
    {
        public tarjeta()
        {
            InitializeComponent();
        }

        Class1 clase2 = new Class1();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                MessageBox.Show("Llene los campos.");
            else
                clase2.z = textBox1.Text;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tarjeta_Load(object sender, EventArgs e)
        {

        }
    }
}
