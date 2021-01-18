using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Ventas_MrTec.MODULOS.Reportes.Reportes_de_Kardex.Reporte_de_inventarios_todos
{
    public partial class FormMovimientoBuscar : Form
    {
        public FormMovimientoBuscar()
        {
            InitializeComponent();
        }

        private void FormMovimientoBuscar_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        ReportMovimientoBuscar rptFREPORT2 = new ReportMovimientoBuscar();
        private void mostrar()
        {
            try
            {

                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion();
                con.Open();
                da = new SqlDataAdapter("buscar_MOVIMIENTOS_DE_KARDEX", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idProducto",MODULOS.Inventarios_KARDEX.Inventarios_Menu.idProducto);
                da.Fill(dt);
                con.Close();
                rptFREPORT2 = new ReportMovimientoBuscar();
                rptFREPORT2.DataSource = dt;               
                reportViewer1.Report = rptFREPORT2;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
