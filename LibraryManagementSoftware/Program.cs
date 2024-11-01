using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSoftware
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmDangNhap());
<<<<<<< HEAD
            Application.Run(new frmDangNhap());
=======
            Application.Run(new frmAdmin());
>>>>>>> 4edf1b788a1d6a92a5ebf0181795b30619258416
        }
    }
}
