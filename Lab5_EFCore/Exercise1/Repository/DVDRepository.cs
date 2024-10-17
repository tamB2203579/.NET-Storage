using Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Repository
{
    public class DVDRepository : IDVDRepository
    {
        DvdlibraryContext dvdlibraryContext {  get; set; }
        public DVDRepository(DvdlibraryContext dvdlibraryContext)
        {
            this.dvdlibraryContext = dvdlibraryContext;
        }

        public int GetNextDVDCodeNo()
        {
            int CodeNo;
            try
            {
                CodeNo = dvdlibraryContext.Dvds.Max(d => d.DvdcodeNo);
                CodeNo++;
            } catch (Exception)
            {
                CodeNo = 1;
            }
            return CodeNo;
        }
        public void AddDVD(Dvd dvd)
        {
            dvdlibraryContext.Dvds.Add(dvd);
            dvdlibraryContext.SaveChanges();
        }
    }
}
