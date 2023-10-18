using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    internal class Nyul : KeretAdat
    {
        public Nyul(string Allat, int Ehesseg, int FuAllapot, PictureBox kep, ImageList kepLista) : base(Allat, Ehesseg, FuAllapot, kep, kepLista)
        {
        }

        public void NyulSzul(List<KeretAdat[]> Keret, int i, int j, int k, int l)
        {
            Keret[i][j].Allat = "Nyul";
            Keret[i][j].Ehesseg = 5;
            Keret[i][j].Szult = true;
            Keret[i][j].Mozgas = true;
            Keret[i][j].Frissites();
            Keret[k][l].Mozgas = false;
            Keret[k][l].Szult = true;
        }
        public void NyulMozgas(List<KeretAdat[]> Keret, int i, int j, int k, int l)
        {
            
            Keret[k][l].Allat = "Nyul";
            Keret[k][l].Ehesseg = Keret[i][j].Ehesseg -1;
            Keret[k][l].Mozgas = true;
            Keret[k][l].Szult = false;
            Keret[k][l].Frissites();
            Keret[i][j].Allat = null;
            Keret[i][j].Ehesseg = 0;
            Frissites();
        }
        public void Meghal(List<KeretAdat[]> Keret, int i, int j)
        {
            Keret[i][j].Allat = null;
            Keret[i][j].Ehesseg = 0;
        }
        public bool NemSzultEsVanMelletteNyul(KeretAdat[] seged)
        {
            if (Szult == false && Array.Exists(seged, x => x.Allat == "Nyul"))
            {
                return true;
            }
            return false;
        }
        public bool SzultNemMozgottEsVanHely(KeretAdat[] seged)
        {
            if (Szult == true && Mozgas == false && Array.Exists(seged, x => x.Allat == null))
            {
                return true;
            }
            return false;
        }

        public void NyulAction(int oszlop, int sorok, List<KeretAdat[]> Keret)
        {
            int i = oszlop;
            int j = sorok;
            KeretAdat[] seged = { Keret[i + 1][j], Keret[i][j + 1], Keret[i - 1][j], Keret[i][j - 1] };
            if (Keret[i][j].Allat == "Nyul" && Keret[i][j].Ehesseg >= 1)
            {
                if (NemSzultEsVanMelletteNyul(seged))
                {
                    switch (Array.IndexOf(seged, seged.Where(x=>x.Allat == null).First()))
                    {
                        case 0:
                            NyulSzul(Keret, i + 1, j, i, j);
                            break;
                        case 1:
                            NyulSzul(Keret, i, j + 1, i, j);
                            break;
                        case 2:
                            NyulSzul(Keret, i - 1, j, i, j);
                            break;
                        case 3:
                            NyulSzul(Keret, i, j - 1, i, j);
                            break;
                    }
                }
                else if (SzultNemMozgottEsVanHely(seged))
                {
                    KeretAdat legnagyobb = seged.OrderBy(x => x.FuAllapot).Where(x => x.Allat == null).First();
                    switch (Array.IndexOf(seged, legnagyobb))
                    {
                        case 0:
                            NyulMozgas(Keret, i, j, i + 1, j);
                            break;
                        case 1:
                            NyulMozgas(Keret, i, j, i, j + 1);
                            break;
                        case 2:
                            NyulMozgas(Keret, i, j, i - 1, j);
                            break;
                        case 3:
                            NyulMozgas(Keret, i, j, i, j -1);
                            break;
                    }
                }
            }
            else if (Keret[i][j].Allat == "Nyul" && Keret[i][j].Ehesseg <= 0)
            {
                Meghal(Keret, i, j);
            }
        }
    }
}
