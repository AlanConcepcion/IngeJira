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
    public partial class historial : Form
    {
        public historial()
        {
            InitializeComponent();
        }

        Class1 clase = new Class1();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu me = new menu();
            me.Show();
        }

        private void historial_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = lista();
        }

        private DataTable lista()
        {
            DataTable historial = new DataTable();



            string cn = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.Valor"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(cn))
            {


                conexion.Open();

                SqlCommand con = new SqlCommand("select de from historial where id_persona= " + Convert.ToInt32(clase.a), conexion);

                SqlDataReader r = con.ExecuteReader();


                historial.Load(r);


            }
            return historial;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
