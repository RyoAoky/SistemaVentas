using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sistema_Ventas_MrTec.MODULOS.Asistente_de_Inicio
{
    public partial class Inicio_de_Servidor : Form
    {
        public Inicio_de_Servidor()
        {
            InitializeComponent();
        }
        private void Inicio_de_Servidor_Load(object sender, EventArgs e)
        {
            Panel2.Location = new Point((Width - Panel2.Width) / 2, (Height - Panel2.Height) / 2);
            Panel4.Visible = false;
            Panel4.Dock = DockStyle.None;
            string nombre_del_equipo_usuario;
            nombre_del_equipo_usuario = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            txtservidor.Text = @".\"+lblnombredeservicio.Text;
            txtEliminarBase.Text = txtEliminarBase.Text.Replace("Sis_Ventas_MrTec-Prueba", TXTbasededatos.Text);
            txtCrear_procedimientos.Text = txtCrear_procedimientos.Text.Replace("Sis_Ventas_MrTec-Prueba", TXTbasededatos.Text);
            Cursor = Cursors.WaitCursor;


            comprobar_servidor_instalado();
        }

        private void comprobar_servidor_instalado()
        {
            ejecutar_scrip_EliminarBase_inicio_de_sesion();
        }

        private void ejecutar_scrip_EliminarBase_inicio_de_sesion()
        {
            string str;
            SqlConnection con = new SqlConnection("Server=" + txtservidor.Text + "; " + "database=master; integrated security=yes");
            str = txtEliminarBase.Text;
            SqlCommand command = new SqlCommand(str, con);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if ((con.State == ConnectionState.Open))
                {
                    con.Close();
                }
            }
        }

        
    }
}
