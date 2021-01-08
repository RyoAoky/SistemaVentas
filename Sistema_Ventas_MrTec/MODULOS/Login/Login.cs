using Google.Authenticator;
using Sistema_Ventas_MrTec.MODULOS.Caja;
using Sistema_Ventas_MrTec.MODULOS.Ventas_Menu_Principal;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Sistema_Ventas_MrTec.MODULOS
{
    public partial class Login : Form
    {
        private int contador;
        private int contador_Cajas;
        private int contador_mostrar_movimientos_de_caja_por_Serial_y_Usuario;
        private int contador_Usuario;
        public static String idusuariovariable;
        public static String idcajavariable;

        public Login()
        {
            InitializeComponent();           
        }
        //private void ejecutar_Procedimientos_Almacenados(string proc, int cantV, string[] Valores, string[] datos,int tipCMD)
        //{
        //string proc = "prueba1";
        //string[] v1 = { "@nombP", "@appPrueba", "@fecha" };
        //string[] dat = { "nombre1", Int16.Parse("1").ToString(), DateTime.Now.ToString() };
        //ejecutar_Procedimientos_Almacenados(proc, v1.Length, v1, dat);
        //    try
        //    {

        //        SqlConnection conn = new SqlConnection();
        //        conn.ConnectionString = Conexion.ConexionMaestra.Conexion;
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd = new SqlCommand(proc, conn);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        for (int i = 0; i < cantV; i++)
        //        {
        //            cmd.Parameters.AddWithValue(Valores.GetValue(i).ToString(), datos.GetValue(i).ToString());
        //        }
        //        if (tipCMD == 0)
        //        {
        //            cmd.ExecuteNonQuery();
        //        }else if (tipCMD == 1)
        //        {
        //            cmd.ExecuteScalar();
        //        }
        //        conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        private void Login_Load(object sender, EventArgs e)
        {
            
                dibujarUsuario();
                cargar_usuario();
                panel_Inicio_de_Sesion.Visible = false;
                panel_Restaurar_Contraseña.Visible = false;
                progressBar1.Visible = false;

                pictureBox3.Location = new Point((Width - pictureBox3.Width) / 2, (Height - pictureBox3.Height) / 2);
                Panel_seleccionar_Cuenta.Location = new Point((Width - Panel_seleccionar_Cuenta.Width) / 2, (Height - Panel_seleccionar_Cuenta.Height) / 2);
                panel_Restaurar_Contraseña.Location = new Point((Width - panel_Restaurar_Contraseña.Width) / 2, (Height - panel_Restaurar_Contraseña.Height) / 2);
                panel_Inicio_de_Sesion.Location = new Point((Width - panel_Inicio_de_Sesion.Width) / 2, (Height - panel_Inicio_de_Sesion.Height) / 2);

                timer1.Start();
            
        }        


        //public void OTP_Autenticador(object sender, PaintEventArgs e)
        //{
        //    TwoFactorAuthenticator autenticador = new TwoFactorAuthenticator();

        //    cargar_usuario();
        //    string key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);

        //    var setupInfo = autenticador.GenerateSetupCode("Sistema_de_Ventas_MrTEC", txtlogin.Text, key, false, 3);

        //    string qrCodeImageUrl = setupInfo.QrCodeSetupImageUrl;
        //    string manualEntrySetupCode = setupInfo.ManualEntryKey;

            

        //    imgQrCode.Image = qrCodeImageUrl;
        //    lblManualSetupCode.Text = manualEntrySetupCode;


        //    bool pincorrecto = autenticador.ValidateTwoFactorPIN("we23rf3rvujf23fvaw", "239056");
        //} 
        public void dibujarUsuario()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexion.ConexionMaestra.Conexion;
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("SELECT * from USUARIO2 where Estado='ACTIVO'", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Label nombUsua = new Label();
                Panel contenedor = new Panel();
                PictureBox imagenUsua = new PictureBox();

                nombUsua.Text = rdr["Login"].ToString();
                nombUsua.Name = rdr["idUsuario"].ToString();
                nombUsua.Size = new System.Drawing.Size(180, 40);
                nombUsua.Font = new System.Drawing.Font("Mongolian Baiti", 16);
                nombUsua.BackColor = Color.FromArgb(20, 20, 20);
                nombUsua.ForeColor = Color.White;
                nombUsua.Dock = DockStyle.Bottom;
                nombUsua.TextAlign = ContentAlignment.MiddleCenter;
                nombUsua.Cursor = Cursors.Hand;

                contenedor.Size = new System.Drawing.Size(180, 230);
                contenedor.BorderStyle = BorderStyle.None;
                contenedor.BackColor = Color.FromArgb(20, 20, 20);

                imagenUsua.Size = new System.Drawing.Size(180, 190);
                imagenUsua.Dock = DockStyle.Top;
                imagenUsua.BackgroundImage = null;
                byte[] bi = (Byte[])rdr["Icono"];
                MemoryStream ms = new MemoryStream(bi);
                imagenUsua.Image = Image.FromStream(ms);
                imagenUsua.SizeMode = PictureBoxSizeMode.Zoom;
                imagenUsua.Tag = rdr["Login"].ToString();
                imagenUsua.Cursor = Cursors.Hand;

                contenedor.Controls.Add(nombUsua);
                contenedor.Controls.Add(imagenUsua);
                nombUsua.BringToFront();
                flowLayoutPanel6.Controls.Add(contenedor);

                nombUsua.Click += new EventHandler(eventLabel);
                imagenUsua.Click += new EventHandler(eventImagen);
            }

            conn.Close();
        }
        private void eventImagen(System.Object sender, EventArgs e)
        {
            txtlogin.Text = ((PictureBox)sender).Tag.ToString();
            txtpaswwor.Clear();
            panel_Inicio_de_Sesion.Visible = true;
            Panel_seleccionar_Cuenta.Visible = false;
            MOSTRAR_PERMISOS();
            txtpaswwor.Focus();
        }
        private void eventLabel(System.Object sender, EventArgs e)
        {
            txtlogin.Text = ((Label)sender).Text;
            txtpaswwor.Clear();
            panel_Inicio_de_Sesion.Visible = true;
            Panel_seleccionar_Cuenta.Visible = false;
            MOSTRAR_PERMISOS();
            txtpaswwor.Focus();
        }

        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {

        }

        private void Listar_aperturas_de_cierre_de_detalle_de_cierre_de_caja()
        {
            //string proc = "mostrar_movimientos_de_caja_por_Serial";
            //string[] v1 = { "@Serial" };
            //string[] dat = {lblSerialPc.Text};
            //ejecutar_Procedimientos_Almacenados(proc, v1.Length, v1, dat,0);
            try
            {
                DataTable dt1 = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                con.Open();

                da = new SqlDataAdapter("mostrar_movimientos_de_caja_por_Serial", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Serial", lblSerialPc.Text);

                da.Fill(dt1);
                data_Listado_CierreCaja.DataSource = dt1;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void MOSTRAR_PERMISOS()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Conexion.ConexionMaestra.Conexion;

            SqlCommand com = new SqlCommand("mostrar_permisos_por_usuario_ROL_UNICO", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Login", txtlogin.Text);
            string importe;
            try
            {
                con.Open();
                importe = Convert.ToString(com.ExecuteScalar());
                con.Close();
                lblRol.Text = importe;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void contar_aperturas_de_detalles_cierre_de_caja()
        {
            int x;
            x = data_Listado_CierreCaja.Rows.Count;
            contador_Cajas = (x);
        }
        private void txtpaswwor_TextChanged(object sender, EventArgs e)
        {
            if (txtpaswwor.TextLength < 6)
            {
                Iniciar_Sesion_OK();
            }
            else
            {
                btn_iniciarSesion.PerformClick();
            }

        }

        private void aperturar_detalle_de_cierre_de_caja()
        {
            try
            {
                cargar_usuario();
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = Conexion.ConexionMaestra.Conexion;
                conn.Open();



                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_DETALLE_cierre_de_caja", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@fechaini", DateTime.Today);

                cmd.Parameters.AddWithValue("@fechafin", DateTime.Today);
                cmd.Parameters.AddWithValue("@fechacierre", DateTime.Today);
                cmd.Parameters.AddWithValue("@ingresos", "0.00");
                cmd.Parameters.AddWithValue("@egresos", "0.00");
                cmd.Parameters.AddWithValue("@saldo", "0.00");
                cmd.Parameters.AddWithValue("@idusuario", IDUSUARIO.Text);

                cmd.Parameters.AddWithValue("@totalcaluclado", "0.00");
                cmd.Parameters.AddWithValue("@totalreal", "0.00");
                cmd.Parameters.AddWithValue("@estado", "CAJA APERTURADA");
                cmd.Parameters.AddWithValue("@diferencia", "0.00");

                cmd.Parameters.AddWithValue("@id_caja", txtidcaja.Text);


                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Iniciar_Sesion_OK()
        {

            cargar_usuario();
            contar();

            try
            {
                IDUSUARIO.Text = dataListado.SelectedCells[1].Value.ToString();
                txtnombre.Text = dataListado.SelectedCells[2].Value.ToString();
                idusuariovariable = IDUSUARIO.Text;

                
            }
            catch
            {

            }
            if (contador > 0)
            {
                Listar_aperturas_de_cierre_de_detalle_de_cierre_de_caja();
                contar_aperturas_de_detalles_cierre_de_caja();


                string rol = lblRol.Text;
                if (contador_Cajas == 0 & lblRol.Text != "Solo Ventas (No está autorizado para manejar dinero)")
                {
                    aperturar_detalle_de_cierre_de_caja();
                    lblApertura_De_caja.Text = "Nuevo****";
                    timer2.Start();

                }
                else
                {
                    if (lblRol.Text != "Solo Ventas (No está autorizado para manejar dinero)")
                    {
                        mostrar_movimientos_de_caja_por_Serial_y_Usuario();
                        contar_mostrar_movimientos_de_caja_por_Serial_y_Usuario();
                        try
                        {
                            lblusuario_queinicioCaja.Text = data_Listado_CierreCaja.SelectedCells[1].Value.ToString();
                            lblnombredeCajero.Text = data_Listado_CierreCaja.SelectedCells[2].Value.ToString();

                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                        if (contador_mostrar_movimientos_de_caja_por_Serial_y_Usuario != 0)
                        {
                            if (lblusuario_queinicioCaja.Text != "admin" & txtlogin.Text == "admin")
                            {
                                MessageBox.Show("Continuaras Turno de *" + lblnombredeCajero.Text + " Todos los Registros seran con ese Usuario", "Caja Iniciada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                lblpermisodeCaja.Text = "Correcto";

                            }
                            else
                            if (lblusuario_queinicioCaja.Text == "admin" & txtlogin.Text == "admin")
                            {
                                lblpermisodeCaja.Text = "Correcto";
                            }
                            else if (lblusuario_queinicioCaja.Text != txtlogin.Text)
                            {
                                MessageBox.Show("Para poder continuar con el turno de " + lblnombredeCajero.Text + ", debes inciar sesion con este usuario " + lblusuario_queinicioCaja.Text + " ó con el usuario Admin", "Iniciar Sesion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                lblpermisodeCaja.Text = "vacio";
                            }
                            else if (lblusuario_queinicioCaja.Text == txtlogin.Text)
                            {
                                lblpermisodeCaja.Text = "Correcto";
                            }
                        }
                        else
                        {
                            lblpermisodeCaja.Text = "Correcto";
                        }
                        if (lblpermisodeCaja.Text == "Correcto")
                        {
                            lblApertura_De_caja.Text = "Aperturado";
                            timer2.Start();
                        }
                    }
                    else
                    {
                        timer2.Start();
                    }
                }
            }

        }

        private void mostrar_movimientos_de_caja_por_Serial_y_Usuario()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                con.Open();

                da = new SqlDataAdapter("mostrar_movimientos_de_caja_por_Serial_y_Usuario", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Serial", lblSerialPc.Text);
                da.SelectCommand.Parameters.AddWithValue("@idUsuario", IDUSUARIO.Text);

                da.Fill(dt);
                dataListado_movimiento_validar.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }
        private void contar_mostrar_movimientos_de_caja_por_Serial_y_Usuario()
        {
            int x;
            x = dataListado_movimiento_validar.Rows.Count;
            contador_mostrar_movimientos_de_caja_por_Serial_y_Usuario = (x);
        }
        private void contar()
        {
            int x;
            x = dataListado.Rows.Count;
            contador = (x);
        }
        private void cargar_usuario()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                con.Open();

                da = new SqlDataAdapter("validar_usuario", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@password", txtpaswwor.Text);
                da.SelectCommand.Parameters.AddWithValue("@login", txtlogin.Text);
                da.Fill(dt);
                dataListado.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            Conexion.Tamaño_automatico_de_datatables.Multilinea(ref dataListado);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void mostrar_correos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                con.Open();

                da = new SqlDataAdapter("select Correo from Usuario2 where Estado='ACTIVO'", con);
                da.Fill(dt);
                txtcorreo.DisplayMember = "Correo";
                txtcorreo.ValueMember = "Correo";
                txtcorreo.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            Conexion.Tamaño_automatico_de_datatables.Multilinea(ref dataListado);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel_Restaurar_Contraseña.Visible = true;
            Panel_seleccionar_Cuenta.Visible = false;
            mostrar_correos();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel_Inicio_de_Sesion.Visible = false;
            Panel_seleccionar_Cuenta.Visible = true;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            panel_Restaurar_Contraseña.Visible = false;
            Panel_seleccionar_Cuenta.Visible = true;

        }

        private void mostrar_correo_por_correo()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                SqlCommand da = new SqlCommand("buscar_usuario_por_correo", con);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@correo", txtcorreo.Text);
                con.Open();
                lblresultadoPass.Text = Convert.ToString(da.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void mostrar_usuario_por_correo()
        {
            try
            {
                //string resultado;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion;


                SqlCommand da = new SqlCommand("buscar_usuario1_por_correo", con);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@correo", txtcorreo.Text);
                con.Open();
                lblresultadoUser.Text = Convert.ToString(da.ExecuteScalar());
                //lblresultadoUser.Text = Convert.ToString(da.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        internal void enviarCorreo(string emisor, string password, string mensaje, string asunto, string destinatario, string ruta)
        {
            try
            {
                MailMessage correos = new MailMessage();
                SmtpClient envios = new SmtpClient();

                correos.To.Clear();
                correos.Body = "";
                correos.Subject = "";
                correos.Body = mensaje;
                correos.Subject = asunto;
                correos.IsBodyHtml = true;
                correos.To.Add((destinatario));
                correos.From = new MailAddress(emisor);
                envios.Credentials = new NetworkCredential(emisor, password);

                envios.Host = "mail.mistertec.net.pe";
                envios.Port = 587;
                envios.EnableSsl = false;
                //envios.DeliveryMethod = SmtpDeliveryMethod.Network;

                envios.Send(correos);
                lblresultadoPass.Text = "ENVIADO";
                //lblresultadoUser.Text = "ENVIADO";
                MessageBox.Show("Contraseña Enviada, revisa tu correo Electronico", "Recuperador de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel_Restaurar_Contraseña.Visible = false;

            }
            catch
            {
                MessageBox.Show("ERROR, revisa tu correo Electronico", "Restauracion de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblresultadoPass.Text = "Correo no registrado";
            }

        }
        private void btn_EnviarPass_Click(object sender, EventArgs e)
        {
            mostrar_usuario_por_correo();
            mostrar_correo_por_correo();
            richTextBox1.Text = richTextBox1.Text.Replace("@pass", lblresultadoPass.Text);
            richTextBox1.Text = richTextBox1.Text.Replace("@user", lblresultadoUser.Text);
            enviarCorreo("pruebas_app@mistertec.net.pe", "Palomares123", richTextBox1.Text, "Recuperacion de Contraseña", txtcorreo.Text, "");

            Panel_seleccionar_Cuenta.Visible = true;

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "2";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "0";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "9";
        }

        private void btnborrartodo_Click(object sender, EventArgs e)
        {
            txtpaswwor.Clear();
        }

        public static string Mid(string param, int startIndex, int length)
        {
            string result = param.Substring(startIndex, length);
            return result;
        }

        private void btnborrarderecha_Click(object sender, EventArgs e)
        {
            try
            {
                int largo;
                if (txtpaswwor.Text != "")
                {
                    largo = txtpaswwor.Text.Length;
                    txtpaswwor.Text = Mid(txtpaswwor.Text, txtpaswwor.GetLineFromCharIndex(6), largo - 1);
                }
            }
            catch
            {

            }
        }

        private void tver_Click(object sender, EventArgs e)
        {
            txtpaswwor.PasswordChar = '\0';
            tocultar.Visible = true;
            tver.Visible = false;
        }

        private void tocultar_Click(object sender, EventArgs e)
        {
            txtpaswwor.PasswordChar = '*';
            tocultar.Visible = false;
            tver.Visible = true;
        }

        private void MOSTRAR_CAJA_POR_SERIAL()
        {
            try
            {
                DataTable dt1 = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                con.Open();

                da = new SqlDataAdapter("mostrar_cajas_por_Serial_de_DiscoDuro", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Serial", lblSerialPc.Text);
                da.Fill(dt1);
                dataListado_Caja.DataSource = dt1;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            mostrar_Usuario_Registrado();
            contar_Usuarios();
            if (contador_Usuario == 0)
            {
                Dispose();
                this.Hide();
                Panel_de_Administracion_del_Software.Conexion_Manual frm = new Panel_de_Administracion_del_Software.Conexion_Manual();
                frm.ShowDialog();
            }
            else
            {
                //this.Show();
                timer1.Stop();
                try
                {

                    ManagementObjectSearcher MOS = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
                    foreach (ManagementObject getserial in MOS.Get())
                    {
                        lblSerialPc.Text = getserial.Properties["SerialNumber"].Value.ToString();

                        MOSTRAR_CAJA_POR_SERIAL();
                        try
                        {
                            txtidcaja.Text = dataListado_Caja.SelectedCells[1].Value.ToString();
                            lblcaja.Text = dataListado_Caja.SelectedCells[2].Value.ToString();
                            idcajavariable = txtidcaja.Text;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn_iniciarSesion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Contraseña incorrectar, intente nuevamente", "Inicio de Sesion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtpaswwor.Clear();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                panel5.Visible = false;
                panel_Inicio_de_Sesion.Visible = false;
                pictureBox3.Visible = true;
                BackColor = Color.FromArgb(26, 26, 26);
                progressBar1.Value = progressBar1.Value + 10;
                progressBar1.Visible = true;
            }
            else
            {
                progressBar1.Value = 0;
                timer2.Stop();
                if (lblApertura_De_caja.Text == "Nuevo****" & lblRol.Text != "Solo Ventas (No está autorizado para manejar dinero)")
                {
                    this.Hide();
                    Apertura_de_Caja frm = new Apertura_de_Caja();
                    frm.ShowDialog();
                    this.Hide();
                }
                else
                {
                    this.Hide();
                    Ventas_Menu_Principal_OK frm = new Ventas_Menu_Principal_OK();
                    frm.ShowDialog();
                    this.Hide();

                }

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            panel_Inicio_de_Sesion.Visible = false;
            panel_Restaurar_Contraseña.Visible = true;
            mostrar_correos();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            panel_Inicio_de_Sesion.Visible = false;
            Panel_seleccionar_Cuenta.Visible = true;
        }

        private void mostrar_Usuario_Registrado()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                con.Open();
                da = new SqlDataAdapter("select * from Usuario2", con);
                da.Fill(dt);
                dataListadoUsuario.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void contar_Usuarios()
        {
            int x;
            x = dataListadoUsuario.Rows.Count;
            contador_Usuario = (x);
        }
    }
}