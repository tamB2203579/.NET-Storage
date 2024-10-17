using Exercise3.Models;
using Exercise3.Repository;

namespace Exercise3
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            ThanhToanContext context = new ThanhToanContext();
            ITTRepository ttRepository = new TTRepository(context);

            Application.Run(new frmThanhToan(ttRepository, context));
        }
    }
}