using Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Repository
{
    public interface IDVDRepository
    {
        int GetNextDVDCodeNo();
        void AddDVD(Dvd dvd);
    }
}
