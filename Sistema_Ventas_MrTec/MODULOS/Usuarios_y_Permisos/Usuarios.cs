using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.IO;
using System.Text.RegularExpressions;

namespace Sistema_Ventas_MrTec
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void Cargar_estado_de_iconos()
        {
            try
            {
                foreach (DataGridViewRow row in dataListado.Rows)
                {

                    try
                    {

                        string Icono = Convert.ToString(row.Cells["Nombre_de_Icono"].Value);

                        if (Icono == "1")
                        {
                            pictureBox3.Visible = false;

                            pictureBox4.Visible = true;
                            pictureBox6.Visible = true;
                            pictureBox7.Visible = true;
                            pictureBox5.Visible = true;
                            pictureBox8.Visible = true;
                            pictureBox9.Visible = true;
                        }
                        else if (Icono == "2")
                        {
                            pictureBox4.Visible = false;

                            pictureBox3.Visible = true;
                            pictureBox6.Visible = true;
                            pictureBox7.Visible = true;
                            pictureBox5.Visible = true;
                            pictureBox8.Visible = true;
                            pictureBox9.Visible = true;
                        }
                        else if (Icono == "3")
                        {
                            pictureBox6.Visible = false;

                            pictureBox4.Visible = true;
                            pictureBox3.Visible = true;
                            pictureBox7.Visible = true;
                            pictureBox5.Visible = true;
                            pictureBox8.Visible = true;
                            pictureBox9.Visible = true;
                        }
                        else if (Icono == "4")
                        {
                            pictureBox7.Visible = false;

                            pictureBox4.Visible = true;
                            pictureBox6.Visible = true;
                            pictureBox3.Visible = true;
                            pictureBox5.Visible = true;
                            pictureBox8.Visible = true;
                            pictureBox9.Visible = true;
                        }
                        else if (Icono == "5")
                        {
                            pictureBox5.Visible = false;

                            pictureBox4.Visible = true;
                            pictureBox6.Visible = true;
                            pictureBox7.Visible = true;
                            pictureBox3.Visible = true;
                            pictureBox8.Visible = true;
                            pictureBox9.Visible = true;
                        }
                        else if (Icono == "6")
                        {
                            pictureBox8.Visible = false;

                            pictureBox4.Visible = true;
                            pictureBox6.Visible = true;
                            pictureBox7.Visible = true;
                            pictureBox5.Visible = true;
                            pictureBox3.Visible = true;
                            pictureBox9.Visible = true;
                        }
                        else if (Icono == "7")
                        {
                            pictureBox9.Visible = false;

                            pictureBox4.Visible = true;
                            pictureBox6.Visible = true;
                            pictureBox7.Visible = true;
                            pictureBox5.Visible = true;
                            pictureBox8.Visible = true;
                            pictureBox3.Visible = true;
                        }

                        
                        
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Cargar_estado_de_iconos();
            panelIcono.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Cargar_estado_de_iconos();
            panelIcono.Visible = true;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (txtCorreo.Text != "")
            {
                try
                {
                    SqlConnection conn = new SqlConnection();
                    //conn.ConnectionString = Conexion.ConexionMaestra.Conexion;
                    conn.Open();


                    
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand("editar_usuario", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idUsuario", lblID.Text);

                    cmd.Parameters.AddWithValue("@nombres", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@Login", txtUsuario.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPass.Text);
                    cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                    cmd.Parameters.AddWithValue("@Rol", txtRol.Text);

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    Icono.Image.Save(ms, Icono.Image.RawFormat);

                    cmd.Parameters.AddWithValue("@Icono", ms.GetBuffer());
                    cmd.Parameters.AddWithValue("@nombre_de_icono", lblnombIcono.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    mostrar();
                    btnGuardar.Visible = false;
                    btnGuardarCambios.Visible = true;                    
                    panel4.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }
        public bool validarCorreo(string email)
        {
            return Regex.IsMatch(email,@"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$");
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (validarCorreo(txtCorreo.Text) == false)
            {
                MessageBox.Show("Correo electrónico no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCorreo.Focus();
                txtCorreo.SelectAll();
            }
            else
            {
                if (txtRol.Text != "")
                {
                    if (txtNombre.Text != "" || txtUsuario.Text != "" || txtPass.Text != "")
                    {

                        if (txtCorreo.Text != "")
                        {
                            if (lblAnuncioIcono.Visible == false)
                            {
                                try
                                {


                                    SqlConnection con = new SqlConnection();
                                    //con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                                    con.Open();
                                    SqlCommand cmd = new SqlCommand();
                                    cmd = new SqlCommand("insertar_usuario", con);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@nombres", txtNombre.Text);
                                    cmd.Parameters.AddWithValue("@Login", txtUsuario.Text);
                                    cmd.Parameters.AddWithValue("@Password", txtPass.Text);

                                    cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                                    cmd.Parameters.AddWithValue("@Rol", txtRol.Text);
                                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                                    Icono.Image.Save(ms, Icono.Image.RawFormat);


                                    cmd.Parameters.AddWithValue("@Icono", ms.GetBuffer());
                                    cmd.Parameters.AddWithValue("@Nombre_de_icono", lblnombIcono.Text);
                                    cmd.Parameters.AddWithValue("@Estado", "ACTIVO");
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    mostrar();
                                    panel4.Visible = false;


                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("No ha ingresado un correo electronico","Registro");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hay campos sin completar", "Registro");
                    }
                }
                else
                {
                    MessageBox.Show("Elija un Rol", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void mostrar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                //con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                con.Open();

                //SqlCommand cmd = new SqlCommand();
                da = new SqlDataAdapter("mostrar_usuario", con);
                da.Fill(dt);
                dataListado.DataSource = dt;
                con.Close();

                dataListado.Columns[1].Visible = false;
                dataListado.Columns[5].Visible = false;
                dataListado.Columns[6].Visible = false;
                dataListado.Columns[7].Visible = false;
                dataListado.Columns[8].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            Conexion.Tamaño_automatico_de_datatables.Multilinea(ref dataListado);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Icono.Image = pictureBox3.Image;
            lblnombIcono.Text = "1";
            lblAnuncioIcono.Visible = false;
            panelIcono.Visible = false;

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Icono.Image = pictureBox4.Image;
            lblnombIcono.Text = "2";
            lblAnuncioIcono.Visible = false;
            panelIcono.Visible = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Icono.Image = pictureBox6.Image;
            lblnombIcono.Text = "3";
            lblAnuncioIcono.Visible = false;
            panelIcono.Visible = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Icono.Image = pictureBox7.Image;
            lblnombIcono.Text = "4";
            lblAnuncioIcono.Visible = false;
            panelIcono.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Icono.Image = pictureBox5.Image;
            lblnombIcono.Text = "5";
            lblAnuncioIcono.Visible = false;
            panelIcono.Visible = false;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Icono.Image = pictureBox8.Image;
            lblnombIcono.Text = "6";
            lblAnuncioIcono.Visible = false;
            panelIcono.Visible = false;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Icono.Image = pictureBox9.Image;
            lblnombIcono.Text = "7";
            lblAnuncioIcono.Visible = false;
            panelIcono.Visible = false;
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panelIcono.Visible = false;
            mostrar();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            lblAnuncioIcono.Visible = true;
            txtCorreo.Text = "";
            txtPass.Text = "";
            txtUsuario.Text = "";
            txtNombre.Text = "";
            lblCorreo.Text = "Ingrese su correo electrónico";
            lblCorreo.ImageIndex = -1;
            menuStrip3.Size = new Size(100, 81);
            menuStrip3.Location = new Point(126, 400);
            //67,332
            btnGuardar.Visible = true;
            btnGuardarCambios.Visible = false;
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID.Text = dataListado.SelectedCells[1].Value.ToString();
            txtNombre.Text = dataListado.SelectedCells[2].Value.ToString();
            txtUsuario.Text = dataListado.SelectedCells[3].Value.ToString();
            txtPass.Text = dataListado.SelectedCells[4].Value.ToString();

            Icono.BackgroundImage = null;
            byte[] b = (byte[])dataListado.SelectedCells[5].Value;
            MemoryStream ms = new MemoryStream(b);
            Icono.Image = Image.FromStream(ms);
            lblAnuncioIcono.Visible = false;

            //lblID.Text = dataListado.SelectedCells[1].RowIndex.ToString();

            lblnombIcono.Text = dataListado.SelectedCells[6].Value.ToString();
            
            txtCorreo.Text = dataListado.SelectedCells[7].Value.ToString();
            txtRol.Text = dataListado.SelectedCells[8].Value.ToString();
            menuStrip3.Size = new Size(170, 81);
            menuStrip3.Location = new Point(126, 400);
            panel5.Visible = true;
            panel4.Visible = true;
            
            panelIcono.Visible = false;
            btnGuardar.Visible = false;
            btnGuardarCambios.Visible = true;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void dataListado_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == this.dataListado.Columns["Eli"].Index)
            {
                DialogResult result;
                result = MessageBox.Show("¿Desea eliminar este usuario? " + dataListado.SelectedCells[3].Value.ToString(), "Eliminar registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    SqlCommand cmd;
                    try
                    {
                        foreach (DataGridViewRow row in dataListado.SelectedRows)
                        {
                            int onekey = Convert.ToInt32(row.Cells["idUsuario"].Value);
                            string usuario = Convert.ToString(row.Cells["Login"].Value);

                            try
                            {
                                try
                                {
                                    SqlConnection con = new SqlConnection();
                                    //con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                                    con.Open();
                                    cmd = new SqlCommand("eliminar_usuario", con);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@idUsuario", onekey);
                                    cmd.Parameters.AddWithValue("@Login", usuario);
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            catch (Exception ex1)
                            {
                                MessageBox.Show(ex1.Message);
                            }
                        }
                        mostrar();
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show(ex2.Message);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargar Imágen";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Icono.BackgroundImage = null;
                Icono.Image = new Bitmap(dlg.FileName);
                Icono.SizeMode = PictureBoxSizeMode.Zoom;
                lblnombIcono.Text = Path.GetFileName(dlg.FileName);
                lblAnuncioIcono.Visible = false;
                panelIcono.Visible = false;
            }
        }


        private void buscar_usuario()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                //con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                con.Open();

                da = new SqlDataAdapter("buscar_usuario", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", txtBuscar.Text);
                da.Fill(dt);
                dataListado.DataSource = dt;
                con.Close();

                dataListado.Columns[1].Visible = false;
                dataListado.Columns[5].Visible = false;
                dataListado.Columns[6].Visible = false;
                dataListado.Columns[7].Visible = false;
                dataListado.Columns[8].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            Conexion.Tamaño_automatico_de_datatables.Multilinea(ref dataListado);

        }
        public void Numeros(System.Windows.Forms.TextBox CajaTexto, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;

            }


        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            buscar_usuario();
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            Numeros(txtBuscar, e);
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCorreo.Text == "" || txtCorreo.Text.Length==0 || txtCorreo.Text==null)
            {
                lblCorreo.ImageIndex = -1;
                lblCorreo.Text = "Ingrese su correo electrónico";
            }
            else
            {
                if (validarCorreo(txtCorreo.Text) == true)
                {
                    lblCorreo.Text = "         Correo electrónico validado";
                    lblCorreo.ImageIndex = 0;
                    lblCorreo.ImageAlign = ContentAlignment.MiddleLeft;
                }
                if (validarCorreo(txtCorreo.Text) == false)
                {
                    lblCorreo.Text = "         Correo electrónico inválido";
                    lblCorreo.ImageIndex = 1;
                    lblCorreo.ImageAlign = ContentAlignment.MiddleLeft;
                }
            }
            
        }

        private void btnCerrarIconos_Click(object sender, EventArgs e)
        {
            panelIcono.Visible = false;
        }
    }
}
