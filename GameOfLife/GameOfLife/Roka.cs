using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public class Roka 
    {
        Random rnd = new Random();
        private List<KeretAdat> Keret { get; set; }

        public void RokaSzul(List<KeretAdat[]> Keret, int i, int j, int k, int l, KeretAdat[] seged)
        {
            Keret[i][j].Allat = "Roka";
            Keret[i][j].Ehesseg = 10;
            Keret[i][j].Szult = true;
            Keret[i][j].Mozgas = true;
            Keret[i][j].Frissites();
            Keret[k][l].Mozgas = false;
            Keret[k][l].Szult = true;
            seged.Where(x => x.Allat == "Roka").First().Szult = true;
        }

        public void RokaMozgas(List<KeretAdat[]> Keret, int i, int j, int k, int l)
        {
            Keret[k][l].Ehesseg = Keret[i][j].Ehesseg - 1;
            if (Keret[k][l].Allat == "Nyul")
            {
                if (Keret[k][l].Ehesseg <= 7)
                {
                    Keret[k][l].Ehesseg += 3;
                }
                else
                {
                    Keret[k][l].Ehesseg = 10;
                }
            }
            Keret[k][l].Allat = "Roka";
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

        public bool NemSzultEsVanMelletteRoka(List<KeretAdat[]> Keret, KeretAdat[] seged, int i, int j)
        {
            if (Keret[i][j].Szult == false && Array.Exists(seged, x => x.Allat == "Roka") && Array.Exists(seged, x => x.Allat == null))
            {
                return true;
            }
            return false;
        }

        public bool SzultNemMozgottEsVanHely(List<KeretAdat[]> Keret, KeretAdat[] seged, int i, int j)
        {
            if (Keret[i][j].Szult == true && Keret[i][j].Mozgas == false && Array.Exists(seged, x => x.Allat == null))
            {
                return true;
            }
            return false;
        }

        public bool NemSzultNemMozgottEsVanHely(List<KeretAdat[]> Keret, KeretAdat[] seged, int i, int j)
        {
            if (Keret[i][j].Szult == false && Keret[i][j].Mozgas == false && Array.Exists(seged, x => x.Allat == null))
            {
                return false;
            }
            return true;
        }

        public bool SzulesFeltetelek(List<KeretAdat[]> Keret, KeretAdat[] seged, int i, int j)
        {
            if (Keret[i][j].Szult == false && Keret[i][j].Allat == "Roka" && Keret[i][j].Mozgas == false && Array.Exists(seged, x => x.Allat == "Roka") && seged.Where(x => x.Allat == "Roka").First().Szult == false && Array.Exists(seged, x => x.Allat == null))
            {
                return true;
            }
            return false;
        }

        public void RokaAction(int oszlop, int sorok, List<KeretAdat[]> Keret)
        {
            for (int i = 0; i < oszlop; i++)
            {
                for (int j = 0; j < sorok; j++)
                {
                    KeretAdat[] seged = new KeretAdat[4];
                    KeretAdat[] seged2 = new KeretAdat[4];


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

                    try
                    {
                        seged2[0] = Keret[i + 2][j];
                    }
                    catch
                    {
                        seged2[0] = new KeretAdat("void", -1, -1, null, null);
                    }
                    try
                    {
                        seged2[1] = Keret[i][j + 2];
                    }
                    catch
                    {
                        seged2[1] = new KeretAdat("void", -1, -1, null, null);
                    }
                    try
                    {
                        seged2[2] = Keret[i - 2][j];
                    }
                    catch
                    {
                        seged2[2] = new KeretAdat("void", -1, -1, null, null);
                    }
                    try
                    {
                        seged2[3] = Keret[i][j - 2];
                    }
                    catch
                    {
                        seged2[3] = new KeretAdat("void", -1, -1, null, null);
                    }

                    if (Keret[i][j].Allat == "Roka" && Keret[i][j].Ehesseg <= 0)
                    {
                        Meghal(Keret, i, j);
                    }

                    if (Keret[i][j].Allat == "Roka")
                    {
                        if (Keret[i][j].Mozgas == false && Array.Exists(seged, x => x.Allat == "Nyul"))
                        {
                            KeretAdat legkozelebbi = seged.Where(x => x.Allat == "Nyul").First();
                            switch (Array.IndexOf(seged, legkozelebbi))
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
                        }
                        else if (Keret[i][j].Mozgas == false && Array.Exists(seged2, x => x.Allat == "Nyul"))
                        {
                            KeretAdat legkozelebbi = seged2.Where(x => x.Allat == "Nyul").First();
                            switch (Array.IndexOf(seged2, legkozelebbi))
                            {
                                case 0:
                                    RokaMozgas(Keret, i, j, i + 2, j);
                                    break;
                                case 1:
                                    RokaMozgas(Keret, i, j, i, j + 2);
                                    break;
                                case 2:
                                    RokaMozgas(Keret, i, j, i - 2, j);
                                    break;
                                default:
                                    RokaMozgas(Keret, i, j, i, j - 2);
                                    break;
                            }
                        }
                    }
                    if (SzulesFeltetelek(Keret, seged, i , j))
                    {
                        switch (Array.IndexOf(seged, seged.Where(x => x.Allat == null && x.Allat != "void").First()))
                        {
                            case 0:

                                RokaSzul(Keret, i + 1, j, i, j, seged);
                                seged[0] = Keret[i + 1][j];
                                break;
                            case 1:
                                RokaSzul(Keret, i, j + 1, i, j, seged);
                                seged[1] = Keret[i][j + 1];
                                break;
                            case 2:
                                RokaSzul(Keret, i - 1, j, i, j, seged);
                                seged[2] = Keret[i - 1][j];
                                break;
                            case 3:
                                RokaSzul(Keret, i, j - 1, i, j, seged);
                                seged[3] = Keret[i][j - 1];
                                break;
                        }
                    }
                    else if (Keret[i][j].Allat == "Roka" && Keret[i][j].Mozgas == false && Array.Exists(seged, x => x.Allat == null))
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