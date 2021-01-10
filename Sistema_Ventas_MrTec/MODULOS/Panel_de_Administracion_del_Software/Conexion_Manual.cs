using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Sistema_Ventas_MrTec.MODULOS.Panel_de_Administracion_del_Software
{
    public partial class Conexion_Manual : Form
    {
        private Conexion.AES aes = new Conexion.AES();
        private string cadenaConexion;
        public Conexion_Manual()
        {
            InitializeComponent();
        }
        
        private void Conexion_Manual_Load(object sender,EventArgs e)
        {
            ReadfromXML();
            //cadenaConexion = txtCnString.Text;
            Listar();
            if (lblEstadoConexion == "CONECTADO")
            {                
                Hide();
                Asistente_de_Inicio.Registro_de_Empresa frm = new Asistente_de_Inicio.Registro_de_Empresa();
                frm.ShowDialog();
                this.Dispose();
            }
            else
            {

            }
        }

        public void SavetoXML(object dbcString)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ConnectionString.xml");
            XmlElement root = doc.DocumentElement;
            root.Attributes[0].Value = Convert.ToString(dbcString);
            XmlTextWriter writer = new XmlTextWriter("ConnectionString.xml", null);
            writer.Formatting = Formatting.Indented;
            doc.Save(writer);
            writer.Close();
        }
        string dbcString;
        public void ReadfromXML()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("ConnectionString.xml");
                XmlElement root = doc.DocumentElement;
                dbcString = root.Attributes[0].Value;
                txtCnString.Text = (aes.Decrypt(dbcString, Conexion.Desencrytacion.appPwdUnique, int.Parse("256")));
                //txtCnString.Text = "";
                //txtCnString.Text = cadenaConexion;
            }
            catch (System.Security.Cryptography.CryptographicException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //limpiarRuta();
            SavetoXML(aes.Encrypt(txtCnString.Text, Conexion.Desencrytacion.appPwdUnique, int.Parse("256")));
            mostrar();
        }

        private void mostrar()
        {
            Conexion.ConexionMaestra.testConexion(Conexion.ConexionMaestra.Conexion);
            //SavetoXML(aes.Encrypt(txtCnString.Text, Conexion.Desencrytacion.appPwdUnique, int.Parse("256")));

            //    SqlConnection con = new SqlConnection();
            //    //String str;
            //    try
            //    {

            //        Conexion.ConexionMaestra.testConexion(Conexion.ConexionMaestra.Conexion);


            //        //con = new SqlConnection(Conexion.ConexionMaestra.Conexion);

            //        //str = "create DATABASE PSistema";
            //        //SqlCommand command = new SqlCommand(str, con);
            //        ////con.ConnectionString = Conexion.ConexionMaestra.Conexion;
            //        //con.Open();
            //        //command.ExecuteNonQuery();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //        MessageBox.Show("Sin conexion a la Base de datos \n" + ex.Message, "Conexion fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    finally
            //    {
            //        if ((con.State == ConnectionState.Open))
            //        {
            //            //con = new SqlConnection(Conexion.ConexionMaestra.Conexion);
            //            //str = "drop DATABASE PSistema";                    
            //            try
            //            {

            //                //SqlCommand command1 = new SqlCommand(str, con);
            //                //con.Open();
            //                //command1.ExecuteNonQuery();

            //                con.Close();
            //                MessageBox.Show("Coneccion realizada correctamente", "Conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //            catch (Exception ex)
            //            {
            //                Console.WriteLine(ex.Message);
            //            }
            //        }
            //    }
            //    //try
            //    //{
            //    //    DataTable dt = new DataTable();
            //    //    SqlDataAdapter da;
            //    //    SqlConnection con = new SqlConnection();
            //    //    con.ConnectionString = Conexion.ConexionMaestra.Conexion;
            //    //    con.Open();

            //    //    da = new SqlDataAdapter("mostrar_usuario", con);
            //    //    da.Fill(dt);
            //    //    datalistado.DataSource = dt;
            //    //    con.Close();
            //    //    MessageBox.Show("Coneccion realizada correctamente", "Conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //}
            //    //catch (Exception ex)
            //    //{
            //    //    MessageBox.Show("Sin conexion a la Base de datos \n" + ex.Message, "Conexion fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //}
            //    //Conexion.Tamaño_automatico_de_datatables.Multilinea(ref datalistado);
        }
        private string lblEstadoConexion;
        private void Listar()
        {

            //SqlConnection con = new SqlConnection();
            try
            {
                //con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                //con.Open();
                Conexion.ConexionMaestra.testConexion(Conexion.ConexionMaestra.Conexion);
                lblEstadoConexion = "CONECTADO";
            }
            catch (Exception ex)
            {
                lblEstadoConexion = "NO CONECTADO";
                Console.WriteLine(ex.Message);
                MessageBox.Show("Sin conexion a la Base de datos \n" + ex.Message, "Conexion fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //finally
            //{
            //    if ((con.State == ConnectionState.Open))
            //    {
            //        con.Close();
            //        //MessageBox.Show("Coneccion realizada correctamente", "Conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                con.Open();
                da = new SqlDataAdapter("select * from Usuario2", con);
                da.Fill(dt);
                datalistadoUsuarioRegistrado.DataSource = dt;
                con.Close();

                lblEstadoConexion = "CONECTADO";
            }
            catch (Exception ex)
            {
                lblEstadoConexion = "NO CONECTADO";
                Console.WriteLine(ex.Message);
                //MessageBox.Show("Sin conexion a la Base de datos \n" + ex.Message, "Conexion fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private string ruta;
        private void limpiarRuta()
        {
            ruta = Path.Combine(Directory.GetCurrentDirectory(), "ConnectionString" + ".xml");
            FileInfo fi = new FileInfo(ruta);
            StreamWriter sw;
            try
            {
                //if (File.Exists(ruta) == true)
                //{
                //    sw = File.CreateText(ruta);
                //    sw.WriteLine(txtCrearXML.Text);
                //    sw.Flush();
                //    sw.Close();
                //}
                //else 
                if (File.Exists(ruta) == true)
                {
                    File.Delete(ruta);
                    sw = File.CreateText(ruta);
                    sw.WriteLine(txtCrearXML.Text);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
