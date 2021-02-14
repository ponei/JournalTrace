using JournalTrace.Language;
using JournalTrace.View.Util;
using System;
using System.Windows.Forms;

namespace JournalTrace
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            _ = new LanguageManager();
            _ = new ContextMenuHelper();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}