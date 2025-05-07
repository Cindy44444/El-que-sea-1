using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace El_que_sea_1
{
    public partial class Form1 : Form
    {
        aCCIONES acc = new aCCIONES();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            dgDATOS.DataSource = acc.Mostrar();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
           if (acc.ExportaraExcel())
            {
                MessageBox.Show("Exportado con exito...");
            }
            else
            {
                MessageBox.Show("Fallo al exportado...");
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            if (acc.ImportarArchivo())
            {
                MessageBox.Show("Importando...");
            }
            else
            {
                MessageBox.Show("Error...");
            }
        }
    }
}
