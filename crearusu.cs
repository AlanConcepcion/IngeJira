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
    public partial class crearusu : Form
    {
        public crearusu()
        {
            InitializeComponent();
        }


        public void crearu()
        {

            try
            {

                string cn = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.Valor"].ConnectionString;

                using (SqlConnection conexion = new SqlConnection(cn))
                {

                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("insert into usuario (id, nombre, apellido, telefono, direccion, edad, correo, contrasena) values ("+ textBox3.Text + ",'" + textBox1.Text + "','" + textBox2.Text + "',"+ textBox4.Text + ",'" + textBox6.Text + "', " + textBox8.Text + ",'" + textBox5.Text + "','" + textBox7.Text + "')", conexion);
                    int query = cmd.ExecuteNonQuery();

                    if (query != 0)
                    {
                        MessageBox.Show("Se agrego usuario correctamente.");
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



        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            login lo = new login();
            lo.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crearu();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
