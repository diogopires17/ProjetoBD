using aluguer_de_equipamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Contacts
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            //Application.Run(new ReservasUser(12));
            //Application.Run(new Feedback(12));
           // Application.Run(new AdminHomePage(1));
        }
    }
}
