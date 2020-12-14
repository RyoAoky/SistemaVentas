using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Sistema_Ventas_MrTec.MODULOS.Panel_de_Administracion_del_Software
{
    public partial class Conexion_Manual : Form
    {
        private Conexion.AES aes = new Conexion.AES();
        public Conexion_Manual()
        {
            InitializeComponent();
        }
        
        private void Conexion_Manual_Load(object sender,EventArgs e)
        {
            ReadfromXML();
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

            }
            catch (System.Security.Cryptography.CryptographicException ex)
            {


            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SavetoXML(aes.Encrypt(txtCnString.Text, Conexion.Desencrytacion.appPwdUnique, int.Parse("256")));
            mostrar();
        }

        private void mostrar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                con.Open();

                da = new SqlDataAdapter("mostrar_usuario", con);
                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();
                MessageBox.Show("Coneccion realizada correctamente", "Conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Sin conexion a la Base de datos", "Conexion fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

            Conexion.Tamaño_automatico_de_datatables.Multilinea(ref datalistado);

        }

        private void txtCnString_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
