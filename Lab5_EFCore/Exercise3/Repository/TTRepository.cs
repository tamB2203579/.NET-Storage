using Exercise3.Models;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3.Repository
{
    public class TTRepository : ITTRepository
    {
        ThanhToanContext ttcontext {  get; set; }
        public TTRepository(ThanhToanContext ttcontext)
        {
            this.ttcontext = ttcontext;
        }
        
        public int GetNextSoHD()
        {
            int SoHD;
            try
            {
                SoHD = ttcontext.Khachhangs.Max(k => k.SoHd);
                SoHD++;
            }
            catch (Exception)
            {
                SoHD = 1;
            }
            return SoHD;
        }
        public void AddKH(Khachhang khachhang)
        {
            ttcontext.Khachhangs.Add(khachhang);
            ttcontext.SaveChanges();
        }
    }
}
