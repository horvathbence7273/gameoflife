using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    internal class Nyul : KeretAdat
    {

        public void NyulAction(int oszlop, int sorok, List<KeretAdat[]> Keret)
        {
            int i = oszlop;
            int j = sorok;
            KeretAdat[] seged = { Keret[i + 1][j], Keret[i][j + 1], Keret[i - 1][j], Keret[i][j - 1] };



            if (Keret[i][j].Allat == "Nyul" && Keret[i][j].Ehesseg >= 1)
            {
                if (Szult == false && Array.Exists(seged,x=>x.Allat == "Nyul"))
                {

                    switch (Array.IndexOf(seged, seged.Where(x=>x.Allat == null).First()))
                    {
                        case 0:
                            Keret[i + 1][j].Allat = "Nyul";
                            Keret[i + 1][j].Ehesseg = 5;
                            Keret[i + 1][j].Szult = true;
                            Keret[i + 1][j].Mozgas = true;
                            Keret[i + 1][j].Frissites();
                            break;
                        case 1:
                            Keret[i][j + 1].Allat = "Nyul";
                            Keret[i][j + 1].Ehesseg = 5;
                            Keret[i][j + 1].Szult = true;
                            Keret[i][j + 1].Mozgas = true;
                            Keret[i][j + 1].Frissites();
                            break;
                        case 2:
                            Keret[i - 1][j].Allat = "Nyul";
                            Keret[i - 1][j].Ehesseg = 5;
                            Keret[i - 1][j].Szult = true;
                            Keret[i - 1][j].Mozgas = true;
                            Keret[i - 1][j].Frissites();
                            break;
                        case 3:
                            Keret[i][j - 1].Allat = "Nyul";
                            Keret[i][j - 1].Ehesseg = 5;
                            Keret[i][j - 1].Szult = true;
                            Keret[i][j - 1].Mozgas = true;
                            Keret[i][j - 1].Frissites();
                            break;
                    }
                }

                if (Szult == false && Mozgas == false && Array.Exists(seged, x => x.Allat == null))
                {
                    KeretAdat legnagyobb = seged.OrderBy(x => x.FuAllapot).Where(x => x.Allat == null).First();
                    switch (Array.IndexOf(seged, legnagyobb))
                    {
                        case 0:
                            Keret[i][j].Allat = null;
                            Keret[i][j].Ehesseg = 0;
                            Keret[i + 1][j].Allat = "Nyul";
                            Keret[i + 1][j].Ehesseg = 5;
                            Keret[i + 1][j].Mozgas = true;
                            Keret[i + 1][j].Frissites();
                            Frissites();
                            break;
                        case 1:
                            Keret[i][j].Allat = null;
                            Keret[i][j].Ehesseg = 0;
                            Keret[i][j + 1].Allat = "Nyul";
                            Keret[i][j + 1].Ehesseg = 5;
                            Keret[i][j + 1].Mozgas = true;
                            Keret[i][j + 1].Frissites();
                            Frissites();
                            break;
                        case 2:
                            Keret[i][j].Allat = null;
                            Keret[i][j].Ehesseg = 0;
                            Keret[i - 1][j].Allat = "Nyul";
                            Keret[i - 1][j].Ehesseg = 5;
                            Keret[i - 1][j].Mozgas = true;
                            Keret[i - 1][j].Frissites();
                            Frissites();
                            break;
                        case 3:
                            Keret[i][j].Allat = null;
                            Keret[i][j].Ehesseg = 0;
                            Keret[i][j - 1].Allat = "Nyul";
                            Keret[i][j - 1].Ehesseg = 5;
                            Keret[i][j - 1].Mozgas = true;
                            Keret[i][j - 1].Frissites();
                            Frissites();
                            break;
                    }
                }
            }
            else
            {
                Keret[i][j].Allat = null;
                Keret[i][j].Ehesseg = 0;
            }


        }
    }
}
