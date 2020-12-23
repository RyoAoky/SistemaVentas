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
namespace Sistema_Ventas_MrTec.MODULOS.Reportes.Reportes_de_Kardex.Reporte_de_inventarios_todos
{
    public partial class FormReporteMovimientoFILTROS : Form
    {
        public FormReporteMovimientoFILTROS()
        {
            InitializeComponent();
        }

        private void FormReporteMovimientoFILTROS_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        Reporte_Movimiento_con_filtros rptFREPORT2 = new Reporte_Movimiento_con_filtros();
        private void mostrar()
        {
            try
            {

                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexion.ConexionMaestra.Conexion;
                con.Open();
                da = new SqlDataAdapter("buscar_MOVIMIENTOS_DE_KARDEX_filtros", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fecha", MODULOS.Inventarios_KARDEX.Inventarios_Menu.Fecha);
                da.SelectCommand.Parameters.AddWithValue("@tipo", MODULOS.Inventarios_KARDEX.Inventarios_Menu.Tipo_de_Movimiento);
                da.SelectCommand.Parameters.AddWithValue("@Id_usuario", MODULOS.Inventarios_KARDEX.Inventarios_Menu.id_Usuario);
                da.Fill(dt);
                con.Close();
                rptFREPORT2 = new Reporte_Movimiento_con_filtros();
                rptFREPORT2.DataSource = dt;
                rptFREPORT2.table1.DataSource = dt;
                reportViewer1.Report = rptFREPORT2;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
