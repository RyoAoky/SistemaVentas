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
    public partial class Apertura_de_Caja : Form
    {
        public Apertura_de_Caja()
        {
            InitializeComponent();
           
        }

        private void Apertura_de_Caja_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CO");
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ",";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ",";
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
                    Console.WriteLine(ex.Message);
                }
            }

        }
        private void btnIniciar_Apertura_Click(object sender, EventArgs e)
        {
            try
            {
                
                
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion();
                con.Open();
                SqlCommand da = new SqlCommand();
                da = new SqlCommand("editar_dinero_caja_principal", con);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@idCaja", txtidcaja.Text);
                da.Parameters.AddWithValue("@saldo", txtmonto.Text);
                da.ExecuteNonQuery();
                con.Close();

                this.Hide();
                Ventas_Menu_Principal.Ventas_Menu_Principal_OK frm = new Ventas_Menu_Principal.Ventas_Menu_Principal_OK();
                frm.ShowDialog();
                this.Hide();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        private void MOSTRAR_CAJA_POR_SERIAL()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion();
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
                Console.WriteLine(ex.Message);

            }


        }

        private void btnOmitir_Apertura_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt1 = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion();
                con.Open();

                da = new SqlDataAdapter("editar_dinero_caja_principal", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idCaja", txtidcaja.Text);
                da.SelectCommand.Parameters.AddWithValue("@saldo", 0);

                this.Hide();
                Ventas_Menu_Principal.Ventas_Menu_Principal_OK frm = new Ventas_Menu_Principal.Ventas_Menu_Principal_OK();
                frm.ShowDialog();
                this.Hide();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
    }
}
