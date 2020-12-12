using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sistema_Ventas_MrTec.MODULOS.Caja
{
    public partial class Cierre_de_Caja : Form
    {
        public Cierre_de_Caja()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("cerrar_caja", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcaja", txtidcaja.Text);
                cmd.Parameters.AddWithValue("@fechafin", txtfechacierre.Value);
                cmd.Parameters.AddWithValue("@fechacierre", txtfechacierre.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                Application.Exit();
                Application.Run();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
