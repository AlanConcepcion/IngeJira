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
    public partial class Cuentas : Form
    {
        public Cuentas()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);


            Class1 clase = new Class1();

            try
            {
                string cn = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.Valor"].ConnectionString;

                using(SqlConnection conexion = new SqlConnection(cn)) {
                    

                    conexion.Open();

                    SqlCommand con = new SqlCommand("select nombre, apellido, telefono, correo, direccion, edad from usuario where id= " + Convert.ToInt32(clase.a), conexion);

                    SqlDataReader r = con.ExecuteReader();
                    
                    while (r.Read())
                    {
                        
                        label2.Text = Convert.ToString(r.GetValue(0))+ "  "  + Convert.ToString(r.GetValue(1));
                        label8.Text = Convert.ToString(r.GetValue(2));
                        label9.Text = Convert.ToString(r.GetValue(3));
                        label10.Text = Convert.ToString(r.GetValue(4));
                        label11.Text = Convert.ToString(r.GetValue(5));
                    } 
                }
            }

            catch (SqlException er)
            {
                MessageBox.Show(Convert.ToString(er));
            }
        }

        private void zaza_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            menu me = new menu();
            me.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
