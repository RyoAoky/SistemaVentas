using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Ventas_MrTec.MODULOS.Asistente_de_Inicio
{
    public partial class Usuarios_autorizados_al_sistema : Form
    {
        public Usuarios_autorizados_al_sistema()
        {
            InitializeComponent();
            ManagementObject MOS = new ManagementObject(@"Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'");
            lblIDSERIAL.Text = MOS.Properties["SerialNumber"].Value.ToString();
            lblIDSERIAL.Text = lblIDSERIAL.Text.Trim();
            txtnombre.Focus();
        }
        
        private void Usuarios_autorizados_al_sistema_Load(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text != "" && TXTCONTRASEÑA.Text != "" && TXTUSUARIO.Text != "")
            {
                if (TXTCONTRASEÑA.Text == txtconfirmarcontraseña.Text)
                {
                    string contraseña_encryptada;
                    contraseña_encryptada = Conexion.Encryptar_en_texto.Encriptar(this.TXTCONTRASEÑA.Text.Trim());
                    try
                    {
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = Conexion.ConexionMaestra.Conexion();
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand("insertar_usuario", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombres", txtnombre.Text);
                        cmd.Parameters.AddWithValue("@Login", TXTUSUARIO.Text);
                        cmd.Parameters.AddWithValue("@Password", contraseña_encryptada);

                        cmd.Parameters.AddWithValue("@Correo", Asistente_de_Inicio.Registro_de_Empresa.correo);
                        cmd.Parameters.AddWithValue("@Rol", "Administrador (Control total)");
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        PictureBox2.Image.Save(ms, PictureBox2.Image.RawFormat);


                        cmd.Parameters.AddWithValue("@Icono", ms.GetBuffer());
                        cmd.Parameters.AddWithValue("@Nombre_de_icono", "Ada_369");
                        cmd.Parameters.AddWithValue("@Estado", "ACTIVO");
                        cmd.ExecuteNonQuery();
                        con.Close();

                        Insertar_licencia_de_prueba_30_dias();
                        insertar_cliente_standar();
                        insertar_grupo_por_defecto();
                        insertar_inicio_De_sesion();
                        MessageBox.Show("!LISTO! RECUERDA que para Iniciar Sesión tu Usuario es: " + TXTUSUARIO.Text + " y tu Contraseña es: " + TXTCONTRASEÑA.Text, "Registro Exitoso", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                        Dispose();
                        Application.Restart();
                        //Presentacion.LOGIN frm = new Presentacion.LOGIN();
                        //frm.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        //MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas no Coinciden", "Contraseñas Incompatibles", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("Falta ingresar Datos", "Datos incompletos", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
        }

        private void Insertar_licencia_de_prueba_30_dias()
        {
            DateTime today = DateTime.Now;
            DateTime fechaFinal = today.AddDays(30);
            txtfechaFinalOK.Text = Convert.ToString(fechaFinal);
            string SERIALpC;
            SERIALpC = Conexion.Encryptar_en_texto.Encriptar(this.lblIDSERIAL.Text.Trim());
            string FECHA_FINAL;
            FECHA_FINAL = Conexion.Encryptar_en_texto.Encriptar(this.txtfechaFinalOK.Text.Trim());
            string estado;
            estado = Conexion.Encryptar_en_texto.Encriptar("?ACTIVO?");
            string fecha_activacion;
            fecha_activacion = Conexion.Encryptar_en_texto.Encriptar(this.txtfechaInicio.Text.Trim());

            try
            {
                try
                {


                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = Conexion.ConexionMaestra.Conexion();
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand("Insertar_marcan", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@s", SERIALpC);
                    cmd.Parameters.AddWithValue("@f", FECHA_FINAL);
                    cmd.Parameters.AddWithValue("@e", estado);
                    cmd.Parameters.AddWithValue("@fa", fecha_activacion);
                    cmd.ExecuteNonQuery();
                    con.Close();


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //MessageBox.Show(ex.Message);
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void insertar_cliente_standar()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_clientes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", "GENERICO");
                cmd.Parameters.AddWithValue("@Direccion", 0);
                cmd.Parameters.AddWithValue("@IdentificadorFiscal ", 0);
                cmd.Parameters.AddWithValue("@Celular", 0);
                cmd.Parameters.AddWithValue("@Estado ", 0);
                cmd.Parameters.AddWithValue("@Saldo", 0);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //MessageBox.Show(ex.Message);
            }
        }
        private void insertar_grupo_por_defecto()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_Grupo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", "General");
                cmd.Parameters.AddWithValue("@Por_defecto", "Si");                
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //MessageBox.Show(ex.Message);
            }
        }
        private void insertar_inicio_De_sesion()
        {
            try
            {

                string serialPC;
                serialPC = Conexion.Encryptar_en_texto.Encriptar(this.lblIDSERIAL.Text.Trim());
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_inicio_De_sesion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_serial_Pc", serialPC);
                cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);
                cmd.ExecuteNonQuery();
                con.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
