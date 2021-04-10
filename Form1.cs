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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Class1 clase = new Class1();

        public int prestamoid;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = lista();
        }

        private DataTable lista()
        {

            DataTable prestamos = new DataTable();

            string cn = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.Valor"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(cn))
            {


                conexion.Open();

                SqlCommand con = new SqlCommand("select id_prestamo as IDP, persona_id as ID, cantidad as Cantidad from prestamos where estado = 2", conexion);

                SqlDataReader r = con.ExecuteReader();


                prestamos.Load(r);


            }
            return prestamos;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            crearusu cu = new crearusu();
            cu.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
           
        }

        //continuar esto y arreglar para que tome otros datos de prestamo
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                prestamoid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["IDP"].FormattedValue.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // update prestamos set estado = 0 where id_prestamo = 0;

            try
            {
                string cn = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.Valor"].ConnectionString;

                using (SqlConnection conexion = new SqlConnection(cn))
                {


                    conexion.Open();

                    SqlCommand con = new SqlCommand("update prestamos set estado = 0 where id_prestamo =" + prestamoid, conexion);

                    int mod = con.ExecuteNonQuery();

                    
                        if (mod == 1)
                    {
                        MessageBox.Show("Se Valido correctamente.");

                        dataGridView1.DataSource = lista();


                    }
                    else
                    {
                        MessageBox.Show("Seleccione una fila");
                    }
                }
            }

            catch (SqlException er)
            {
                MessageBox.Show(Convert.ToString(er));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Hide();
            login l = new login();
            l.Show();
                
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string cn = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.Valor"].ConnectionString;

                using (SqlConnection conexion = new SqlConnection(cn))
                {


                    conexion.Open();

                    SqlCommand con = new SqlCommand("delete prestamos where id_prestamo =" + prestamoid, conexion);

                    int mod = con.ExecuteNonQuery();


                    if (mod == 1)
                    {
                        MessageBox.Show("Se Cancelo correctamente.");
                        dataGridView1.DataSource = lista();
                    }
                    else
                    {
                        MessageBox.Show("Seleccione una fila.");
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
