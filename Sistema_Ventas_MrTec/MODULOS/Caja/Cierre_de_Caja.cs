using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Management;

namespace Sistema_Ventas_MrTec.MODULOS.Caja
{
    public partial class Cierre_de_Caja : Form
    {
        public Cierre_de_Caja()
        {

            InitializeComponent();
        }
        private void Cierre_de_Caja_Load(object sender, EventArgs e)
        {
            ManagementObjectSearcher MOS = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
            foreach (ManagementObject getserial in MOS.Get())
            {
                lblSerialPc.Text = getserial.Properties["SerialNumber"].Value.ToString();
                MOSTRAR_CAJA_POR_SERIAL();
                try
                {
                    txtidcaja.Text = datalistado_caja.SelectedCells[1].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                SqlConnection con = new SqlConnection();
                //con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("cerrar_caja", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //DateTime date = new DateTime();
                //int idCaja1 = Int16.Parse( txtidcaja.Text);
                cmd.Parameters.AddWithValue("@idcaja", txtidcaja.Text);
                cmd.Parameters.AddWithValue("@fechafin", txtfechacierre.Value);
                cmd.Parameters.AddWithValue("@fechacierre", txtfechacierre.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                Application.Exit();
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MOSTRAR_CAJA_POR_SERIAL()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                //con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                con.Open();

                da = new SqlDataAdapter("mostrar_cajas_por_Serial_de_DiscoDuro", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Serial", lblSerialPc.Text);
                da.Fill(dt);
                datalistado_caja.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }
    }
}
