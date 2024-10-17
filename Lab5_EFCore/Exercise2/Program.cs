using Exercise2.Models;
using Exercise2.Repository;

namespace Exercise2
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

            QlcbContext context = new QlcbContext();
            ICanBoRepository canBoRepository = new CanBoRepository(context);

            Application.Run(new frmCanBo(canBoRepository, context));
        }
    }
}  