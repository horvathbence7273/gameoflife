using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public class MezoAdat : IAdat
    {
        public int Ehesseg { get; set; }
        public int FuAllapot { get; set; }
        public bool Mozgott { get; set; }
        public bool Szult {  get; set; }

        public MezoAdat(int Ehesseg, int FuAllapot)
        {
            this.Ehesseg = Ehesseg;
            this.FuAllapot = FuAllapot;
            Mozgott = false;
            Szult = false;
        }

        public virtual void Frissites(int oszlop, int sor)
        {
            Kepek.KepMezo[oszlop,sor].Image = null;
            Kepek.KepMezo[oszlop,sor].BackgroundImage = Kepek.Fuvek.Images[FuAllapot];
        }

        public virtual void FuNo(int oszlop, int sor)
        {
            if (FuAllapot < 2)
            {
                FuAllapot++;
            }
            Frissites(oszlop, sor);
           
        }
        public void KorVege(int oszlop, int sor)
        {
            Szult = false;
            Mozgott = false;
            if (Ehesseg != 0)
            {
                Ehesseg--;
            }
            FuNo(oszlop, sor);
        }

        public virtual void Mozog(int oszlop, int sor)
        {
        }

        public virtual bool Eszik(int oszlop, int sor)
        {
            return false;
        }

        public virtual void Szul(int oszlop, int sor)
        {
        }

        public virtual void Meghal(int oszlop, int sor)
        {
        }
    }
}
