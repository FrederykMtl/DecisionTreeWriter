using System;
using System.Windows.Forms;
using FileManager;

namespace DecisionTreeWriter
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
            DirectoryManager.CreateApplicationDirectories();
            Application.Run(new FrmDecisionTree());
        }
    }
}
