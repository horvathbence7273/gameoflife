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
        public Roka(int Ehesseg, int FuAllapot, PictureBox KepDoboz) : base(Ehesseg, FuAllapot, KepDoboz)
        {
        }

        public override void Frissites()
        {
            KepDoboz.Image = Kepek.Allatok.Images[1];
            KepDoboz.BackgroundImage = Kepek.Fuvek.Images[FuAllapot];

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
                while (korulotte[random].FuAllapot != -1);

                switch (random)
                {
                    case 0:
                        hovaFu = Adatok.Mezo[oszlop + 1, sor].FuAllapot;
                        Adatok.Mezo[oszlop + 1, sor] = Adatok.Mezo[oszlop, sor];
                        Adatok.Mezo[oszlop + 1, sor].Mozgott = true;
                        Adatok.Mezo[oszlop + 1, sor].FuAllapot = hovaFu;
                        Adatok.Mezo[oszlop, sor] = new MezoAdat(0, Adatok.Mezo[oszlop, sor].FuAllapot, Adatok.Mezo[oszlop + 1, sor].KepDoboz);
                        Frissites();
                        break;
                    case 1:
                        hovaFu = Adatok.Mezo[oszlop, sor + 1].FuAllapot;
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
            MezoAdat[] korulotte1 = Korulotte.Egyel(oszlop, sor);
            MezoAdat[] korulotte2 = Korulotte.Kettovel(oszlop, sor);
            int random;
            int hovaFu;
            if (korulotte1.Any(x => x is Nyul && x.FuAllapot != -1))
            {
                do
                {
                    random = rnd.rand.Next(0, 4);
                }
                while (korulotte1[random] is Nyul == false);

                switch (random)
                {
                    case 0:
                        hovaFu = Adatok.Mezo[oszlop + 1, sor].FuAllapot;
                        Adatok.Mezo[oszlop + 1, sor] = Adatok.Mezo[oszlop, sor];
                        if (Adatok.Mezo[oszlop + 1, sor].Ehesseg + 3 > 10)
                        {
                            Adatok.Mezo[oszlop + 1, sor].Ehesseg = 10;
                        }
                        else
                        {
                            Adatok.Mezo[oszlop + 1, sor].Ehesseg += 3;
                        }
                        Adatok.Mezo[oszlop + 1, sor].Mozgott = true;
                        Adatok.Mezo[oszlop + 1, sor].FuAllapot = hovaFu;
                        Adatok.Mezo[oszlop, sor] = new MezoAdat(0, Adatok.Mezo[oszlop, sor].FuAllapot, Adatok.Mezo[oszlop + 1, sor].KepDoboz);
                        Adatok.Mezo[oszlop + 1, sor].Frissites();
                        return true;
                    case 1:
                        hovaFu = Adatok.Mezo[oszlop, sor + 1].FuAllapot;
                        Adatok.Mezo[oszlop, sor + 1] = Adatok.Mezo[oszlop, sor];
                        if (Adatok.Mezo[oszlop, sor + 1].Ehesseg + 3 > 10)
                        {
                            Adatok.Mezo[oszlop, sor + 1].Ehesseg = 10;
                        }
                        else
                        {
                            Adatok.Mezo[oszlop, sor + 1].Ehesseg += 3;
                        }
                        Adatok.Mezo[oszlop, sor + 1].Mozgott = true;
                        Adatok.Mezo[oszlop, sor + 1].FuAllapot = hovaFu;
                        Adatok.Mezo[oszlop, sor] = new MezoAdat(0, Adatok.Mezo[oszlop, sor].FuAllapot, Adatok.Mezo[oszlop, sor + 1].KepDoboz);
                        Adatok.Mezo[oszlop, sor + 1].Frissites();
                        return true;
                    case 2:
                        hovaFu = Adatok.Mezo[oszlop - 1, sor].FuAllapot;
                        Adatok.Mezo[oszlop - 1, sor] = Adatok.Mezo[oszlop, sor];
                        if (Adatok.Mezo[oszlop - 1, sor].Ehesseg + 3 > 10)
                        {
                            Adatok.Mezo[oszlop - 1, sor].Ehesseg = 10;
                        }
                        else
                        {
                            Adatok.Mezo[oszlop - 1, sor].Ehesseg += 3;
                        }
                        Adatok.Mezo[oszlop - 1, sor].Mozgott = true;
                        Adatok.Mezo[oszlop - 1, sor].FuAllapot = hovaFu;
                        Adatok.Mezo[oszlop, sor] = new MezoAdat(0, Adatok.Mezo[oszlop, sor].FuAllapot, Adatok.Mezo[oszlop - 1, sor].KepDoboz);
                        Adatok.Mezo[oszlop - 1, sor].Frissites();
                        return true;
                    case 3:
                        hovaFu = Adatok.Mezo[oszlop, sor - 1].FuAllapot;
                        Adatok.Mezo[oszlop, sor - 1] = Adatok.Mezo[oszlop, sor];
                        if (Adatok.Mezo[oszlop, sor - 1].Ehesseg + 3 > 10)
                        {
                            Adatok.Mezo[oszlop, sor - 1].Ehesseg = 10;
                        }
                        else
                        {
                            Adatok.Mezo[oszlop, sor - 1].Ehesseg += 3;
                        }
                        Adatok.Mezo[oszlop, sor - 1].Mozgott = true;
                        Adatok.Mezo[oszlop, sor - 1].FuAllapot = hovaFu;
                        Adatok.Mezo[oszlop, sor] = new MezoAdat(0, Adatok.Mezo[oszlop, sor].FuAllapot, Adatok.Mezo[oszlop, sor - 1].KepDoboz);
                        Adatok.Mezo[oszlop, sor - 1].Frissites();
                        return true;
                    default:
                        return false;

                }
            }
            else if(korulotte2.Any(x => x is Nyul && x.FuAllapot != -1))
            {
                do
                {
                    random = rnd.rand.Next(0, 4);
                }
                while (korulotte2[random] is Nyul == false);

                switch (random)
                {
                    case 0:
                        hovaFu = Adatok.Mezo[oszlop + 2, sor].FuAllapot;
                        Adatok.Mezo[oszlop + 2, sor] = Adatok.Mezo[oszlop, sor];
                        if (Adatok.Mezo[oszlop + 2, sor].Ehesseg + 3 > 10)
                        {
                            Adatok.Mezo[oszlop + 2, sor].Ehesseg = 10;
                        }
                        else
                        {
                            Adatok.Mezo[oszlop + 2, sor].Ehesseg += 3;
                        }
                        Adatok.Mezo[oszlop + 2, sor].Mozgott = true;
                        Adatok.Mezo[oszlop + 2, sor].FuAllapot = hovaFu;
                        Adatok.Mezo[oszlop, sor] = new MezoAdat(0, Adatok.Mezo[oszlop, sor].FuAllapot, Adatok.Mezo[oszlop + 2, sor].KepDoboz);
                        Adatok.Mezo[oszlop + 2, sor].Frissites();
                        return true;
                    case 1:
                        hovaFu = Adatok.Mezo[oszlop, sor + 2].FuAllapot;
                        Adatok.Mezo[oszlop, sor + 2] = Adatok.Mezo[oszlop, sor];
                        if (Adatok.Mezo[oszlop, sor + 2].Ehesseg + 3 > 10)
                        {
                            Adatok.Mezo[oszlop, sor + 2].Ehesseg = 10;
                        }
                        else
                        {
                            Adatok.Mezo[oszlop, sor + 2].Ehesseg += 3;
                        }
                        Adatok.Mezo[oszlop, sor + 2].Mozgott = true;
                        Adatok.Mezo[oszlop, sor + 2].FuAllapot = hovaFu;
                        Adatok.Mezo[oszlop, sor] = new MezoAdat(0, Adatok.Mezo[oszlop, sor].FuAllapot, Adatok.Mezo[oszlop, sor + 2].KepDoboz);
                        Adatok.Mezo[oszlop, sor + 2].Frissites();
                        return true;
                    case 2:
                        hovaFu = Adatok.Mezo[oszlop - 2, sor].FuAllapot;
                        Adatok.Mezo[oszlop - 2, sor] = Adatok.Mezo[oszlop, sor];
                        if (Adatok.Mezo[oszlop - 2, sor].Ehesseg + 3 > 10)
                        {
                            Adatok.Mezo[oszlop - 2, sor].Ehesseg = 10;
                        }
                        else
                        {
                            Adatok.Mezo[oszlop - 2, sor].Ehesseg += 3;
                        }
                        Adatok.Mezo[oszlop - 2, sor].Mozgott = true;
                        Adatok.Mezo[oszlop - 2, sor].FuAllapot = hovaFu;
                        Adatok.Mezo[oszlop, sor] = new MezoAdat(0, Adatok.Mezo[oszlop, sor].FuAllapot, Adatok.Mezo[oszlop - 2, sor].KepDoboz);
                        Adatok.Mezo[oszlop - 2, sor].Frissites();
                        return true;
                    case 3:
                        hovaFu = Adatok.Mezo[oszlop, sor - 2].FuAllapot;
                        Adatok.Mezo[oszlop, sor - 2] = Adatok.Mezo[oszlop, sor];
                        if (Adatok.Mezo[oszlop, sor - 2].Ehesseg + 3 > 10)
                        {
                            Adatok.Mezo[oszlop, sor - 2].Ehesseg = 10;
                        }
                        else
                        {
                            Adatok.Mezo[oszlop, sor - 2].Ehesseg += 3;
                        }
                        Adatok.Mezo[oszlop, sor - 2].Mozgott = true;
                        Adatok.Mezo[oszlop, sor - 2].FuAllapot = hovaFu;
                        Adatok.Mezo[oszlop, sor] = new MezoAdat(0, Adatok.Mezo[oszlop, sor].FuAllapot, Adatok.Mezo[oszlop, sor - 2].KepDoboz);
                        Adatok.Mezo[oszlop, sor - 2].Frissites();
                        return true;
                    default:
                        return false;
                }
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
            if (korulotte.Any(x => x is MezoAdat && x.FuAllapot != -1) && korulotte.Any(x => x is Roka))
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
                        Adatok.Mezo[oszlop + 1, sor] = new Roka(5, hovaFu, Adatok.Mezo[oszlop + 1, sor].KepDoboz);
                        Adatok.Mezo[oszlop + 1, sor].Mozgott = true;
                        Adatok.Mezo[oszlop + 1, sor].Szult = true;
                        Adatok.Mezo[oszlop + 1, sor].Frissites();
                        korulotte.First(x => x is Roka).Szult = true;
                        Szult = true;
                        break;
                    case 1:
                        hovaFu = Adatok.Mezo[oszlop, sor + 1].FuAllapot;
                        Adatok.Mezo[oszlop, sor + 1] = new Roka(5, hovaFu, Adatok.Mezo[oszlop, sor + 1].KepDoboz);
                        Adatok.Mezo[oszlop, sor + 1].Mozgott = true;
                        Adatok.Mezo[oszlop, sor + 1].Szult = true;
                        Adatok.Mezo[oszlop, sor + 1].Frissites();
                        korulotte.First(x => x is Roka).Szult = true;
                        Szult = true;
                        break;
                    case 2:
                        hovaFu = Adatok.Mezo[oszlop - 1, sor].FuAllapot;
                        Adatok.Mezo[oszlop - 1, sor] = new Roka(5, hovaFu, Adatok.Mezo[oszlop - 1, sor].KepDoboz);
                        Adatok.Mezo[oszlop - 1, sor].Mozgott = true;
                        Adatok.Mezo[oszlop - 1, sor].Szult = true;
                        Adatok.Mezo[oszlop - 1, sor].Frissites();
                        korulotte.First(x => x is Roka).Szult = true;
                        Szult = true;
                        break;
                    case 3:
                        hovaFu = Adatok.Mezo[oszlop, sor - 1].FuAllapot;
                        Adatok.Mezo[oszlop, sor - 1] = new Roka(5, hovaFu, Adatok.Mezo[oszlop, sor - 1].KepDoboz);
                        Adatok.Mezo[oszlop, sor - 1].Mozgott = true;
                        Adatok.Mezo[oszlop, sor - 1].Szult = true;
                        Adatok.Mezo[oszlop, sor - 1].Frissites();
                        korulotte.First(x => x is Roka).Szult = true;
                        Szult = true;
                        break;
                }
            }
        }
        public override void Meghal(int oszlop, int sor)
        {
            if (Ehesseg <= 0)
            {
                Adatok.Mezo[oszlop, sor] = new MezoAdat(0, Adatok.Mezo[oszlop, sor].FuAllapot, Adatok.Mezo[oszlop, sor].KepDoboz);
            }

        }
    }
}
