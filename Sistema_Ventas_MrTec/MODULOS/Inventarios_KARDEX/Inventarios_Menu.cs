using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sistema_Ventas_MrTec.MODULOS.Inventarios_KARDEX
{
    public partial class Inventarios_Menu : Form
    {
        public Inventarios_Menu()
        {
            InitializeComponent();
        }

        private void Inventarios_Menu_Load(object sender, EventArgs e)
        {
            buscar_usuario();
        }

        private void txtbuscarMovimiento_TextChanged(object sender, EventArgs e)
        {
            if(txtbuscarMovimiento.Text=="Buscar producto" | txtbuscarMovimiento.Text == "")
            {
                DATALISTADO_PRODUCTOS_Movimientos.Visible = false;
            }
            else
            {
                DATALISTADO_PRODUCTOS_Movimientos.Visible = true;
                buscar_productos_movimientos();
            }
        }

        private void buscar_productos_movimientos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                con.Open();

                da = new SqlDataAdapter("BUSCAR_PRODUCTOS_KARDEX", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letrab", txtbuscarMovimiento.Text);
                da.Fill(dt);
                DATALISTADO_PRODUCTOS_Movimientos.DataSource = dt;
                con.Close();


                DATALISTADO_PRODUCTOS_Movimientos.Columns[1].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[3].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[4].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[5].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[6].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[7].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[8].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[9].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[10].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[11].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[12].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[13].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[14].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[15].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[16].Visible = false;

                Conexion.Tamaño_automatico_de_datatables.Multilinea(ref DATALISTADO_PRODUCTOS_Movimientos);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DATALISTADO_PRODUCTOS_Movimientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtbuscarMovimiento.Text = DATALISTADO_PRODUCTOS_Movimientos.SelectedCells[2].Value.ToString();
            DATALISTADO_PRODUCTOS_Movimientos.Visible = false;
            buscar_movimientos_de_kardex();
        }

        private void buscar_movimientos_de_kardex()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                con.Open();

                da = new SqlDataAdapter("buscar_MOVIMIENTOS_DE_KARDEX", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idProducto", DATALISTADO_PRODUCTOS_Movimientos.SelectedCells[1].Value.ToString());
                da.Fill(dt);
                DatalistadoMovimientos.DataSource = dt;
                con.Close();


                DatalistadoMovimientos.Columns[0].Visible = false;
                DatalistadoMovimientos.Columns[10].Visible = false;
                DatalistadoMovimientos.Columns[11].Visible = false;
                Conexion.Tamaño_automatico_de_datatables.Multilinea(ref DatalistadoMovimientos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
                
        private void buscar_movimientos_por_filtro_acumulado()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                con.Open();

                da = new SqlDataAdapter("buscar_MOVIMIENTOS_DE_KARDEX_filtros_acumulado", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fecha", txtfechaM.Value);
                da.SelectCommand.Parameters.AddWithValue("@tipo", txtTipoMovi.Text);
                da.SelectCommand.Parameters.AddWithValue("@Id_usuario", txtIdusuario.Text);


                da.Fill(dt);
                DatalistadoMovimientosACUMULADO_PRODUCTO.DataSource = dt;
                con.Close();


                DatalistadoMovimientosACUMULADO_PRODUCTO.Columns[4].Visible = false;
                DatalistadoMovimientosACUMULADO_PRODUCTO.Columns[5].Visible = false;
                DatalistadoMovimientosACUMULADO_PRODUCTO.Columns[6].Visible = false;

                Conexion.Tamaño_automatico_de_datatables.Multilinea(ref DatalistadoMovimientosACUMULADO_PRODUCTO);
                DataGridViewCellStyle styCabeceras = new DataGridViewCellStyle();
                styCabeceras.BackColor = System.Drawing.Color.FromArgb(26, 115, 232);
                styCabeceras.ForeColor = System.Drawing.Color.White;
                styCabeceras.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                DatalistadoMovimientosACUMULADO_PRODUCTO.ColumnHeadersDefaultCellStyle = styCabeceras;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buscar_movimientos_por_filtro()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                con.Open();

                da = new SqlDataAdapter("buscar_MOVIMIENTOS_DE_KARDEX_filtros", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fecha", txtfechaM.Value);
                da.SelectCommand.Parameters.AddWithValue("@tipo", txtTipoMovi.Text);
                da.SelectCommand.Parameters.AddWithValue("@Id_usuario", txtIdusuario.Text);


                da.Fill(dt);
                DatalistadoMovimientos.DataSource = dt;
                con.Close();


                DatalistadoMovimientos.Columns[0].Visible = false;
                DatalistadoMovimientos.Columns[10].Visible = false;
                DatalistadoMovimientos.Columns[11].Visible = false;

                DatalistadoMovimientos.Columns[9].Visible = false;
                DatalistadoMovimientos.Columns[13].Visible = false;
                DatalistadoMovimientos.Columns[14].Visible = false;
                DatalistadoMovimientos.Columns[12].Visible = false;
                Conexion.Tamaño_automatico_de_datatables.Multilinea(ref DatalistadoMovimientos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
           

            groupBox1.Visible = true;
            DATALISTADO_PRODUCTOS_Movimientos.Visible = false;
            txtTipoMovi.Text = "-Todos-";
            buscar_movimientos_por_filtro();
            buscar_movimientos_por_filtro_acumulado();
            panel7.Visible = true;
            MenuStrip2.Visible = false;
            menuStrip7.Visible = false;
        }

        private void txtUSUARIOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (groupBox1.Visible == true)
            {
                Buscar_id_USUARIOS();
                buscar_movimientos_por_filtro();
                buscar_movimientos_por_filtro_acumulado();
            }
        }

        private void buscar_usuario()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                con.Open();

                da = new SqlDataAdapter("select*from USUARIO2", con);

                da.Fill(dt);
                txtUSUARIOS.DisplayMember = "Nombres_y_Apellidos";
                txtUSUARIOS.ValueMember = "idUsuario";

                txtUSUARIOS.DataSource = dt;
                //txtIdusuario.Text = txtUSUARIOS.ValueMember;

                con.Close();
                Buscar_id_USUARIOS();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        internal void Buscar_id_USUARIOS()
        {

            string resultado;
            string queryMoneda;
            queryMoneda = "Buscar_id_USUARIOS";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Conexion.ConexionMaestra.Conexion;

            SqlCommand comMoneda = new SqlCommand(queryMoneda, con);
            comMoneda.CommandType = CommandType.StoredProcedure;
            comMoneda.Parameters.AddWithValue("@Nombre_y_Apelllidos", txtUSUARIOS.Text);
            try
            {
                con.Open();
                resultado = Convert.ToString(comMoneda.ExecuteScalar()); //asignamos el valor del importe
                txtIdusuario.Text = resultado;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                resultado = "";
            }
        }

        private void tver_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
            groupBox1.Visible = false;
            buscar_movimientos_de_kardex();
            txtTipoMovi.Text = "-Todos-";
            txtbuscarMovimiento.Text = "Buscar producto";
            MenuStrip2.Visible = true;
            MenuStrip6.Visible = true;
        }

        private void txtfechaM_ValueChanged(object sender, EventArgs e)
        {
            if (groupBox1.Visible == true)
            {
                buscar_movimientos_por_filtro();
                buscar_movimientos_por_filtro_acumulado();
            }
        }

        private void txtTipoMovi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (groupBox1.Visible == true)
            {
                buscar_movimientos_por_filtro();
                buscar_movimientos_por_filtro_acumulado();
            }
        }
    }
}
