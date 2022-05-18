using ServidorConcentrese.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServidorConcentrese
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Properties.Settings.Default.DataDirectory);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Concentrese servidorConcentrese = new Concentrese();
            Application.Run(new VentanaServidor(servidorConcentrese));
        }
    }
}
