using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

namespace Shoot_Down_Zombie
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        //public static Stopwatch mystopwatch = new Stopwatch();

        [STAThread]
        static void Main()
        {
            //mystopwatch.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Form1());

            //below will run when we close the applicaiton

            //MessageBox.Show(Application.StartupPath.ToString());
            //MessageBox.Show(Application.ExecutablePath.ToString());

            //MessageBox.Show(Program.mystopwatch.ElapsedMilliseconds.ToString());
        }
    }
}
