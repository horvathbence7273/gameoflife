using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    internal sealed class Nyul : MezoAdat
    {
        public Nyul(int Ehesseg, int FuAllapot) : base(Ehesseg, FuAllapot)
        {
        }
        public override void Frissites(int oszlop, int sor)
        {
            Kepek.KepMezo[oszlop, sor].Image = Kepek.Allatok.Images[0];
            Kepek.KepMezo[oszlop, sor].BackgroundImage = Kepek.Fuvek.Images[FuAllapot];

        }
        public override void Mozog(int oszlop, int sor)
        {
            MezoAdat[] korulotte = Korulotte.Egyel(oszlop, sor);
            int random;
            int hovaFu;
            if (korulotte.Any(x=>x is MezoAdat && x.FuAllapot != -1))
            {
                do
                {
                    random = rnd.rand.Next(0, 4);
                }
                while (korulotte[random].FuAllapot != korulotte.Max(x=>x.FuAllapot));

                int[] hova = Hova.Egyre(random, oszlop, sor);
             
                hovaFu = Adatok.Mezo[hova[0], hova[1]].FuAllapot;
                Adatok.Mezo[hova[0], hova[1]] = Adatok.Mezo[oszlop, sor];
                Adatok.Mezo[hova[0], hova[1]].Mozgott = true;
                Adatok.Mezo[hova[0], hova[1]].FuAllapot = hovaFu;
                Adatok.Mezo[oszlop, sor] = new MezoAdat(0, Adatok.Mezo[oszlop, sor].FuAllapot);
                Adatok.Mezo[hova[0], hova[1]].Frissites(oszlop, sor);
                Adatok.Mezo[oszlop, sor].Frissites(oszlop, sor);
            }
        }
        public override bool Eszik(int oszlop, int sor)
        {
            if (Ehesseg < 5 && FuAllapot != 0)
            {
                if (Ehesseg == 4 && FuAllapot == 2)
                {
                    return false;
                }
                Ehesseg += FuAllapot;
                if (Ehesseg < 5)
                {
                    Ehesseg = 5;
                }
                FuAllapot -= 1;
                Mozgott = true;
                Frissites(oszlop, sor);
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void Szul(int oszlop, int sor)
        {
            MezoAdat[] korulotte = Korulotte.Egyel(oszlop, sor);
            int random;
            if (korulotte.Any(x => x is MezoAdat && x.FuAllapot != -1) && korulotte.Any(x=>x is Nyul && x.Szult == false) && Szult == false)
            {
                do
                {
                    random = rnd.rand.Next(0, 4);
                }
                while (korulotte[random] is MezoAdat == false || korulotte[random].FuAllapot == -1);

                int[] hova = Hova.Egyre(random, oszlop, sor);

                Adatok.Mezo[hova[0], hova[1]] = new Nyul(5, Adatok.Mezo[hova[0], hova[1]].FuAllapot);
                Adatok.Mezo[hova[0], hova[1]].Mozgott = true;
                Adatok.Mezo[hova[0], hova[1]].Szult = true;
                Adatok.Mezo[hova[0], hova[1]].Frissites(oszlop, sor);
                korulotte.First(x => x is Nyul).Szult = true;
                Szult = true;
            }
        }
        public override void Meghal(int oszlop, int sor)
        {
            if (Ehesseg <= 0)
            {
                Adatok.Mezo[oszlop, sor] = new MezoAdat(0,Adatok.Mezo[oszlop, sor].FuAllapot);
            }

        }

        public override void FuNo(int oszlop, int sor)
        {
            FuAllapot = FuAllapot;
            Frissites(oszlop, sor);
        }
    }
}
