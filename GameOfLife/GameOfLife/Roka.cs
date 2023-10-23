using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    internal sealed class Roka : MezoAdat
    {
        public Roka(int Ehesseg, int FuAllapot) : base(Ehesseg, FuAllapot)
        {
        }

        public override void Frissites(int oszlop, int sor)
        {
            Kepek.KepMezo[oszlop, sor].Image = Kepek.Allatok.Images[1];
            Kepek.KepMezo[oszlop, sor].BackgroundImage = Kepek.Fuvek.Images[FuAllapot];

        }
        public override void Mozog(int oszlop, int sor)
        {
            MezoAdat[] korulotte = Korulotte.Egyel(oszlop, sor);
            int random;
            int hovaFu;
            if (korulotte.Any(x => x is MezoAdat && x.FuAllapot != -1))
            {
                do
                {
                    random = rnd.rand.Next(0, 4);
                }
                while (korulotte[random].FuAllapot == -1);

                int[] hova = Hova.Egyre(random, oszlop, sor);

                hovaFu = Adatok.Mezo[hova[0], hova[1]].FuAllapot;
                Adatok.Mezo[hova[0], hova[1]] = Adatok.Mezo[oszlop, sor];
                Adatok.Mezo[hova[0], hova[1]].Mozgott = true;
                Adatok.Mezo[hova[0], hova[1]].FuAllapot = hovaFu;
                Adatok.Mezo[oszlop, sor] = new MezoAdat(0, Adatok.Mezo[oszlop, sor].FuAllapot);
                Adatok.Mezo[oszlop, sor].Frissites(oszlop, sor);
                Adatok.Mezo[hova[0], hova[1]].Frissites(oszlop, sor);
            }
        }
        public override bool Eszik(int oszlop, int sor)
        {
            MezoAdat[] korulotte1 = Korulotte.Egyel(oszlop, sor);
            MezoAdat[] korulotte2 = Korulotte.Kettovel(oszlop, sor);
            int random;
            int hovaFu;
            if (korulotte1.Any(x => x is Nyul))
            {
                do
                {
                    random = rnd.rand.Next(0, 4);
                }
                while (korulotte1[random] is Nyul == false);

                int[] hova = Hova.Egyre(random, oszlop, sor);
                
                hovaFu = Adatok.Mezo[hova[0], hova[1]].FuAllapot;
                Adatok.Mezo[hova[0], hova[1]] = Adatok.Mezo[oszlop, sor];
                if (Adatok.Mezo[hova[0], hova[1]].Ehesseg + 3 > 10)
                {
                    Adatok.Mezo[hova[0], hova[1]].Ehesseg = 10;
                }
                else
                {
                    Adatok.Mezo[hova[0], hova[1]].Ehesseg += 3;
                }
                Adatok.Mezo[hova[0], hova[1]].Mozgott = true;
                Adatok.Mezo[hova[0], hova[1]].FuAllapot = hovaFu;
                Adatok.Mezo[oszlop, sor] = new MezoAdat(0, Adatok.Mezo[oszlop, sor].FuAllapot);
                Adatok.Mezo[oszlop, sor].Frissites(oszlop, sor);
                Adatok.Mezo[hova[0], hova[1]].Frissites(oszlop, sor);
                return true;
            }
            else if(korulotte2.Any(x => x is Nyul))
            {
                do
                {
                    random = rnd.rand.Next(0, 4);
                }
                while (korulotte2[random] is Nyul == false);

                int[] hova = Hova.Ketoore(random, oszlop, sor);

                hovaFu = Adatok.Mezo[hova[0], hova[1]].FuAllapot;
                Adatok.Mezo[hova[0], hova[1]] = Adatok.Mezo[oszlop, sor];
                if (Adatok.Mezo[hova[0], hova[1]].Ehesseg + 3 > 10)
                {
                    Adatok.Mezo[hova[0], hova[1]].Ehesseg = 10;
                }
                else
                {
                    Adatok.Mezo[hova[0], hova[1]].Ehesseg += 3;
                }
                Adatok.Mezo[hova[0], hova[1]].Mozgott = true;
                Adatok.Mezo[hova[0], hova[1]].FuAllapot = hovaFu;
                Adatok.Mezo[oszlop, sor] = new MezoAdat(0, Adatok.Mezo[oszlop, sor].FuAllapot);
                Adatok.Mezo[oszlop, sor].Frissites(oszlop, sor);
                Adatok.Mezo[hova[0], hova[1]].Frissites(oszlop, sor);
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
            if (korulotte.Any(x => x is MezoAdat && x.FuAllapot != -1) && korulotte.Any(x => x is Roka))
            {
                do
                {
                    random = rnd.rand.Next(0, 4);
                }
                while (korulotte[random] is MezoAdat == false || korulotte[random].FuAllapot == -1);

                int[] hova = Hova.Egyre(random, oszlop, sor);
                Adatok.Mezo[hova[0], hova[1]] = new Roka(5, Adatok.Mezo[hova[0], hova[1]].FuAllapot);
                Adatok.Mezo[hova[0], hova[1]].Mozgott = true;
                Adatok.Mezo[hova[0], hova[1]].Szult = true;
                Adatok.Mezo[hova[0], hova[1]].Frissites(oszlop, sor);
                korulotte.First(x => x is Roka).Szult = true;
                Szult = true;
            }
        }
        public override void Meghal(int oszlop, int sor)
        {
            if (Ehesseg <= 0)
            {
                Adatok.Mezo[oszlop, sor] = new MezoAdat(0, Adatok.Mezo[oszlop, sor].FuAllapot);
            }

        }
    }
}
