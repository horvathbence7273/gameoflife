using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    internal class Roka : KeretAdat
    {
        public Roka(string Allat, int Ehesseg, int FuAllapot, PictureBox kep, ImageList kepLista) : base(Allat, Ehesseg, FuAllapot, kep, kepLista)
        {
        }

        public void RokaSzul(List<KeretAdat[]> Keret, int i, int j, int k, int l)
        {
            Keret[i][j].Allat = "Roka";
            Keret[i][j].Ehesseg = 10;
            Keret[i][j].Szult = true;
            Keret[i][j].Mozgas = true;
            Keret[i][j].Frissites();
            Keret[k][l].Mozgas = false;
            Keret[k][l].Szult = true;
        }

        public void RokaMozgas(List<KeretAdat[]> Keret, int i, int j, int k, int l)
        {

            Keret[k][l].Allat = "Roka";
            Keret[k][l].Ehesseg = Keret[i][j].Ehesseg - 1;
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

        public bool NemSzultEsVanMelletteRoka(KeretAdat[] seged)
        {
            if (Szult == false && Array.Exists(seged, x => x.Allat == "Roka"))
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

        public void RokaAction(int oszlop, int sorok, List<KeretAdat[]> Keret)
        {
            int i = oszlop;
            int j = sorok;
            KeretAdat[] seged = { Keret[i + 1][j], Keret[i][j + 1], Keret[i - 1][j], Keret[i][j - 1] };
            if (Keret[i][j].Allat == "Roka" && Keret[i][j].Ehesseg >= 1)
            {
                if (NemSzultEsVanMelletteRoka(seged))
                {
                    switch (Array.IndexOf(seged, seged.Where(x => x.Allat == null).First()))
                    {
                        case 0:
                            RokaSzul(Keret, i + 1, j, i, j);
                            break;
                        case 1:
                            RokaSzul(Keret, i, j + 1, i, j);
                            break;
                        case 2:
                            RokaSzul(Keret, i - 1, j, i, j);
                            break;
                        case 3:
                            RokaSzul(Keret, i, j - 1, i, j);
                            break;
                    }
                }
                else if (SzultNemMozgottEsVanHely(seged))
                {
                    KeretAdat legkozelebbi = seged.OrderBy(x => x.Allat).Where(x => x.Allat == "Nyul").First();
                    switch (Array.IndexOf(seged, legnagyobb))
                    {
                        case 0:
                            RokaMozgas(Keret, i, j, i + 1, j);
                            KeretAdat legkozelebbi = seged.OrderBy(x => x.Allat).Where(x => x.Allat == "Nyul").First();
                            switch (Array.IndexOf(seged, legnagyobb))
                            {
                                case 0:
                                    RokaMozgas(Keret, i, j, i + 1, j);
                                    break;
                                case 1:
                                    RokaMozgas(Keret, i, j, i, j + 1);
                                    break;
                                case 2:
                                    RokaMozgas(Keret, i, j, i - 1, j);
                                    break;
                                case 3:
                                    RokaMozgas(Keret, i, j, i, j - 1);
                                    break;
                            }
                            break;
                        case 1:
                            RokaMozgas(Keret, i, j, i, j + 1);
                            KeretAdat legkozelebbi = seged.OrderBy(x => x.Allat).Where(x => x.Allat == "Nyul").First();
                            switch (Array.IndexOf(seged, legnagyobb))
                            {
                                case 0:
                                    RokaMozgas(Keret, i, j, i + 1, j);
                                    break;
                                case 1:
                                    RokaMozgas(Keret, i, j, i, j + 1);
                                    break;
                                case 2:
                                    RokaMozgas(Keret, i, j, i - 1, j);
                                    break;
                                case 3:
                                    RokaMozgas(Keret, i, j, i, j - 1);
                                    break;
                            }
                            break;
                        case 2:
                            RokaMozgas(Keret, i, j, i - 1, j);
                            KeretAdat legkozelebbi = seged.OrderBy(x => x.Allat).Where(x => x.Allat == "Nyul").First();
                            switch (Array.IndexOf(seged, legnagyobb))
                            {
                                case 0:
                                    RokaMozgas(Keret, i, j, i + 1, j);
                                    break;
                                case 1:
                                    RokaMozgas(Keret, i, j, i, j + 1);
                                    break;
                                case 2:
                                    RokaMozgas(Keret, i, j, i - 1, j);
                                    break;
                                case 3:
                                    RokaMozgas(Keret, i, j, i, j - 1);
                                    break;
                            }
                            break;
                        case 3:
                            RokaMozgas(Keret, i, j, i, j - 1);
                            KeretAdat legkozelebbi = seged.OrderBy(x => x.Allat).Where(x => x.Allat == "Nyul").First();
                            switch (Array.IndexOf(seged, legnagyobb))
                            {
                                case 0:
                                    RokaMozgas(Keret, i, j, i + 1, j);
                                    break;
                                case 1:
                                    RokaMozgas(Keret, i, j, i, j + 1);
                                    break;
                                case 2:
                                    RokaMozgas(Keret, i, j, i - 1, j);
                                    break;
                                case 3:
                                    RokaMozgas(Keret, i, j, i, j - 1);
                                    break;
                            }
                            break;
                    }
                }
            }
            else if (Keret[i][j].Allat == "Roka" && Keret[i][j].Ehesseg <= 0)
            {
                Meghal(Keret, i, j);
            }
        }
    }
}