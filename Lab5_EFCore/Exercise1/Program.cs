using Exercise1.Models;
using Exercise1.Repository;
using Lab4;

namespace Exercise1
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
    
            DvdlibraryContext context = new DvdlibraryContext();
            IDVDRepository dvdRepository = new DVDRepository(context);

            Application.Run(new frmDVDCatalog(dvdRepository));
        }
    }
}