using System;
using System.Windows.Forms;

namespace MCMS
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            if (args[0] == "reset")
            {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Einstellungen wurden zurückgesetzt!");
                MCMS.Properties.Settings.Default.Reset();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}