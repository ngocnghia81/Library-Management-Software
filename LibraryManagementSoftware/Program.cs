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
            //Application.Run(new frmDangNhap());
<<<<<<< HEAD
            Application.Run(new frmTraSach());
=======
            Application.Run(new frmAdmin());
>>>>>>> a67a9bd5a865d6ec761ba9cb7414bf0e051a1cd1
        }
    }
}
