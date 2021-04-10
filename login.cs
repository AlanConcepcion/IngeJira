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

                        }
                    conexion.Close();
                    
                }
            }

            catch (Exception e)
            {

               MessageBox.Show(e.Message);
            }
        }

        public void login2()
        {

            try
            {

                string cn = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.Valor"].ConnectionString;



                using (SqlConnection conexion = new SqlConnection(cn))
                {

                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("select id, contrasena from administrador where id= " + textBox1.Text + " and contrasena= '" + textBox2.Text + "' ", conexion);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        Hide();
                        Form1 f = new Form1();
                        f.Show();

                    }
                    conexion.Close();

                }
            }

            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox1.Text != "")
            {

                Class1 clase = new Class1();

                clase.a = textBox1.Text;
                
                login1();
                login2();
            } else 
            {
                
;                
            }

            if(textBox1.Text == "" && textBox1.Text == "")
            {
                MessageBox.Show("Los campos no pueden estar vacios.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {


            this.Hide();
            crearusu cu = new crearusu();
            cu.Show();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Debe ir a una sucursal para la creación de su cuenta.");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
