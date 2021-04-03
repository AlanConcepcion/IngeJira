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
    public partial class Deudas : Form
    {
        public Deudas()
        {
            InitializeComponent();
        }

        public string cantidad;

        public int prestamoid;

        Class1 clase = new Class1();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu me = new menu();
            me.Show();
        }

        private DataTable lista()
        {

            DataTable pagar = new DataTable();

            string cn = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.Valor"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(cn))
            {


                conexion.Open();

                SqlCommand con = new SqlCommand("select id_prestamo as IDP, persona_id as ID, cantidad as Cantidad, fecha as Fecha, fecha_lim as Limite from prestamos where persona_id=  " + Convert.ToInt32(clase.a) + "and fecha_lim <= GETDATE()", conexion);

                SqlDataReader r = con.ExecuteReader();


                pagar.Load(r);


            }
            return pagar;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cn = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.Valor"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(cn))
            {

                if (dataGridView1.SelectedRows.Count != 1)
                {
                    conexion.Open();

                    SqlCommand con = new SqlCommand("insert into historial(de, id_persona) values ('Pago la deuda de: " + cantidad + "$ el dia " + dateTimePicker1.Value.ToString() + "', " + Convert.ToInt32(clase.a) + ")", conexion);
                    SqlCommand delete = new SqlCommand("delete prestamos where persona_id ="+ Convert.ToInt32(clase.a) + "and id_prestamo = " + prestamoid, conexion);
                    int query = con.ExecuteNonQuery();
                    int query2 = delete.ExecuteNonQuery();

                    if (query != 0 || query2 != 0)
                    {
                        MessageBox.Show("Se realizo el pago correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }


                }
                else
                {
                    MessageBox.Show("Seleccione una fila.");
                }
            }
        }

        private void Deudas_Load(object sender, EventArgs e)
        {
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            dataGridView1.DataSource = lista();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;

                cantidad = dataGridView1.Rows[e.RowIndex].Cells["Cantidad"].FormattedValue.ToString();
                prestamoid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["IDP"].FormattedValue.ToString());
            }
        }
    }
}
