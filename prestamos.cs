using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class prestamos : Form
    {
        public prestamos()
        {
            InitializeComponent();
        }



        Class1 clase = new Class1();
        public void solicitar()
        {

            try
            {

                string cn = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.Valor"].ConnectionString;

                using (SqlConnection conexion = new SqlConnection(cn))
                {

                    conexion.Open();

                    int cantidad = Convert.ToInt32(textBox1.Text);
                    double interes = 0.05;

                    double aplicado = cantidad * interes;

                    int total = Convert.ToInt32(aplicado) + cantidad;


                    SqlCommand cmd = new SqlCommand("insert into prestamos(cantidad, fecha, fecha_lim, persona_id, estado) values (" + total + ",'" + Convert.ToString(dateTimePicker1.Value.ToString("yyyy-MM-dd")) + "','" + dateTimePicker1.Value.AddDays(30).ToString("yyyy-MM-dd") + "', " + clase.a + ", 2)", conexion);
                    int query = cmd.ExecuteNonQuery();

                    if (query != 0)
                    {
                        MessageBox.Show("Se Envio la solicitud.");
                    }
                    else
                    {
                        MessageBox.Show("Error, revise los campos.");
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                solicitar();   
            else MessageBox.Show("Llene los campos.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu me = new menu();
            me.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
