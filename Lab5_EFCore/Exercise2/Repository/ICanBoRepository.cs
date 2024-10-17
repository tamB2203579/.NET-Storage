using Exercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2.Repository
{
    public interface ICanBoRepository
    {
        int GetNextMaCB();
        void AddCanBo(Canbo canbo);
    }
}
