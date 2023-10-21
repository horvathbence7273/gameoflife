using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public static class Korulotte
    {
        public static MezoAdat[] Egyel(int oszlop, int sor)
        {
            MezoAdat[] korulotte = { null, null, null, null };

            if (oszlop + 1 == Adatok.Mezo.GetLength(0))
            {
                korulotte[0] = new MezoAdat(-1, -1, null);
            }
            
            if (sor + 1 == Adatok.Mezo.GetLength(1))
            {
                korulotte[1] = new MezoAdat(-1, -1, null);
            }

            if (oszlop - 1 < 0)
            {
                korulotte[2] = new MezoAdat(-1, -1, null);
            }

            if (sor - 1 < 0)
            {
                korulotte[3] = new MezoAdat(-1, -1, null);
            }

            for (int i = 0; i < 4; i++)
            {
                if (korulotte[i] == null)
                {
                    switch (i)
                    {
                        case 0:
                            korulotte[i] = Adatok.Mezo[oszlop + 1, sor];
                            break;
                        case 1:
                            korulotte[i] = Adatok.Mezo[oszlop, sor + 1];
                            break;
                        case 2:
                            korulotte[i] = Adatok.Mezo[oszlop - 1, sor];
                            break;
                        case 3:
                            korulotte[i] = Adatok.Mezo[oszlop, sor - 1];
                            break;
                    }
                }
            }
            return korulotte;
        }

        public static MezoAdat[] Kettovel(int oszlop, int sor)
        {
            MezoAdat[] korulotte = { null, null, null, null };

            if (oszlop + 2 >= Adatok.Mezo.GetLength(0))
            {
                korulotte[0] = new MezoAdat(-1, -1, null);
            }

            if (sor + 2 >= Adatok.Mezo.GetLength(1))
            {
                korulotte[1] = new MezoAdat(-1, -1, null);
            }

            if (oszlop - 2 < 0)
            {
                korulotte[2] = new MezoAdat(-1, -1, null);
            }

            if (sor - 2 < 0)
            {
                korulotte[3] = new MezoAdat(-1, -1, null);
            }

            for (int i = 0; i < 4; i++)
            {
                if (korulotte[i] == null)
                {
                    switch (i)
                    {
                        case 0:
                            korulotte[i] = Adatok.Mezo[oszlop + 2, sor];
                            break;
                        case 1:
                            korulotte[i] = Adatok.Mezo[oszlop, sor + 2];
                            break;
                        case 2:
                            korulotte[i] = Adatok.Mezo[oszlop - 2, sor];
                            break;
                        case 3:
                            korulotte[i] = Adatok.Mezo[oszlop, sor - 2];
                            break;
                    }
                }
            }
            return korulotte;
        }

    }
}
