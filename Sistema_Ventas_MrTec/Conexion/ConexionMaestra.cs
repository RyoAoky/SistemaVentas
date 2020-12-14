using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Sistema_Ventas_MrTec.Conexion
{
    class ConexionMaestra
    {

        //public static string Conexion = "Data Source=SQL5063.site4now.net;Initial Catalog=DB_A699E9_ryoaoki;User Id=DB_A699E9_ryoaoki_admin;Password=Razer123@!;";
        //public static string Conexion = "Provider=SQLOLEDB;Data Source=SQL5097.site4now.net;Initial Catalog=;User Id=DB_A699E9_mrtec_admin;Password=admin1234";
        //SqlConnection conexion = new SqlConnection(Conexion1);

       // public static string Conexion = Convert.ToString(Sistema_Ventas_MrTec.Conexion.Desencrytacion.checkServer());

        public static string Conexion = "Data source=DESKTOP-M0SCQGB;Initial Catalog=Sis_Ventas_MrTec;Integrated Security= true";
        //Data source=DESKTOP-M0SCQGB;Initial Catalog=BASEADACURSO;Integrated Security= true
    }
}
