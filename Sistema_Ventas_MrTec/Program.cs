using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Sistema_Ventas_MrTec
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MODULOS.Productos.ProductoOK());

            //Application.Run(new MODULOS.Login());

            //Application.Run(new MODULOS.Panel_de_Administracion_del_Software.Conexion_Manual());

            Application.Run(new MODULOS.Inventarios_KARDEX.Inventarios_Menu());
        }
    }
}
