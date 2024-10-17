using Exercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2.Repository
{
    public class CanBoRepository : ICanBoRepository
    {
        QlcbContext qlcbContext {  get; set; }
        public CanBoRepository(QlcbContext qlcbContext)
        {
            this.qlcbContext = qlcbContext;
        }
        
        public int GetNextMaCB()
        {
            int MaCB;
            try
            {
                MaCB = qlcbContext.Canbos.Max(c => c.MaCb);
                MaCB++;
            }
            catch (Exception)
            {
                MaCB = 1;
            }
            return MaCB;
        }

        public void AddCanBo(Canbo canbo)
        {
            qlcbContext.Canbos.Add(canbo);
            qlcbContext.SaveChanges();
        }
    }
}
