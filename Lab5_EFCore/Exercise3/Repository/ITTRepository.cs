using Exercise3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3.Repository
{
    public interface ITTRepository
    {
        int GetNextSoHD();
        void AddKH(Khachhang khachhang);
    }
}
