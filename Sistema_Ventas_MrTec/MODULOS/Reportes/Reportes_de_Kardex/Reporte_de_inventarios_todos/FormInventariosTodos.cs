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
    public partial class FormInventariosTodos : Form
    {
        public FormInventariosTodos()
        {
            InitializeComponent();
        }

        private void FormInventariosTodos_Load(object sender, EventArgs e)
        {
            mostrar();
        }
        ReporteInventarios_Todos rptFREPORT2 = new ReporteInventarios_Todos();
        private void mostrar()
        {
            try
            {
                
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();                
                con.ConnectionString = Conexion.ConexionMaestra.Conexion();
                con.Open();

                da = new SqlDataAdapter("imprimir_inventarios_todos", con);                
                
                da.Fill(dt);
                
                con.Close();
                rptFREPORT2 = new ReporteInventarios_Todos();
                rptFREPORT2.DataSource = dt;
                rptFREPORT2.table1.DataSource = dt;
                //Telerik.Reporting.InstanceReportSource instanceReportSource = new Telerik.Reporting.InstanceReportSource();
                //instanceReportSource.ReportDocument = rptFREPORT2;
                reportViewer1.Report = rptFREPORT2;
                
                reportViewer1.RefreshReport();
            }
            catch(Exception ex)
            {                
                Console.WriteLine(ex.Message);
            }
        }
    }
}
