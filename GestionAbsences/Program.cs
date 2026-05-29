using System;
using System.Windows.Forms;
using GestionAbsences.Controleur;

namespace GestionAbsences
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            new ControleurApp();
        }
    }
}