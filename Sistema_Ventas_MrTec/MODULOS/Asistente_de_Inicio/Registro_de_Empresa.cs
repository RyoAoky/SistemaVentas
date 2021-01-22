using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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

        }

        private void TSIGUIENTE_Y_GUARDAR__Click(object sender, EventArgs e)
        {
            if (validarCorreo(txtcorreo.Text) == false)
            {
                MessageBox.Show("Correo electrónico no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtcorreo.Focus();
                txtcorreo.SelectAll();
            }

            if (no.Checked == true)
            {
                TXTTRABAJASCONIMPUESTOS.Text = "NO";
            }
            if (si.Checked == true)
            {
                TXTTRABAJASCONIMPUESTOS.Text = "SI";
            }
            Ingresar_empresa();
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
    }
}
