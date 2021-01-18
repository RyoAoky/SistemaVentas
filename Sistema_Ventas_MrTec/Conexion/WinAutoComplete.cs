using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sistema_Ventas_MrTec.Conexion
{
    public class DataHelper
    {
        public static DataTable LoadDataTable()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da ;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Conexion.ConexionMaestra.Conexion();
            con.Open();
            da = new SqlDataAdapter("SELECT TOP 100 Descripcion FROM Producto1",con);
            da.Fill(dt);
            return dt;
        }


        public static AutoCompleteStringCollection LoadAutoComplete()
        {
            DataTable dt = LoadDataTable();
            AutoCompleteStringCollection stringcol = new AutoCompleteStringCollection();
            foreach(DataRow row in dt.Rows)
            {
                stringcol.Add(Convert.ToString(row["Descripcion"]));
            }
            return stringcol;
        }
    }
}
