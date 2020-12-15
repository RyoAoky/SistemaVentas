using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sistema_Ventas_MrTec.MODULOS.Productos
{
    public partial class ProductoOK : Form
    {
        int txtcontador;
        int txtcontadorGrupo;
        public ProductoOK()
        {
            InitializeComponent();
        }
        private void ProductoOK_Load(object sender, EventArgs e)
        {
            PANELREGISTRO.Visible = false;
        }
        private void PictureBox2_Click(object sender, EventArgs e)
        {
            PANELREGISTRO.Visible = true;
            CheckInventarios.Checked = true;
            PANELINVENTARIO.Visible = true;
            PanelGRUPOSSELECT.Visible = false;
            btnGuardar_grupo.Visible = false;
            BtnGuardarCambios.Visible = false;
            BtnCancelar.Visible = false;
            btnNuevoGrupo.Visible = true;
            mostrar_grupos();
            txtgrupo.Clear();

            lblEstadoCodigo.Text = "NUEVO";
            PanelGRUPOSSELECT.Visible = true;
            btnGuardar_grupo.Visible = false;
            BtnGuardarCambios.Visible = false;
            BtnCancelar.Visible = false;
            btnNuevoGrupo.Visible = true;
            mostrar_grupos();

            txtapartirde.Text = "0";
            txtstock2.ReadOnly = false;
            Panel25.Enabled = true;
            Panel21.Visible = false;
            Panel22.Visible = false;
            Panel18.Visible = false;
            txtidproducto.Text = "0";

            PANELINVENTARIO.Visible = true;

            txtdescripcion.AutoCompleteCustomSource = Conexion.DataHelper.LoadAutoComplete();
            txtdescripcion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtdescripcion.AutoCompleteSource = AutoCompleteSource.CustomSource;

            PANELREGISTRO.Visible = true;
            porunidad.Checked = true;
            No_aplica_fecha.Checked = false;
            Panel6.Visible = false;

            LIMPIAR();
            btnagregaryguardar.Visible = true;
            btnagregar.Visible = false;


            txtdescripcion.Text = "";
            PANELINVENTARIO.Visible = true;


            TGUARDAR.Visible = true;
            TGUARDARCAMBIOS.Visible = false;
        }

        internal void LIMPIAR()
        {
            txtidproducto.Text = "";
            txtdescripcion.Text = "";
            txtcosto.Text = "0";
            TXTPRECIODEVENTA2.Text = "0";
            txtpreciomayoreo.Text = "0";
            txtgrupo.Text = "";

            agranel.Checked = false;
            txtstockminimo.Text = "0";
            txtstock2.Text = "0";
            lblEstadoCodigo.Text = "NUEVO";
        }

        
        private void mostrar_grupos()
        {
            PanelGRUPOSSELECT.Visible = true;
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                con.Open();

                da = new SqlDataAdapter("mostrar_grupos", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@buscar", txtgrupo.Text);
                da.Fill(dt);
                datalistadoGrupos.DataSource = dt;
                con.Close();

                datalistadoGrupos.DataSource = dt;
                datalistadoGrupos.Columns[2].Visible = false;
                datalistadoGrupos.Columns[3].Width = 500;
                contarGrupo();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Conexion.Tamaño_automatico_de_datatables.Multilinea(ref datalistado);
        }
        private void btnGuardar_grupo_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand("insertar_Grupo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Grupo", txtgrupo.Text);
                cmd.Parameters.AddWithValue("@Por_defecto", "NO");
                cmd.ExecuteNonQuery();
                con.Close();
                mostrar_grupos();
                lblIdGrupo.Text = datalistadoGrupos.SelectedCells[2].Value.ToString();
                txtgrupo.Text = datalistadoGrupos.SelectedCells[3].Value.ToString();

                PanelGRUPOSSELECT.Visible = false;
                btnGuardar_grupo.Visible = false;
                BtnGuardarCambios.Visible = false;
                BtnCancelar.Visible = false;
                btnNuevoGrupo.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnNuevoGrupo_Click(object sender, EventArgs e)
        {
            txtgrupo.Text = "Escribe el Nuevo Grupo";
            txtgrupo.SelectAll();
            txtgrupo.Focus();

            PanelGRUPOSSELECT.Visible = false;
            btnGuardar_grupo.Visible = true;
            BtnGuardarCambios.Visible = false;
            BtnCancelar.Visible = true;
            btnNuevoGrupo.Visible = false;
        }

        private void txtgrupo_TextChanged(object sender, EventArgs e)
        {
            contarGrupo();
            mostrar_grupos();
            if (txtcontadorGrupo == 0)
            {
                PanelGRUPOSSELECT.Visible = false;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            PanelGRUPOSSELECT.Visible = false;
            btnGuardar_grupo.Visible = false;
            BtnGuardarCambios.Visible = false;
            BtnCancelar.Visible = false;
            btnNuevoGrupo.Visible = true;
            txtgrupo.Clear();
            mostrar_grupos();
        }

        private void TGUARDAR_Click(object sender, EventArgs e)
        {

        }

        private void TGUARDARCAMBIOS_Click(object sender, EventArgs e)
        {

        }

        private void insertar_productos()
        {
            if (txtpreciomayoreo.Text == "0" | txtpreciomayoreo.Text == "") txtapartirde.Text = "0";

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_Producto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Descripcion", txtdescripcion.Text);
                cmd.Parameters.AddWithValue("@Imagen", ".");
                cmd.Parameters.AddWithValue("@Precio_de_compra", txtcosto.Text);
                cmd.Parameters.AddWithValue("@Precio_de_venta", TXTPRECIODEVENTA2.Text);
                cmd.Parameters.AddWithValue("@Codigo", txtcodigodebarras.Text);
                cmd.Parameters.AddWithValue("@A_partir_de", txtapartirde.Text);
                cmd.Parameters.AddWithValue("@Impuesto", 0);
                cmd.Parameters.AddWithValue("@Precio_mayoreo", txtpreciomayoreo.Text);
                if (porunidad.Checked == true) txtse_vende_a.Text = "Unidad";
                if (agranel.Checked == true) txtse_vende_a.Text = "Granel";

                cmd.Parameters.AddWithValue("@Se_vende_a", txtse_vende_a.Text);
                cmd.Parameters.AddWithValue("@Id_grupo", lblIdGrupo.Text);
                if (PANELINVENTARIO.Visible == true)
                {
                    cmd.Parameters.AddWithValue("@Usa_inventarios", "SI");
                    cmd.Parameters.AddWithValue("@Stock_minimo", txtstockminimo.Text);
                    cmd.Parameters.AddWithValue("@Stock", txtstock2.Text);

                    if (No_aplica_fecha.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@Fecha_de_vencimiento", "NO APLICA");
                    }

                    if (No_aplica_fecha.Checked == false)
                    {
                        cmd.Parameters.AddWithValue("@Fecha_de_vencimiento", txtfechaoka.Text);
                    }


                }
                if (PANELINVENTARIO.Visible == false)
                {
                    cmd.Parameters.AddWithValue("@Usa_inventarios", "NO");
                    cmd.Parameters.AddWithValue("@Stock_minimo", 0);
                    cmd.Parameters.AddWithValue("@Fecha_de_vencimiento", "NO APLICA");
                    cmd.Parameters.AddWithValue("@Stock", "Ilimitado");

                }
                cmd.Parameters.AddWithValue("@Fecha", DateTime.Today);
                cmd.Parameters.AddWithValue("@Motivo", "Registro inicial de Producto");
                cmd.Parameters.AddWithValue("@Cantidad ", txtstock2.Text);
                cmd.Parameters.AddWithValue("@Id_usuario", MODULOS.Login.idusuariovariable);
                cmd.Parameters.AddWithValue("@Tipo", "ENTRADA");
                cmd.Parameters.AddWithValue("@Estado", "CONFIRMADO");
                cmd.Parameters.AddWithValue("@Id_caja", MODULOS.Login.idcajavariable);

                cmd.ExecuteNonQuery();

                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void datalistadoGrupos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == this.datalistadoGrupos.Columns["EliminarG"].Index)
            {
                DialogResult result;
                result = MessageBox.Show("¿Realmente deseas eliminar este Grupo?", "Eliminar Grupo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    SqlCommand cmd;
                    try
                    {
                        foreach (DataGridViewRow row in datalistadoGrupos.SelectedRows)
                        {
                            int onekey = Convert.ToInt32(row.Cells["idLine"].Value);
                            try
                            {
                                try
                                {
                                    SqlConnection con = new SqlConnection();
                                    con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                                    con.Open();
                                    cmd = new SqlCommand("eliminar_grupo", con);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@id", onekey);
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }catch(Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        txtgrupo.Text = "GENERAL";
                        mostrar_grupos();
                        lblIdGrupo.Text = datalistadoGrupos.SelectedCells[2].Value.ToString();
                        PanelGRUPOSSELECT.Visible = true;
                    }catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            if(e.ColumnIndex == this.datalistadoGrupos.Columns["EditarG"].Index)
            {
                lblIdGrupo.Text = datalistadoGrupos.SelectedCells[2].Value.ToString();
                txtgrupo.Text = datalistadoGrupos.SelectedCells[3].Value.ToString();
                PanelGRUPOSSELECT.Visible = false;
                btnGuardar_grupo.Visible = false;
                BtnGuardarCambios.Visible = false;
                BtnCancelar.Visible = true;
                btnNuevoGrupo.Visible = false;
            }
            if(e.ColumnIndex == this.datalistadoGrupos.Columns["Grupo"].Index)
            {
                lblIdGrupo.Text = datalistadoGrupos.SelectedCells[2].Value.ToString();
                txtgrupo.Text = datalistadoGrupos.SelectedCells[3].Value.ToString();
                PanelGRUPOSSELECT.Visible = false;
                btnGuardar_grupo.Visible = false;
                BtnGuardarCambios.Visible = false;
                BtnCancelar.Visible = false;
                btnNuevoGrupo.Visible = true;
                if (lblEstadoCodigo.Text == "NUEVO")
                {
                    Generar_codigo_de_barras_automatico();
                }
            }
            
            
        }

        private void Generar_codigo_de_barras_automatico()
        {
            Double resultado;
            string queryMoneda;
            queryMoneda = "SELECT max(Id_Producto1) FROM Producto1";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Conexion.ConexionMaestra.Conexion;
            SqlCommand conMoneda = new SqlCommand(queryMoneda, con);
            try
            {
                con.Open();
                resultado = Convert.ToDouble(conMoneda.ExecuteScalar()) + 1;
                con.Close();
            }catch(Exception ex)
            {
                resultado = 1;
                Console.WriteLine(ex.Message);
            }
            string Cadena = txtgrupo.Text;
            string[] Palabra;
            String espacio = " ";
            Palabra = Cadena.Split(Convert.ToChar(espacio));
            try
            {
                txtcodigodebarras.Text = resultado + Palabra[0].Substring(0,2) + "MRTEC";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void txtdescripcion_TextChanged(object sender, EventArgs e)
        {
            mostrar_descripcion_produco_sin_repetir();
            contar();

            if (txtcontador == 0)
            {
                DATALISTADO_PRODUCTOS_OKA.Visible = false;
            }
            if(txtcontador > 0)
            {
                DATALISTADO_PRODUCTOS_OKA.Visible = false;
            }
            if (TGUARDAR.Visible == false)
            {
                DATALISTADO_PRODUCTOS_OKA.Visible = false;
            }
            
        }

        private void contar()
        {
            int x;
            x = DATALISTADO_PRODUCTOS_OKA.Rows.Count;
            txtcontador = (x);
            
        }
        private void contarGrupo()
        {
            int x;
            x = datalistadoGrupos.Rows.Count;
            txtcontadorGrupo = (x);

        }
        private void mostrar_descripcion_produco_sin_repetir()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                con.Open();

                da = new SqlDataAdapter("mostrar_descripcion_producto_sin_repetir", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@buscar", txtdescripcion.Text);
                da.Fill(dt);
                DATALISTADO_PRODUCTOS_OKA.DataSource = dt;
                con.Close();

                datalistado.Columns[1].Width = 500;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }



        }

        private void DATALISTADO_PRODUCTOS_OKA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtdescripcion.Text = DATALISTADO_PRODUCTOS_OKA.SelectedCells[1].Value.ToString();
                DATALISTADO_PRODUCTOS_OKA.Visible = false;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenerarCodigo_Click(object sender, EventArgs e)
        {
            Generar_codigo_de_barras_automatico();
        }

        private void txtPorcentajeGanancia_TextChanged(object sender, EventArgs e)
        {
            TimerCalucular_porcentaje_ganancia.Stop();

            TimerCalcular_precio_venta.Start();
            TimerCalucular_porcentaje_ganancia.Stop();
        }

        private void TimerCalucular_porcentaje_ganancia_Tick(object sender, EventArgs e)
        {
            TimerCalucular_porcentaje_ganancia.Stop();
            try
            {
                double totalVentavariadouble;
                double txtprecioventa2v = Convert.ToDouble(TXTPRECIODEVENTA2.Text);
                double txtcostov = Convert.ToDouble(txtcosto.Text);
                totalVentavariadouble = ((txtprecioventa2v - txtcostov) / (txtcostov)) * 100;
                if(totalVentavariadouble > 0)
                {
                    this.txtPorcentajeGanancia.Text = Convert.ToString(totalVentavariadouble);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void TimerCalcular_precio_venta_Tick(object sender, EventArgs e)
        {
            TimerCalcular_precio_venta.Stop();
            try
            {
                double totalVentavariadouble;
                double txtcostov = Convert.ToDouble(txtcosto.Text);
                double txtporcentajeGananciav = Convert.ToDouble(txtPorcentajeGanancia.Text);
                totalVentavariadouble = txtcostov + ((txtcostov + txtporcentajeGananciav) / 100);
                if (totalVentavariadouble > 0 & txtPorcentajeGanancia.Focused == true)
                {
                    this.TXTPRECIODEVENTA2.Text = Convert.ToString(totalVentavariadouble);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void datalistado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.datalistado.Columns["Eliminar"].Index)
            {
                DialogResult result;
                result = MessageBox.Show("¿Realmente desea eliminar este Producto?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    SqlCommand cmd;
                    try
                    {
                        foreach (DataGridViewRow row in datalistado.SelectedRows)
                        {
                            int onekey = Convert.ToInt32(row.Cells["Id_Producto1"].Value);
                            try
                            {
                                try
                                {
                                    SqlConnection con = new SqlConnection();
                                    con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                                    con.Open();
                                    cmd = new SqlCommand("eliminar_Producto1", con);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@id", onekey);
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        //buscar();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            if (e.ColumnIndex == this.datalistado.Columns["Editar"].Index)
            {
                proceso_para_obtener_datos_de_productos();
            }
        }

        private void proceso_para_obtener_datos_de_productos()
        {
            try
            {

                Panel25.Enabled = true;
                DATALISTADO_PRODUCTOS_OKA.Visible = false;

                Panel6.Visible = false;
                TGUARDAR.Visible = false;
                TGUARDARCAMBIOS.Visible = true;
                PANELREGISTRO.Visible = true;


                btnNuevoGrupo.Visible = true;
                txtid_productooka.Text = datalistado.SelectedCells[2].Value.ToString();
                lblEstadoCodigo.Text = "EDITAR";
                PanelGRUPOSSELECT.Visible = false;
                BtnGuardarCambios.Visible = false;
                btnGuardar_grupo.Visible = false;
                BtnCancelar.Visible = false;
                btnNuevoGrupo.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
