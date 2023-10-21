using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    internal sealed class Nyul : MezoAdat
    {
        public Nyul(int Ehesseg, int FuAllapot, PictureBox KepDoboz) : base(Ehesseg, FuAllapot, KepDoboz)
        {
        }
        public override void Frissites()
        {
            KepDoboz.Image = Kepek.Allatok.Images[0];
            KepDoboz.BackgroundImage = Kepek.Fuvek.Images[FuAllapot];

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

                switch (random)
                {
                    case 0:
                        hovaFu = Adatok.Mezo[oszlop + 1, sor].FuAllapot;
                        Adatok.Mezo[oszlop + 1, sor] = Adatok.Mezo[oszlop, sor];
                        Adatok.Mezo[oszlop + 1, sor].Mozgott = true;
                        Adatok.Mezo[oszlop + 1, sor].FuAllapot = hovaFu;
                        Adatok.Mezo[oszlop, sor] = new MezoAdat(0, Adatok.Mezo[oszlop, sor].FuAllapot, Adatok.Mezo[oszlop + 1, sor].KepDoboz);
                        Adatok.Mezo[oszlop + 1, sor].Frissites();
                        break;
                    case 1:
                        hovaFu = Adatok.Mezo[oszlop, sor +  1].FuAllapot;
                        Adatok.Mezo[oszlop, sor + 1] = Adatok.Mezo[oszlop, sor];
                        Adatok.Mezo[oszlop, sor + 1].Mozgott = true;
                        Adatok.Mezo[oszlop, sor + 1].FuAllapot = hovaFu;
                        Adatok.Mezo[oszlop, sor] = new MezoAdat(0, Adatok.Mezo[oszlop, sor].FuAllapot, Adatok.Mezo[oszlop, sor + 1].KepDoboz);
                        Adatok.Mezo[oszlop, sor + 1].Frissites();
                        break;
                    case 2:
                        hovaFu = Adatok.Mezo[oszlop - 1, sor].FuAllapot;
                        Adatok.Mezo[oszlop - 1, sor] = Adatok.Mezo[oszlop, sor];
                        Adatok.Mezo[oszlop - 1, sor].Mozgott = true;
                        Adatok.Mezo[oszlop - 1, sor].FuAllapot = hovaFu;
                        Adatok.Mezo[oszlop, sor] = new MezoAdat(0, Adatok.Mezo[oszlop, sor].FuAllapot, Adatok.Mezo[oszlop - 1, sor].KepDoboz);
                        Adatok.Mezo[oszlop - 1, sor].Frissites();
                        break;
                    case 3:
                        hovaFu = Adatok.Mezo[oszlop, sor - 1].FuAllapot;
                        Adatok.Mezo[oszlop, sor - 1] = Adatok.Mezo[oszlop, sor];
                        Adatok.Mezo[oszlop, sor - 1].Mozgott = true;
                        Adatok.Mezo[oszlop, sor - 1].FuAllapot = hovaFu;
                        Adatok.Mezo[oszlop, sor] = new MezoAdat(0, Adatok.Mezo[oszlop, sor].FuAllapot, Adatok.Mezo[oszlop, sor - 1].KepDoboz);
                        Adatok.Mezo[oszlop, sor - 1].Frissites();
                        break;
                }
            }
        }
        public override bool Eszik(int oszlop, int sor)
        {
            if (Ehesseg < 5 && FuAllapot != 0)
            {
                if (Ehesseg < 4)
                {
                    Ehesseg += FuAllapot;
                    if (FuAllapot == 2)
                    {
                        FuAllapot = 1;
                    }
                    else
                    {
                        FuAllapot = 0;
                    }
                }
                else if (Ehesseg == 4)
                {
                    if (FuAllapot == 1)
                    {
                        Ehesseg += FuAllapot;
                        FuAllapot = 0;
                    }
                    else
                    {
                        return false;
                    }
                }
                FuAllapot = 0;
                Ehesseg -= 1;
                Mozgott = true;
                Frissites();
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
            int hovaFu;
            if (korulotte.Any(x => x is MezoAdat && x.FuAllapot != -1) && korulotte.Any(x=>x is Nyul && x.Szult == false))
            {
                do
                {
                    random = rnd.rand.Next(0, 4);
                }
                while (korulotte[random].FuAllapot != korulotte.Max(x => x.FuAllapot));

                switch (random)
                {
                    case 0:
                        hovaFu = Adatok.Mezo[oszlop + 1, sor].FuAllapot;
                        Adatok.Mezo[oszlop + 1, sor] = new Nyul(5, hovaFu, Adatok.Mezo[oszlop + 1, sor].KepDoboz);
                        Adatok.Mezo[oszlop + 1, sor].Mozgott = true;
                        Adatok.Mezo[oszlop + 1, sor].Szult = true;
                        Adatok.Mezo[oszlop + 1, sor].Frissites();
                        korulotte.First(x=>x is Nyul).Szult = true;
                        Szult = true;
                        break;
                    case 1:
                        hovaFu = Adatok.Mezo[oszlop, sor + 1].FuAllapot;
                        Adatok.Mezo[oszlop, sor + 1] = new Nyul(5, hovaFu, Adatok.Mezo[oszlop, sor + 1].KepDoboz);
                        Adatok.Mezo[oszlop, sor + 1].Mozgott = true;
                        Adatok.Mezo[oszlop, sor + 1].Szult = true;
                        Adatok.Mezo[oszlop, sor + 1].Frissites();
                        korulotte.First(x => x is Nyul).Szult = true;
                        Szult = true;
                        break;
                    case 2:
                        hovaFu = Adatok.Mezo[oszlop - 1, sor].FuAllapot;
                        Adatok.Mezo[oszlop - 1, sor] = new Nyul(5, hovaFu, Adatok.Mezo[oszlop - 1, sor].KepDoboz);
                        Adatok.Mezo[oszlop - 1, sor].Mozgott = true;
                        Adatok.Mezo[oszlop - 1, sor].Szult = true;
                        Adatok.Mezo[oszlop - 1, sor].Frissites();
                        korulotte.First(x => x is Nyul).Szult = true;
                        Szult = true;
                        break;
                    case 3:
                        hovaFu = Adatok.Mezo[oszlop, sor - 1].FuAllapot;
                        Adatok.Mezo[oszlop, sor - 1] = new Nyul(5, hovaFu, Adatok.Mezo[oszlop, sor - 1].KepDoboz);
                        Adatok.Mezo[oszlop, sor - 1].Mozgott = true;
                        Adatok.Mezo[oszlop, sor - 1].Szult = true;
                        Adatok.Mezo[oszlop, sor - 1].Frissites();
                        korulotte.First(x => x is Nyul).Szult = true;
                        Szult = true;
                        break;
                }
            }
        }
        public override void Meghal(int oszlop, int sor)
        {
            if (Ehesseg <= 0)
            {
                Adatok.Mezo[oszlop, sor] = new MezoAdat(0,Adatok.Mezo[oszlop, sor].FuAllapot, Adatok.Mezo[oszlop, sor].KepDoboz);
            }

        }

        public override void FuNo()
        {
            // Method intentionally left empty.
        }
    }
}
