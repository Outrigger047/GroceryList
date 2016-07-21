using System;
using System.Windows.Forms;

namespace GroceryList.Main
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
            try
            {
                Application.Run(new NewListWindow());
            }
            catch (Exception e)
            {
                if (e.Message.Contains("Header row invalid"))
                {
                    System.Windows.Forms.MessageBox.Show(
                        "Repository header row invalid.",
                        "Repository Import Error",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Error);
                }
                else if (e.Message.Contains("Duplicate item found"))
                {
                    System.Windows.Forms.MessageBox.Show(
                        "Duplicate item found: " + e.InnerException.Message,
                        "Repository Import Error",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
        }
    }
}
