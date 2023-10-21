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
        public PictureBox KepDoboz { get; set; }

        public MezoAdat(int Ehesseg, int FuAllapot, PictureBox KepDoboz)
        {
            this.Ehesseg = Ehesseg;
            this.FuAllapot = FuAllapot;
            Mozgott = false;
            Szult = false;
            this.KepDoboz = KepDoboz;
        }

        public virtual void Frissites()
        {
            KepDoboz.Image = null;
            KepDoboz.BackgroundImage = Kepek.Fuvek.Images[FuAllapot];
        }

        public virtual void FuNo()
        {
            if (FuAllapot < 2)
            {
                FuAllapot++;
            }
            Frissites();
           
        }
        public void KorVege()
        {
            Szult = false;
            Mozgott = false;
            if (Ehesseg != 0)
            {
                Ehesseg--;
            }
            FuNo();
        }

        public virtual void Mozog(int oszlopok, int sorok)
        {
        }

        public virtual bool Eszik(int oszlopok, int sorok)
        {
            return false;
        }

        public virtual void Szul(int oszlopok, int sorok)
        {
        }

        public virtual void Meghal(int oszlopok, int sorok)
        {
        }
    }
}
