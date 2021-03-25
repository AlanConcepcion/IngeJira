using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        public void login1()
        {

            try
            {

                string cn = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.Valor"].ConnectionString;

                

                using (SqlConnection conexion = new SqlConnection(cn)) {

                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("select id, contrasena from usuario where id= " + textBox1.Text + " and contrasena= '" + textBox2.Text + "' ", conexion);
                        SqlDataReader dr = cmd.ExecuteReader();

                        if(dr.Read())
                        {
                            this.Hide();
                            menu f2 = new menu();
                            f2.Show();
                        } else
                        {
                            MessageBox.Show("Ese no. c:");
                        }
                    
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            login1();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            crearusu cu = new crearusu();
            cu.Show();
        }
    }
}
