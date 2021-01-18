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
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace Sistema_Ventas_MrTec.MODULOS.Asistente_de_Inicio
{
    public partial class Inicio_de_Servidor : Form
    {
        Process pros = new Process();
        Process pro = new Process();
        private string ruta;
        private Conexion.AES aes = new Conexion.AES();
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
            txtservidor.Text = @".\" + lblnombredeservicio.Text;
            //txtEliminarBase.Text = txtEliminarBase.Text.Replace("Sis_Ventas_MrTec", TXTbasededatos.Text);
            txtCrear_procedimientos.Text = txtCrear_procedimientos.Text.Replace("Sis_Ventas_MrTec", TXTbasededatos.Text);
            Cursor = Cursors.WaitCursor;


            comprobar_servidor_instalado();
            //timer4.Start();
        }

        private void comprobar_servidor_instalado()
        {
            ejecutar_scrip_EliminarBase_inicio_de_sesion();
            ejecutar_scrip_CrearBase_Comprobacion_de_Inicio();
        }

        private void ejecutar_scrip_EliminarBase_inicio_de_sesion()
        {
            string str;
            //SqlConnection con = new SqlConnection("Server=" + txtservidor.Text + "; " + "database=master; integrated security=yes");
            //SqlConnection con = new SqlConnection("Data Source=" + txtservidor.Text + "; " + "database=master; User Id=sa;Password=Razer123@!;");
            SqlConnection con = new SqlConnection("Data Source=74.208.42.58,1433;database=master;User Id=sa;Password=Razer123@!;");
            str = txtEliminarBase.Text;
            SqlCommand command = new SqlCommand(str, con);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
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

        private void ejecutar_scrip_CrearBase_Comprobacion_de_Inicio()
        {
            //var cnn = new SqlConnection("Server=" + txtservidor.Text + "; " + "database=master; integrated security=yes");
            var cnn = new SqlConnection("Data Source=74.208.42.58,1433;database=master;User Id=sa;Password=Razer123@!;");
            string s = "CREATE DATABASE " + TXTbasededatos.Text;
            string s1 = "CREATE DATABASE Sis_Ventas_MrTec";
            var cmd = new SqlCommand(s, cnn);
            var cmd1 = new SqlCommand(s1, cnn);
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                SavetoXML(aes.Encrypt("Data Source=74.208.42.58,1433;Initial Catalog=" + TXTbasededatos.Text + ";User Id=sa;Password=Razer123@!;", Conexion.Desencrytacion.appPwdUnique, int.Parse("256")));

                Panel4.Visible = true;
                Panel4.Dock = DockStyle.Fill;
                label3.Text = @"Instancia Encontrada...
                No Cierre esta Ventana, se cerrara Automaticamente cuando este todo Listo";
                Panel6.Visible = false;


                ejecutar_scryt_crearProcedimientos_almacenados_y_tablas();
                
                



                //TimerCRARINI.Start();
                if (pros.HasExited)
                {
                    //PictureBox2.Hide();
                    timer2.Stop();
                    TimerCRARINI.Stop();
                    timer4.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.Cursor = Cursors.Default;
                Panel6.Visible = true;
                Button2.Visible = true;
                Panel4.Visible = false;
                Panel4.Dock = DockStyle.None;
                lblbuscador_de_servidores.Text = "De click a Instalar Servidor, luego de click a SI cuando se le pida, luego presione ACEPTAR y espere por favor ";
            }


            finally
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
        }

        //private async void loading(object sender,EventArgs e)
        //{
        //    Task task = new Task(ejecutar_scryt_crearProcedimientos_almacenados_y_tablas);
        //    task.Start();
        //    PictureBox2.Show();            
        //    await task;
        //}
        
        private void ejecutar_scryt_crearProcedimientos_almacenados_y_tablas()
        {
            //PictureBox2.Show();

            ruta = Path.Combine(Directory.GetCurrentDirectory(), txtnombre_scrypt.Text + ".txt");
            FileInfo fi = new FileInfo(ruta);
            StreamWriter sw;
            try
            {
                if (File.Exists(ruta) == false)
                {
                    sw = File.CreateText(ruta);
                    sw.WriteLine(txtCrear_procedimientos.Text);
                    sw.Flush();
                    sw.Close();
                }
                else if (File.Exists(ruta) == true)
                {
                    File.Delete(ruta);
                    sw = File.CreateText(ruta);
                    sw.WriteLine(txtCrear_procedimientos.Text);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                //timer2.Start();
                try
                {

                    Panel4.Visible = true;
                    Panel4.Dock = DockStyle.Fill;
                    label3.Text = @"Instalando programas necesarios...";
                    Panel6.Visible = false;
                    

                    if (Environment.Is64BitOperatingSystem)
                    {                        
                        pro.StartInfo.FileName = "MsSqlCmdLnUtils-x64.msi";
                        pro.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                        pro.Start();                        
                    }
                    else
                    {                        
                        pro.StartInfo.FileName = "MsSqlCmdLnUtils-x86.msi";
                        pro.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                        pro.Start();                        
                    }

                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                pro.WaitForExit();
                
                //TimerCRARINI.Start();
                pros.StartInfo.FileName = "sqlcmd";
                pros.StartInfo.Arguments = "-S  tcp:74.208.42.58,1433 -U sa -P Razer123@!" + " -i" + txtnombre_scrypt.Text + ".txt";
                pros.Start();

                Panel4.Visible = true;
                Panel4.Dock = DockStyle.Fill;
                label3.Text = @"Instancia Encontrada...
                No Cierre esta Ventana, se cerrara Automaticamente cuando este todo Listo";
                Panel6.Visible = false;

                pros.WaitForExit();
                
                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
        public static int milisegundo;
        public static int segundo;        
        private void timer4_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            timer3.Stop();
            milisegundo += 1;
            mil3.Text = Convert.ToString(milisegundo);
            if (milisegundo == 60)
            {
                segundo += 1;
                seg3.Text = Convert.ToString(segundo);
                milisegundo = 0;
            }
            if (segundo == 4)
            {
                timer4.Stop();
                try
                {
                    File.Delete(ruta);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Dispose();
                Application.Restart();
            }
        }

        public static int milisegundo1;
        public static int segundos1;
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            //milisegundo1 += 1;
            //milisegundo22.Text = Convert.ToString(milisegundo1);
            //if (milisegundo1 == 60)
            //{
            //    segundos1 += 1;
            //    segundos22.Text = Convert.ToString(segundos1);

            //    milisegundo1 = 0;                
            //}
            //if (segundos1 == 3)
            //{
            //    timer2.Stop();
            //}
        }

        public static int milisegundo2;
        public static int segundos2;
        public static int minutos2;

        //private string milisegundo21;
        //private string segundos21;
        private string minutos21;
        private void TimerCRARINI_Tick(object sender, EventArgs e)
        {
            //milisegundo2 += 1;
            //milisegundo21.Text = Convert.ToString(milisegundo2);
            //if (milisegundo2 == 60)
            //{
            //    segundos2 += 1;
            //    segundos21.Text = Convert.ToString(segundos2);

            //    milisegundo2 = 0;                
            //}
            //if (segundos1 == 20)
            //{
            //    TimerCRARINI.Stop();
            //}
        }
    }
}
