﻿using System;
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
    public partial class Editar : Form
    {
        public Editar()
        {
           

            InitializeComponent();
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
    }
}
