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
    public partial class Editar : Form
    {
        public Editar()
        {
           

            InitializeComponent();
        }

        Class1 clase = new Class1();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);


            

            try
            {
                string cn = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.Valor"].ConnectionString;

                using (SqlConnection conexion = new SqlConnection(cn))
                {


                    conexion.Open();

                    SqlCommand con = new SqlCommand("select nombre, apellido, telefono, correo, direccion, edad, contrasena from usuario where id= " + Convert.ToInt32(clase.a), conexion);

                    SqlDataReader r = con.ExecuteReader();

                    while (r.Read())
                    {

                        textBox1.Text = Convert.ToString(r.GetValue(0));
                        textBox2.Text = Convert.ToString(r.GetValue(1));
                        textBox3.Text = Convert.ToString(r.GetValue(2));
                        textBox4.Text = Convert.ToString(r.GetValue(3));
                        textBox5.Text = Convert.ToString(r.GetValue(4));
                        textBox6.Text = Convert.ToString(r.GetValue(5));
                        textBox7.Text = Convert.ToString(r.GetValue(6));
                    }
                }
            }

            catch (SqlException er)
            {
                MessageBox.Show(Convert.ToString(er));
            }
        }

        private void Editar_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Cuentas cuent = new Cuentas();
            cuent.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cn = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.Valor"].ConnectionString;

                using (SqlConnection conexion = new SqlConnection(cn))
                {


                    conexion.Open();

                    SqlCommand con = new SqlCommand("update usuario set nombre = '" + textBox1.Text + "', apellido ='" + textBox2.Text + "', telefono =" + textBox3.Text + ", correo ='" + textBox4.Text + "', direccion = '" + textBox5.Text + "', edad = " + textBox6.Text + " , contrasena = '"+ textBox7.Text + "' where ID = " + clase.a, conexion);

                    int guardar = con.ExecuteNonQuery();
                    if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
                    {
                        if (guardar == 1) MessageBox.Show("Se Modifico correctamente.");

                        Close();
                        Cuentas cuent = new Cuentas();
                        cuent.Show();


                    }
                    else
                    {
                        MessageBox.Show("Campos vacios");
                    }
                }
            }

            catch (SqlException er)
            {
                MessageBox.Show(Convert.ToString(er));
            }
        }
    }
}
