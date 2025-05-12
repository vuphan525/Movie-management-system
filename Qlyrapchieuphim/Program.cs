using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace Qlyrapchieuphim
{
    
    internal static class Program
    {
        //Global variables start
        private static string _ConnString = "";
        public static string ConnString
        {
            get {  return _ConnString; }
            set { _ConnString = value; }
        }
        //Global variables end


        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
        [STAThread]
        static void Main()
        {
            SetProcessDPIAware();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Program.ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            Application.Run(new Form1());
        }
    }
}
