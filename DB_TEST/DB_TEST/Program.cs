using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_TEST
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm login = new LoginForm();
            Application.Run(login);
        }
/*        public static void MainWindow()
        {
            MainForm main = new MainForm();
            main.ShowDialog();
        }*/
    }
}
