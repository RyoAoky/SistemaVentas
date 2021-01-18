using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//MySqlConnection

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
            PanelMOVIMIENTOS.Dock = DockStyle.None;
            PanelREPORTEInventario.Dock = DockStyle.None;
            PaneliNVENTARIObajo.Dock = DockStyle.None;
            PanelMOVIMIENTOS.Visible = false;
            PanelREPORTEInventario.Visible = false;
            PaneliNVENTARIObajo.Visible = false;
            PanelKardex.Visible = true;
            PanelKardex.Dock = DockStyle.Fill;
            Panelv.Visible = false;
            PanelVencimientos.Visible = false;
            PanelVencimientos.Dock = DockStyle.None;

            PanelK.Visible = true;
            PanelI.Visible = false;
            PanelM.Visible = false;
            PanelR.Visible = false;
            Panelv.Visible = false;

            txtbuscarKardex_movimientos.Text = "Buscar producto";
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
                con.ConnectionString = Conexion.ConexionMaestra.Conexion();
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
                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.Message);
            }
        }

        private void MOSTRAR_Inventario_bajo_minimo()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion();
                con.Open();

                da = new SqlDataAdapter("MOSTRAR_Inventarios_bajo_minimo", con);
                
                da.Fill(dt);
                datalistadoInventarioBAJO.DataSource = dt;
                con.Close();

                datalistadoInventarioBAJO.Columns[0].Visible = false;
                datalistadoInventarioBAJO.Columns[4].Visible = false;
                datalistadoInventarioBAJO.Columns[7].Visible = false;
                datalistadoInventarioBAJO.Columns[8].Visible = false;
                datalistadoInventarioBAJO.Columns[9].Visible = false;
                

                Conexion.Tamaño_automatico_de_datatables.Multilinea(ref datalistadoInventarioBAJO);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.Message);
            }
        }
        public static int idProducto;
        private void DATALISTADO_PRODUCTOS_Movimientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtbuscarMovimiento.Text = DATALISTADO_PRODUCTOS_Movimientos.SelectedCells[2].Value.ToString();
            DATALISTADO_PRODUCTOS_Movimientos.Visible = false;
            buscar_movimientos_de_kardex();
            try
            {
                idProducto = Convert.ToInt32(DATALISTADO_PRODUCTOS_Movimientos.SelectedCells[1].Value.ToString());
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }        
        private void buscar_movimientos_de_kardex()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion();
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
                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.Message);
            }
        }
                
        private void buscar_movimientos_por_filtro_acumulado()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion();
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
                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.Message);
            }
        }

        private void buscar_movimientos_por_filtro()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion();
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
                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.Message);
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
                con.ConnectionString = Conexion.ConexionMaestra.Conexion();
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

                //Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        internal void Buscar_id_USUARIOS()
        {

            string resultado;
            string queryMoneda;
            queryMoneda = "Buscar_id_USUARIOS";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Conexion.ConexionMaestra.Conexion();

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
                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.Message);
                resultado = "";
            }
        }

        private void tver_Click(object sender, EventArgs e)
        {
            DatalistadoMovimientos.DataSource = new DataTable();
            DatalistadoMovimientosACUMULADO_PRODUCTO.DataSource = new DataTable();
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

        private void TNOTAS_Click(object sender, EventArgs e)
        {
            PanelMOVIMIENTOS.Dock = DockStyle.None;
            PanelREPORTEInventario.Dock = DockStyle.None;

            PanelMOVIMIENTOS.Visible = false;
            PanelREPORTEInventario.Visible = false;
            PaneliNVENTARIObajo.Visible = true;
            PaneliNVENTARIObajo.Dock = DockStyle.Fill;
            PanelKardex.Visible = false;
            PanelKardex.Dock = DockStyle.None;
            PanelK.Visible = false;
            PanelI.Visible = true;
            PanelM.Visible = false;
            PanelR.Visible = false;
            Panelv.Visible = false;
            PanelVencimientos.Visible = false;
            PanelVencimientos.Dock = DockStyle.None;
            Panelv.Visible = false;
            MOSTRAR_Inventario_bajo_minimo();
        }

        private void txtbuscar_inventarios_TextChanged(object sender, EventArgs e)
        {
            if(txtbuscar_inventarios.Text != "Buscar...")
            {
                mostrar_inventarios_todos();
            }
        }
        private void mostrar_inventarios_todos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion();
                con.Open();

                da = new SqlDataAdapter("mostrar_inventarios_todos", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", txtbuscar_inventarios.Text);
                da.Fill(dt);
                datalistadoInventariosReport.DataSource = dt;
                con.Close();


                datalistadoInventariosReport.Columns[0].Visible = false;
                datalistadoInventariosReport.Columns[9].Visible = false;
                datalistadoInventariosReport.Columns[10].Visible = false;

                Conexion.Tamaño_automatico_de_datatables.Multilinea(ref DatalistadoMovimientos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        internal void sumar_costo_de_inventario_CONTAR_PRODUCTOS()
        {

            string resultado;
            string queryMoneda;
            queryMoneda = "SELECT Moneda  FROM EMPRESA";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Conexion.ConexionMaestra.Conexion();
            SqlCommand comMoneda = new SqlCommand(queryMoneda, con);
            try
            {
                con.Open();
                resultado = Convert.ToString(comMoneda.ExecuteScalar()); //asignamos el valor del importe
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                resultado = "";
            }

            string importe;
            string query;
            query = "SELECT      CONVERT(NUMERIC(18,2),sum(Producto1.Precio_de_compra * Stock )) as suma FROM  Producto1 where  Usa_inventarios ='SI'";

            SqlCommand com = new SqlCommand(query, con);
            try
            {
                con.Open();
                importe = Convert.ToString(com.ExecuteScalar()); //asignamos el valor del importe
                con.Close();
                lblcostoInventario.Text = resultado + " " + importe;
            }
            catch (Exception ex)
            {
                con.Close();
                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.Message);

                lblcostoInventario.Text = resultado + " " + 0;
            }

            string conteoresultado;
            string querycontar;
            querycontar = "select count(Id_Producto1 ) from Producto1 ";
            SqlCommand comcontar = new SqlCommand(querycontar, con);
            try
            {
                con.Open();
                conteoresultado = Convert.ToString(comcontar.ExecuteScalar()); //asignamos el valor del importe
                con.Close();
                lblcantidaddeProductosEnInventario.Text = conteoresultado;
            }
            catch (Exception ex)
            {
                con.Close();
                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.Message);

                conteoresultado = "";
                lblcantidaddeProductosEnInventario.Text = "0";
            }

        }

        private void TOTROSPAGOS_Click(object sender, EventArgs e)
        {
            PanelR.Visible = true;
            PanelK.Visible = false;
            PanelI.Visible = false;
            PanelM.Visible = false;
            Panelv.Visible = false;
            PanelMOVIMIENTOS.Visible = false;
            PanelREPORTEInventario.Visible = true;
            PaneliNVENTARIObajo.Visible = false;
            PanelMOVIMIENTOS.Dock = DockStyle.None;
            PanelREPORTEInventario.Dock = DockStyle.Fill;
            PaneliNVENTARIObajo.Dock = DockStyle.None;
            PanelKardex.Visible = false;
            PanelKardex.Dock = DockStyle.None;
            PanelVencimientos.Visible = false;
            PanelVencimientos.Dock = DockStyle.None;
            Panelv.Visible = false;
            //mostrar_inventarios_todos();
            datalistadoInventariosReport.DataSource = new DataTable();
            txtbuscar_inventarios.Text = "Buscar...";
            sumar_costo_de_inventario_CONTAR_PRODUCTOS();

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            txtbuscar_inventarios.Clear();
            mostrar_inventarios_todos();
            sumar_costo_de_inventario_CONTAR_PRODUCTOS();
        }

        private void txtBuscarVencimientos_TextChanged(object sender, EventArgs e)
        {
            if(txtBuscarVencimientos.Text != "Buscar producto/Codigo")
            {                
                buscar_productos_vencidos();
                CheckPorVenceren30Dias.Checked = false;
                CheckProductosVencidos.Checked = false;
            }
        }
        private void buscar_productos_vencidos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion();
                con.Open();

                da = new SqlDataAdapter("buscar_productos_vencidos", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", txtBuscarVencimientos.Text);
                da.Fill(dt);
                datalistadoVencimientos.DataSource = dt;
                con.Close();


                datalistadoVencimientos.Columns[0].Visible = false;
                datalistadoVencimientos.Columns[1].Visible = false;
                datalistadoVencimientos.Columns[6].Visible = false;
                datalistadoVencimientos.Columns[7].Visible = false;

                Conexion.Tamaño_automatico_de_datatables.Multilinea(ref DatalistadoMovimientos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.Message);
            }
        }

        private void TVencimientos_Click(object sender, EventArgs e)
        {
            PanelR.Visible = false;
            PanelK.Visible = false;
            PanelI.Visible = false;
            PanelM.Visible = false;
            Panelv.Visible = true;
            PanelMOVIMIENTOS.Visible = false;
            PanelREPORTEInventario.Visible = false;
            PaneliNVENTARIObajo.Visible = false;
            PanelMOVIMIENTOS.Dock = DockStyle.None;
            PanelREPORTEInventario.Dock = DockStyle.None;
            PaneliNVENTARIObajo.Dock = DockStyle.None;
            PanelKardex.Visible = false;
            PanelKardex.Dock = DockStyle.None;
            PanelVencimientos.Visible = true;
            PanelVencimientos.Dock = DockStyle.Fill;
            Panelv.Visible = true;
            txtBuscarVencimientos.Text = "Buscar producto/Codigo";

            txtBuscarVencimientos.Focus();
            datalistadoVencimientos.DataSource = new DataTable();
        }

        private void txtBuscarVencimientos_Click(object sender, EventArgs e)
        {
            txtBuscarVencimientos.SelectAll();
        }

        private void mostrar_productos_vencidos_en_menos_de_30_dias()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion();
                con.Open();

                da = new SqlDataAdapter("mostrar_productos_vencidos_en_menos_de_30_dias", con);
               
                da.Fill(dt);
                datalistadoVencimientos.DataSource = dt;
                con.Close();


                datalistadoVencimientos.Columns[0].Visible = false;
                datalistadoVencimientos.Columns[1].Visible = false;

                Conexion.Tamaño_automatico_de_datatables.Multilinea(ref DatalistadoMovimientos);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        private void CheckPorVenceren30Dias_CheckedChanged(object sender, EventArgs e)
        {
            mostrar_productos_vencidos_en_menos_de_30_dias();
            txtBuscarVencimientos.Text = "Buscar producto/Codigo";
        }

        private void mostrar_productos_vencidos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion();
                con.Open();

                da = new SqlDataAdapter("mostrar_productos_vencidos", con);

                da.Fill(dt);
                datalistadoVencimientos.DataSource = dt;
                con.Close();


                datalistadoVencimientos.Columns[0].Visible = false;
                datalistadoVencimientos.Columns[1].Visible = false;
                Conexion.Tamaño_automatico_de_datatables.Multilinea(ref DatalistadoMovimientos);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        private void CheckProductosVencidos_CheckedChanged(object sender, EventArgs e)
        {
            mostrar_productos_vencidos();
            txtBuscarVencimientos.Text = "Buscar producto/Codigo";
            
        }

        private void TKardex_Click(object sender, EventArgs e)
        {
            PanelMOVIMIENTOS.Dock = DockStyle.None;
            PanelREPORTEInventario.Dock = DockStyle.None;
            PaneliNVENTARIObajo.Dock = DockStyle.None;
            PanelMOVIMIENTOS.Visible = false;
            PanelREPORTEInventario.Visible = false;
            PaneliNVENTARIObajo.Visible = false;
            PanelKardex.Visible = true;
            PanelKardex.Dock = DockStyle.Fill;
            Panelv.Visible = false;
            PanelVencimientos.Visible = false;
            PanelVencimientos.Dock = DockStyle.None;

            PanelK.Visible = true;
            PanelI.Visible = false;
            PanelM.Visible = false;
            PanelR.Visible = false;
            Panelv.Visible = false;

            txtbuscarKardex_movimientos.Text = "Buscar producto";
        }

        private void TMOVIMIENTOS_Click(object sender, EventArgs e)
        {
            PanelMOVIMIENTOS.Dock = DockStyle.Fill;
            PanelREPORTEInventario.Dock = DockStyle.None;
            PaneliNVENTARIObajo.Dock = DockStyle.None;
            PanelMOVIMIENTOS.Visible = true;
            PanelREPORTEInventario.Visible = false;
            PaneliNVENTARIObajo.Visible = false;
            PanelKardex.Visible = false;
            PanelKardex.Dock = DockStyle.None;
            Panelv.Visible = false;
            PanelVencimientos.Visible = false;
            PanelVencimientos.Dock = DockStyle.None;
            panel7.Dock = DockStyle.Right;

            PanelK.Visible = false;
            PanelI.Visible = false;
            PanelM.Visible = true;
            PanelR.Visible = false;
            Panelv.Visible = false;

            buscar_productos_movimientos();
            buscar_usuario();
            Buscar_id_USUARIOS();

            txtbuscarKardex_movimientos.Text = "Buscar producto";
            DatalistadoMovimientos.DataSource = new DataTable();
            DatalistadoMovimientosACUMULADO_PRODUCTO.DataSource = new DataTable();
            txtIdusuario = new ComboBox();
        }

        private void txtbuscarKardex_movimientos_TextChanged(object sender, EventArgs e)
        {
            if(txtbuscarKardex_movimientos.Text == "Buscar producto" | txtbuscarKardex_movimientos.Text == "")
            {
                datalistadoBusquedaKardex.Visible = false;
            }
            else
            {
                datalistadoBusquedaKardex.Visible = true;
                buscar_productos_kardex();
                
            }
        }

        private void buscar_productos_kardex()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion();
                con.Open();

                da = new SqlDataAdapter("BUSCAR_PRODUCTOS_KARDEX", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letrab", txtbuscarKardex_movimientos.Text);
                da.Fill(dt);
                datalistadoBusquedaKardex.DataSource = dt;
                con.Close();


                datalistadoBusquedaKardex.Columns[1].Visible = false;
                //datalistadoBusquedaKardex.Columns[2].Visible = false;
                datalistadoBusquedaKardex.Columns[3].Visible = false;
                datalistadoBusquedaKardex.Columns[4].Visible = false;
                datalistadoBusquedaKardex.Columns[5].Visible = false;
                datalistadoBusquedaKardex.Columns[6].Visible = false;
                datalistadoBusquedaKardex.Columns[7].Visible = false;
                datalistadoBusquedaKardex.Columns[8].Visible = false;
                datalistadoBusquedaKardex.Columns[9].Visible = false;
                datalistadoBusquedaKardex.Columns[10].Visible = false;
                datalistadoBusquedaKardex.Columns[11].Visible = false;
                datalistadoBusquedaKardex.Columns[12].Visible = false;
                datalistadoBusquedaKardex.Columns[13].Visible = false;
                datalistadoBusquedaKardex.Columns[14].Visible = false;
                datalistadoBusquedaKardex.Columns[15].Visible = false;
                datalistadoBusquedaKardex.Columns[16].Visible = false;

                Conexion.Tamaño_automatico_de_datatables.Multilinea(ref datalistadoBusquedaKardex);

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        
        Reportes.Reportes_de_Kardex.Reporte_de_Kardex_diseño.ReportKardex_Movimiento rptFREPORT2 = new Reportes.Reportes_de_Kardex.Reporte_de_Kardex_diseño.ReportKardex_Movimiento();
        private void mostrar_Kardex_movimiento()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion();
                con.Open();

                da = new SqlDataAdapter("MOSTRAR_MOVIMIENTOS_DE_KARDEX", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idProducto", datalistadoBusquedaKardex.SelectedCells[1].Value.ToString());
                da.Fill(dt);
                con.Close();
                rptFREPORT2 = new Reportes.Reportes_de_Kardex.Reporte_de_Kardex_diseño.ReportKardex_Movimiento();
                rptFREPORT2.DataSource = dt;
                rptFREPORT2.table1.DataSource = dt;
                reportViewer1.Report = rptFREPORT2;
                reportViewer1.RefreshReport();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.Message);
            }
        }

        private void datalistadoBusquedaKardex_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtbuscarKardex_movimientos.Text = datalistadoBusquedaKardex.SelectedCells[2].Value.ToString();
            datalistadoBusquedaKardex.Visible = false;
            mostrar_Kardex_movimiento();
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MODULOS.Reportes.Reportes_de_Kardex.Reporte_de_inventarios_todos.FormMovimientoBuscar frm = new MODULOS.Reportes.Reportes_de_Kardex.Reporte_de_inventarios_todos.FormMovimientoBuscar();
            frm.ShowDialog();
        }

        private void txtIdusuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public static string Tipo_de_Movimiento;
        public static DateTime Fecha;
        public static int id_Usuario;
        private void ToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            try
            {
                Tipo_de_Movimiento = txtTipoMovi.Text;
                Fecha = txtfechaM.Value;
                id_Usuario = Convert.ToInt32(txtIdusuario.Text);
                MODULOS.Reportes.Reportes_de_Kardex.Reporte_de_inventarios_todos.FormReporteMovimientoFILTROS frm = new MODULOS.Reportes.Reportes_de_Kardex.Reporte_de_inventarios_todos.FormReporteMovimientoFILTROS();
                frm.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error,no se encontro datos con los parametros seleccionados, intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
