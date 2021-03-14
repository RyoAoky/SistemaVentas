using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Ventas_MrTec.MODULOS.Asistente_de_Inicio
{
    public partial class Registro_de_Empresa : Form
    {
        public Registro_de_Empresa()
        {
            InitializeComponent();
        }

        private void Registro_de_Empresa_Load(object sender, EventArgs e)
        {
            
            txtempresa.Focus();
            try
            {
                ManagementObjectSearcher MOS = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
                foreach (ManagementObject getserial in MOS.Get())
                {
                    lblIDSERIAL.Text = getserial.Properties["SerialNumber"].Value.ToString();
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            TXTCON_LECTORA.Checked = false;
            txtteclado.Checked = true;
            no.Checked = true;
            Panel11.Visible = false;
            Panel9.Visible = false;
            TSIGUIENTE.Visible = false;
            TSIGUIENTE_Y_GUARDAR.Visible = true;
        }
        public static string correo;
        private void TSIGUIENTE_Y_GUARDAR__Click(object sender, EventArgs e)
        {
            
            if (validarCorreo(txtcorreo.Text) == false)
            {
                MessageBox.Show("Correo electrónico no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtcorreo.Focus();
                txtcorreo.SelectAll();
            }
            else
            {
                if (TXTPAIS.Text != "")
                {
                    if (txtmoneda.Text != "")
                    {
                        if (TXTCON_LECTORA.Checked == true || txtteclado.Checked == true)
                        {
                            if (si.Checked == true || no.Checked == true)
                            {
                                if (txtempresa.Text != "")
                                {
                                    if (txtRuta.Text != "")
                                    {
                                        if (no.Checked == true)
                                        {
                                            TXTTRABAJASCONIMPUESTOS.Text = "NO";
                                        }
                                        if (si.Checked == true)
                                        {
                                            TXTTRABAJASCONIMPUESTOS.Text = "SI";
                                        }
                                        Ingresar_empresa();
                                        Ingresar_Caja();
                                        Insertar_3_comprobantes_por_defecto();
                                        correo = txtcorreo.Text;
                                        Hide();
                                        Sistema_Ventas_MrTec.MODULOS.Asistente_de_Inicio.Usuarios_autorizados_al_sistema frm = new Sistema_Ventas_MrTec.MODULOS.Asistente_de_Inicio.Usuarios_autorizados_al_sistema();
                                        frm.ShowDialog();
                                        this.Dispose();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Seleccione una Ruta para Guardar las Copias de Seguridad", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Ingrese un nombre de Empresa", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Seleccione una opción ,si Vendes con Impuestos", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Seleccione una opción de Búsqueda de Productos con Frecuencia", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un simbolo de Moneda", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese un nombre de País", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
        }

        private void Insertar_3_comprobantes_por_defecto()
        {
            try
            {


                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_Serializacion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Serie", "T");
                cmd.Parameters.AddWithValue("@numeroinicio", 6);
                cmd.Parameters.AddWithValue("@numerofin", 0);                
                cmd.Parameters.AddWithValue("@tipodoc", "TICKET");
                cmd.Parameters.AddWithValue("@Destino", "VENTAS");
                cmd.Parameters.AddWithValue("@Por_defecto", "SI");
                cmd.ExecuteNonQuery();
                con.Close();


                con.Open();                
                cmd = new SqlCommand("insertar_Serializacion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Serie", "B");
                cmd.Parameters.AddWithValue("@numeroinicio", 6);
                cmd.Parameters.AddWithValue("@numerofin", 0);
                cmd.Parameters.AddWithValue("@tipodoc", "BOLETA");
                cmd.Parameters.AddWithValue("@Destino", "VENTAS");
                cmd.Parameters.AddWithValue("@Por_defecto", "-");
                cmd.ExecuteNonQuery();
                con.Close();


                con.Open();
                cmd = new SqlCommand("insertar_Serializacion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Serie", "F");
                cmd.Parameters.AddWithValue("@numeroinicio", 6);
                cmd.Parameters.AddWithValue("@numerofin", 0);
                cmd.Parameters.AddWithValue("@tipodoc", "FACTURA");
                cmd.Parameters.AddWithValue("@Destino", "VENTAS");
                cmd.Parameters.AddWithValue("@Por_defecto", "-");
                cmd.ExecuteNonQuery();
                con.Close();


                con.Open();
                cmd = new SqlCommand("insertar_Serializacion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Serie", "I");
                cmd.Parameters.AddWithValue("@numeroinicio", 6);
                cmd.Parameters.AddWithValue("@numerofin", 0);
                cmd.Parameters.AddWithValue("@tipodoc", "INGRESO");
                cmd.Parameters.AddWithValue("@Destino", "INGRESO DE COBROS");
                cmd.Parameters.AddWithValue("@Por_defecto", "-");
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                cmd = new SqlCommand("insertar_Serializacion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Serie", "E");
                cmd.Parameters.AddWithValue("@numeroinicio", 6);
                cmd.Parameters.AddWithValue("@numerofin", 0);
                cmd.Parameters.AddWithValue("@tipodoc", "EGRESO");
                cmd.Parameters.AddWithValue("@Destino", "EGRESO DE PAGOS");
                cmd.Parameters.AddWithValue("@Por_defecto", "-");
                cmd.ExecuteNonQuery();
                con.Close();



                con.Open();
                cmd = new SqlCommand("Insertar_FORMATO_TICKET", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Identificador_fiscal", "RUC Identificador Fiscal de la Empresa");
                cmd.Parameters.AddWithValue("@Direccion", "Calle, Nro, avenida");
                cmd.Parameters.AddWithValue("@Provincia_Departamento_Pais", "Provincia - Departamento - Pais");
                cmd.Parameters.AddWithValue("@Nombre_de_Moneda", "Nombre de Moneda");
                cmd.Parameters.AddWithValue("@Agradecimiento", "Agradecimiento");
                cmd.Parameters.AddWithValue("@pagina_Web_Facebook", "Pagina Web ó Facebook");
                cmd.Parameters.AddWithValue("@Anuncio", "Anuncio");
                cmd.Parameters.AddWithValue("@Datos_fiscales_de_autorizacion", "Datos Fiscales - Numero de Autorizacion, Resolucion...");
                cmd.Parameters.AddWithValue("@Por_defecto", "Ticket No Fiscal");
                cmd.ExecuteNonQuery();
                con.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Ingresar_Caja()
        {
            try
            {


                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Insertar_caja", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@descripcion", txtcaja.Text);
                cmd.Parameters.AddWithValue("@Tema", "Redentor");
                cmd.Parameters.AddWithValue("@Serial_PC", lblIDSERIAL.Text);
                cmd.Parameters.AddWithValue("@Impresora_Ticket", "Ninguna");
                cmd.Parameters.AddWithValue("@Impresora_A4", "Ninguna");
                cmd.Parameters.AddWithValue("@Tipo", "PRINCIPAL");

                cmd.ExecuteNonQuery();
                con.Close();                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Ingresar_empresa()
        {
            try
            {


                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_Empresa", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre_Empresa", txtempresa.Text);
                cmd.Parameters.AddWithValue("@Impuesto", txtimpuesto.Text);
                cmd.Parameters.AddWithValue("@Porcentaje_impuesto", txtporcentaje.Text);
                cmd.Parameters.AddWithValue("@Moneda", txtmoneda.Text);
                cmd.Parameters.AddWithValue("@Trabajas_con_impuestos", TXTTRABAJASCONIMPUESTOS.Text);                

                cmd.Parameters.AddWithValue("@Carpeta_para_copias_de_seguridad", txtRuta.Text);
                cmd.Parameters.AddWithValue("@Correo_para_envio_de_reportes", txtcorreo.Text);
                cmd.Parameters.AddWithValue("@Ultima_fecha_de_copia_de_seguridad", "Ninguna");
                cmd.Parameters.AddWithValue("@Ultima_fecha_de_copia_date", txtfecha.Value);
                cmd.Parameters.AddWithValue("@Frecuencia_de_copias", 1);
                cmd.Parameters.AddWithValue("@Estado", "PENDIENTE");
                cmd.Parameters.AddWithValue("@Tipo_de_empresa", "GENERAL");

                if (TXTCON_LECTORA.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@Modo_de_busqueda", "LECTORA");
                }
                if (txtteclado.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@Modo_de_busqueda", "TECLADO");
                }

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ImagenEmpresa.Image.Save(ms, ImagenEmpresa.Image.RawFormat);


                cmd.Parameters.AddWithValue("@logo", ms.GetBuffer());
                cmd.Parameters.AddWithValue("@Pais", TXTPAIS.Text);
                cmd.Parameters.AddWithValue("@Redondeo_de_total", "NO");



                cmd.ExecuteNonQuery();
                con.Close();
                //mostrar();
                //panel4.Visible = false;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void TXTCON_LECTORA_CheckedChanged(object sender, EventArgs e)
        {
            if (TXTCON_LECTORA.Checked == true)
            {
                txtteclado.Checked = false;
            }
            if (TXTCON_LECTORA.Checked == false)
            {
                txtteclado.Checked = true;
            }
        }

        private void txtteclado_CheckedChanged(object sender, EventArgs e)
        {
            if (txtteclado.Checked == true)
            {
                TXTCON_LECTORA.Checked = false;
            }
            if (txtteclado.Checked == false)
            {
                TXTCON_LECTORA.Checked = true;
            }
        }

        private void TXTPAIS_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtmoneda.SelectedIndex = TXTPAIS.SelectedIndex;
        }

        private void ImagenEmpresa_Click(object sender, EventArgs e)
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes |*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargador de Imagen de Sistema de Ventas";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ImagenEmpresa.BackgroundImage = null;
                ImagenEmpresa.Image = new Bitmap(dlg.FileName);
                ImagenEmpresa.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void lbleditarLogo_Click(object sender, EventArgs e)
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes |*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargador de Imagen de Sistema de Ventas";
            if(dlg.ShowDialog()== DialogResult.OK)
            {
                ImagenEmpresa.BackgroundImage = null;
                ImagenEmpresa.Image = new Bitmap(dlg.FileName);
                ImagenEmpresa.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void Label9_Click(object sender, EventArgs e)
        {
            if(FolderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = FolderBrowserDialog1.SelectedPath;
                string ruta = txtRuta.Text;
                if (ruta.Contains(@"C:\"))
                {
                    MessageBox.Show("Selecciona una ruta diferente al Disco Local C:", "Ruta Invalida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtRuta.Text = "";
                }
                else
                {
                    txtRuta.Text = FolderBrowserDialog1.SelectedPath;
                }
            }
        }

        private void ToolStripButton22_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = FolderBrowserDialog1.SelectedPath;
                string ruta = txtRuta.Text;
                if (ruta.Contains(@"C:\"))
                {
                    MessageBox.Show("Selecciona una ruta diferente al Disco Local C:", "Ruta Invalida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtRuta.Text = "";
                }
                else
                {
                    txtRuta.Text = FolderBrowserDialog1.SelectedPath;
                }
            }
        }

        public bool validarCorreo(string email)
        {
            return Regex.IsMatch(email, @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$");
        }

        private void txtcorreo_TextChanged(object sender, EventArgs e)
        {
            if (txtcorreo.Text == "" || txtcorreo.Text.Length == 0 || txtcorreo.Text == null)
            {
                lblCorreo.ImageIndex = -1;
                lblCorreo.Text = "Ingrese su correo electrónico";
            }
            else
            {
                if (validarCorreo(txtcorreo.Text) == true)
                {
                    lblCorreo.Text = "         Correo electrónico validado";
                    lblCorreo.ImageIndex = 0;
                    lblCorreo.ImageAlign = ContentAlignment.MiddleLeft;
                }
                if (validarCorreo(txtcorreo.Text) == false)
                {
                    lblCorreo.Text = "         Correo electrónico inválido";
                    lblCorreo.ImageIndex = 1;
                    lblCorreo.ImageAlign = ContentAlignment.MiddleLeft;
                }
            }
        }

        private void si_CheckedChanged(object sender, EventArgs e)
        {
            Panel11.Visible = true;
        }

        private void no_CheckedChanged(object sender, EventArgs e)
        {
            Panel11.Visible = false;
        }
    }
}
