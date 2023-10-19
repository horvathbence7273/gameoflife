using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public class Nyul
    {
        Random rnd = new Random();
        private List<KeretAdat> Keret { get; set; }

        public void NyulSzul(List<KeretAdat[]> Keret, int i, int j, int k, int l, KeretAdat[] seged)
        {
            Keret[i][j].Allat = "Nyul";
            Keret[i][j].Ehesseg = 5;
            Keret[i][j].Szult = true;
            Keret[i][j].Mozgas = true;
            Keret[i][j].Frissites();
            Keret[k][l].Mozgas = false;
            Keret[k][l].Szult = true;
            seged.Where(x => x.Allat == "Nyul").First().Szult = true;
        }

        public void NyulMozgas(List<KeretAdat[]> Keret, int i, int j, int k, int l)
        {
            Keret[k][l].Ehesseg = Keret[i][j].Ehesseg - 1;
            Keret[k][l].Allat = "Nyul";
            Keret[k][l].Mozgas = true;
            Keret[k][l].Szult = true;
            Keret[k][l].Frissites();
            Keret[i][j].Allat = null;
            Keret[i][j].Ehesseg = 0;
            Keret[i][j].Frissites();
        }

        public void Meghal(List<KeretAdat[]> Keret, int i, int j)
        {
            Keret[i][j].Allat = null;
            Keret[i][j].Ehesseg = 0;
            Keret[i][j].Frissites();
        }

        public bool NemSzultEsVanMelletteNyul(List<KeretAdat[]> Keret, KeretAdat[] seged, int i , int j)
        {
            if (Keret[i][j].Mozgas == true && Keret[i][j].Szult == false && Array.Exists(seged, x => x.Allat == "Nyul")&& Array.Exists(seged, x => x.Allat == null))
            {
                return true;
            }
            return false;
        }

        public bool SzultNemMozgottEsVanHely(List<KeretAdat[]> Keret, KeretAdat[] seged, int i, int j)
        {
            if (Keret[i][j].Szult == true && Array.Exists(seged, x => x.Allat == null))
            {
                return true;
            }
            return false;
        }

        public bool SzulesFeltetelek(List<KeretAdat[]> Keret, KeretAdat[] seged, int i, int j)
        {
            if (Keret[i][j].Szult == false && Keret[i][j].Allat == "Nyul" && Keret[i][j].Mozgas == false && Array.Exists(seged, x => x.Allat == "Nyul") && seged.Where(x => x.Allat == "Nyul").First().Szult == false && Array.Exists(seged, x => x.Allat == null))
            {
                return true;
            }
            return false;
        }

        public void NyulAction(int oszlop, int sorok, List<KeretAdat[]> Keret)
        {
            for (int i = 0; i < oszlop; i++)
            {
                for (int j = 0; j < sorok; j++)
                {
                    KeretAdat[] seged = new KeretAdat[4];

                    try
                    {
                        seged[0] = Keret[i + 1][j];
                    }
                    catch
                    {
                        seged[0] = new KeretAdat("void", -1, -1, null, null);
                    }
                    try
                    {
                        seged[1] = Keret[i][j + 1];
                    }
                    catch
                    {
                        seged[1] = new KeretAdat("void", -1, -1, null, null);
                    }
                    try
                    {
                        seged[2] = Keret[i - 1][j];
                    }
                    catch
                    {
                        seged[2] = new KeretAdat("void", -1, -1, null, null);
                    }
                    try
                    {
                        seged[3] = Keret[i][j - 1];
                    }
                    catch
                    {
                        seged[3] = new KeretAdat("void", -1, -1, null, null);
                    }

                    if (Keret[i][j].Allat == "Nyul" && Keret[i][j].Ehesseg <= 0)
                    {
                        Meghal(Keret, i, j);
                    }

                    if (Keret[i][j].Allat == "Nyul")
                    {
                        if (SzulesFeltetelek(Keret, seged, i, j))
                        {
                            switch (Array.IndexOf(seged, seged.Where(x => x.Allat == null && x.Allat != "void").First()))
                            {
                                case 0:

                                    NyulSzul(Keret, i + 1, j, i, j, seged);
                                    seged[0] = Keret[i + 1][j];
                                    break;
                                case 1:
                                    NyulSzul(Keret, i, j + 1, i, j, seged);
                                    seged[1] = Keret[i][j + 1];
                                    break;
                                case 2:
                                    NyulSzul(Keret, i - 1, j, i, j, seged);
                                    seged[2] = Keret[i - 1][j];
                                    break;
                                case 3:
                                    NyulSzul(Keret, i, j - 1, i, j, seged);
                                    seged[3] = Keret[i][j - 1];
                                    break;
                            }
                        }
                        if (Keret[i][j].FuAllapot > 0)
                        {
                            if (Keret[i][j].Ehesseg < 4)
                            {
                                Keret[i][j].Ehesseg += Keret[i][j].FuAllapot;
                            }
                            else if (Keret[i][j].Ehesseg == 4)
                            {
                                Keret[i][j].Ehesseg += 1;
                            }
                            Keret[i][j].FuAllapot = 0;
                            Keret[i][j].Ehesseg -= 1;
                            Keret[i][j].Mozgas = true;
                            Keret[i][j].Frissites();
                        }
                        else if (Keret[i][j].Mozgas == false && Array.Exists(seged, x => x.Allat == null))
                        {
                            KeretAdat legnagyobb = seged.OrderByDescending(x => x.FuAllapot).Where(x => x.Allat == null).First();
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
                                    NyulMozgas(Keret, i, j, i, j - 1);
                                    break;
                            }
                        }
                    }
                    else if (Keret[i][j].Allat == "Nyul" && Keret[i][j].Mozgas == false && Array.Exists(seged, x => x.Allat == null))
                    {
                        int szam = 0;
                        do
                        {
                            szam = rnd.Next(0, 4);
                        }
                        while (seged[szam].Allat != null);
                        switch (szam)
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
                                NyulMozgas(Keret, i, j, i, j - 1);
                                break;
                        }
                    }
                    if (Keret[i][j].Mozgas == false)
                    {
                        Keret[i][j].Ehesseg -= 1;
                    }
                }
            }
        }
    }
}
