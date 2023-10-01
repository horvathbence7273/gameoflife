using System;
using System.Collections.Generic;
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
    }
}
