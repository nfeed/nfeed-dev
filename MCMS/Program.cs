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
            try
            {
                switch (args[0])
                {
                    case "reset":
                        System.Console.WriteLine("Einstellungen wurden zurückgesetzt!");
                        MCMS.Properties.Settings.Default.Reset();
                        break;

                    case "test":
                        System.Console.WriteLine("Test");
                        System.Console.Out.WriteLine();
                        break;

                    default:

                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Keine Paramenter übergeben...");
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}