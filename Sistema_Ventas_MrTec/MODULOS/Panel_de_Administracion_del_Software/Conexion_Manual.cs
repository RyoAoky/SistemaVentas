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
        string dbcString;
        public Conexion_Manual()
        {
            InitializeComponent();
        }
        
        private void Conexion_Manual_Load(object sender,EventArgs e)
        {
            //ReadfromXML();
            txtCnString.Clear();
            
        }

        public void SavetoXML(object dbcnString)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ConnectionString.xml");
            XmlElement root = doc.DocumentElement;
            root.Attributes[0].Value = Convert.ToString(dbcnString);
            XmlTextWriter writer = new XmlTextWriter("ConnectionString.xml", null);
            writer.Formatting = Formatting.Indented;
            doc.Save(writer);
            writer.Close();
        }

        public void ReadfromXML()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("ConnectionString.xml");
                XmlElement root = doc.DocumentElement;
                dbcString = root.Attributes[0].Value;
                txtCnString.Text = (aes.Decrypt(dbcString, Conexion.Desencrytacion.appPwdUnique, int.Parse("256")));
            }
            catch (System.Security.Cryptography.CryptographicException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            limpiarXML();
            SavetoXML(aes.Encrypt(txtCnString.Text, Conexion.Desencrytacion.appPwdUnique, int.Parse("256")));
            mostrar();
        }

        private void mostrar()
        {
            try
            {
                Conexion.ConexionMaestra.testConexion(Conexion.ConexionMaestra.Conexion());
            }catch(Exception ex)
            {

            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMostrarCadena_Click(object sender, EventArgs e)
        {
            ReadfromXML();
        }

        private void limpiarXML()
        {
            string ruta = Path.Combine(Directory.GetCurrentDirectory(), "ConnectionString" + ".xml");
            FileInfo fi = new FileInfo(ruta);
            StreamWriter sw;            
            if (File.Exists(ruta) == true)
            {
                File.Delete(ruta);
                sw = File.CreateText(ruta);
                sw.WriteLine(txtCrearXML.Text);
                sw.Flush();
                sw.Close();
            }
        }
    }
}
