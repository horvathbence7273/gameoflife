using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    internal class KeretAdat
    {
        //ez a class tárolja el, hogy a keretben hol mi van. Majd ide rakjatok function-öket

        public ImageList kepLista { get; set; }

        public string allat { get; set; }
        public int ehesseg { get; set; }
        public int fuAllapot { get; set; }
        public bool mozgas { get; set; }
        public PictureBox kep { get; set; }

        public KeretAdat(string allat, int ehesseg, int fuAllapot, PictureBox kep, ImageList kepLista)
        {
            this.allat = allat;
            this.ehesseg = ehesseg;
            this.fuAllapot = fuAllapot;
            mozgas = false;
            this.kep = kep;
            this.kepLista = kepLista;
        }

        public void Frissites()
        {
            switch (allat)
            {
                case "Nyul":
                    kep.Image = kepLista.Images[3];
                    break;
                case "Roka":
                    kep.Image = kepLista.Images[4];
                    break;
                default:
                    kep.Image = null;
                    break;
            }
            kep.BackgroundImage = kepLista.Images[fuAllapot];
        }

        public void NoRoka()
        {
            //ez csak teszt, nyugottan ki lehet törölni a gombbal együtt.

            if (allat == "Roka")
            {
                kep.Image = null;
            }
        }

        public void NyulAction(int oszlop, int sorok, List<KeretAdat[]> Keret)
        {
            bool szult = false;
            for (int i = 0; i < oszlop; i++)
            {
                for (int j = 0; j < sorok; j++)
                {
                    if (Keret[i][j].allat == "Nyul" && Keret[i][j].ehesseg >= 1)
                    {
                        if (Keret[i + 1][j].allat == "Nyul" && Keret[i][j].ehesseg != 0 && szult == false)
                        {
                            if (Keret[i][j + 1].allat == null) //Keret[i][j + 1].allat == "Nyul" && Keret[i][j + 1].allat != "Roka"
                            {
                                Keret[i][j + 1].allat = "Nyul";
                                Keret[i][j + 1].ehesseg = 5;
                                Keret[i][j + 1].kep.Image = kepLista.Images[3];
                                szult = true;
                            }
                            else if (Keret[i - 1][j].allat == null)
                            {
                                Keret[i - 1][j].allat = "Nyul";
                                Keret[i - 1][j].ehesseg = 5;
                                Keret[i - 1][j].kep.Image = kepLista.Images[3];
                                szult = true;
                            }
                            else if (Keret[i][j - 1].allat == null)
                            {
                                Keret[i][j - 1].allat = "Nyul";
                                Keret[i][j - 1].ehesseg = 5;
                                Keret[i][j - 1].kep.Image = kepLista.Images[3];
                                szult = true;
                            }
                        }
                        else if (Keret[i][j + 1].allat == "Nyul" && Keret[i][j].ehesseg != 0 && szult == false)
                        {
                            if (Keret[i - 1][j].allat == null)
                            {
                                Keret[i - 1][j].allat = "Nyul";
                                Keret[i - 1][j].ehesseg = 5;
                                Keret[i - 1][j].kep.Image = kepLista.Images[3];
                                szult = true;
                            }
                            else if (Keret[i + 1][j].allat == null)
                            {
                                Keret[i + 1][j].allat = "Nyul";
                                Keret[i + 1][j].ehesseg = 5;
                                Keret[i + 1][j].kep.Image = kepLista.Images[3];
                                szult = true;
                            }
                            else if (Keret[i][j - 1].allat == null)
                            {
                                Keret[i][j - 1].allat = "Nyul";
                                Keret[i][j - 1].ehesseg = 5;
                                Keret[i][j - 1].kep.Image = kepLista.Images[3];
                                szult = true;
                            }
                        }
                        else if (Keret[i - 1][j].allat == "Nyul" && Keret[i][j].ehesseg != 0 && szult == false)
                        {
                            if (Keret[i + 1][j].allat == null)
                            {
                                Keret[i + 1][j].allat = "Nyul";
                                Keret[i + 1][j].ehesseg = 5;
                                Keret[i + 1][j].kep.Image = kepLista.Images[3];
                                szult = true;
                            }
                            else if (Keret[i][j + 1].allat == null)
                            {
                                Keret[i][j + 1].allat = "Nyul";
                                Keret[i][j + 1].ehesseg = 5;
                                Keret[i][j + 1].kep.Image = kepLista.Images[3];
                                szult = true;
                            }
                            else if (Keret[i][j - 1].allat == null)
                            {
                                Keret[i][j - 1].allat = "Nyul";
                                Keret[i][j - 1].ehesseg = 5;
                                Keret[i][j - 1].kep.Image = kepLista.Images[3];
                                szult = true;
                            }
                        }
                        else if (Keret[i][j - 1].allat == "Nyul" && Keret[i][j].ehesseg != 0 && szult == false)
                        {
                            if (Keret[i - 1][j].allat == null)
                            {
                                Keret[i - 1][j].allat = "Nyul";
                                Keret[i - 1][j].ehesseg = 5;
                                Keret[i - 1][j].kep.Image = kepLista.Images[3];
                                szult = true;
                            }
                            else if (Keret[i + 1][j].allat == null)
                            {
                                Keret[i + 1][j].allat = "Nyul";
                                Keret[i + 1][j].ehesseg = 5;
                                Keret[i + 1][j].kep.Image = kepLista.Images[3];
                                szult = true;
                            }
                            else if (Keret[i][j + 1].allat == null)
                            {
                                Keret[i][j + 1].allat = "Nyul";
                                Keret[i][j + 1].ehesseg = 5;
                                Keret[i][j + 1].kep.Image = kepLista.Images[3];
                                szult = true;
                            }
                        }
                        else if (szult==true && (Keret[i + 1][j].allat == null || Keret[i][j + 1].allat == null || Keret[i - 1][j].allat == null || Keret[i][j - 1].allat == null))
                        {
                            KeretAdat[] seged = { Keret[i + 1][j], Keret[i][j + 1], Keret[i - 1][j], Keret[i][j - 1] };
                            KeretAdat legnagyobb = seged.OrderBy(x => x.fuAllapot).Where(x=>x.allat==null).First();
                            switch (Array.IndexOf(seged, legnagyobb)) 
                            {
                                case 0:
                                    Keret[i][j].allat = null;
                                    Keret[i][j].ehesseg = 0;
                                    Keret[i + 1][j].allat = "Nyul";
                                    Keret[i + 1][j].ehesseg = 5;
                                    Keret[i + 1][j].kep.Image = kepLista.Images[3];
                                    break;
                                case 1:
                                    Keret[i][j].allat = null;
                                    Keret[i][j].ehesseg = 0;
                                    Keret[i][j + 1].allat = "Nyul";
                                    Keret[i][j + 1].ehesseg = 5;
                                    Keret[i][j + 1].kep.Image = kepLista.Images[3];
                                    break;
                                case 2:
                                    Keret[i][j].allat = null;
                                    Keret[i][j].ehesseg = 0;
                                    Keret[i - 1][j].allat = "Nyul";
                                    Keret[i - 1][j].ehesseg = 5;
                                    Keret[i - 1][j].kep.Image = kepLista.Images[3];
                                    break;
                                case 3:
                                    Keret[i][j].allat = null;
                                    Keret[i][j].ehesseg = 0;
                                    Keret[i][j - 1].allat = "Nyul";
                                    Keret[i][j - 1].ehesseg = 5;
                                    Keret[i][j - 1].kep.Image = kepLista.Images[3];
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Keret[i][j].allat = null;
                        Keret[i][j].ehesseg = 0;
                    }
                }
            }
        }
    }
}
