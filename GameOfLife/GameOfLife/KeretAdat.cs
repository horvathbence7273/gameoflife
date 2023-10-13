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

        public string Allat { get; set; }
        public int Ehesseg { get; set; }
        public int FuAllapot { get; set; }
        public bool Mozgas { get; set; }
        public bool Szult {  get; set; }
        public PictureBox kep { get; set; }

        public KeretAdat(string Allat, int Ehesseg, int FuAllapot, PictureBox kep, ImageList kepLista)
        {
            this.Allat = Allat;
            this.Ehesseg = Ehesseg;
            this.FuAllapot = FuAllapot;
            Mozgas = false;
            Szult = false;
            this.kep = kep;
            this.kepLista = kepLista;
        }

        public void Frissites()
        {
            switch (Allat)
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
            kep.BackgroundImage = kepLista.Images[FuAllapot];
        }


    }
}
