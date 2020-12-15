using Sistema_Ventas_MrTec.MODULOS.Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sistema_Ventas_MrTec.MODULOS.Ventas_Menu_Principal
{
    public partial class Ventas_Menu_Principal_OK : Form
    {
        public Ventas_Menu_Principal_OK()
        {
            InitializeComponent();
        }

        private void BtnCerrar_turno_Click(object sender, EventArgs e)
        {
            Caja.Cierre_de_Caja frm = new Caja.Cierre_de_Caja();
            frm.ShowDialog();
        }

        private void ToolStripButton22_Click(object sender, EventArgs e)
        {
            Productos.ProductoOK frm = new Productos.ProductoOK();
            frm.ShowDialog();
        }
    }
}
