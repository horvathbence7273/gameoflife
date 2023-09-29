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

        public PictureBox[,] kepKeret { get; set; }
        public string[,,] adatKeret { get; set; }
        public ImageList kepLista { get; set; }

        public KeretAdat(PictureBox[,] lista, string[,,] adat, ImageList kepek)
        {
            kepKeret = lista;
            adatKeret = adat;
            kepLista = kepek;
        }

        public void Frissites()
        {
            for (int i = 0; i < kepKeret.GetLength(0); i++)
            {
                for (int j = 0; j < kepKeret.GetLength(1); j++)
                {
                    if (adatKeret[j, i, 0] == "Fu")
                    {
                        kepKeret[j, i].Image = null;
                    }
                    else if(adatKeret[j, i, 0] == "Nyul")
                    {
                        kepKeret[j, i].Image = kepLista.Images[3];
                    }
                    else
                    {
                        kepKeret[j, i].Image = kepLista.Images[4];
                    }
                    kepKeret[j, i].BackgroundImage = kepLista.Images[int.Parse(adatKeret[j, i, 2])];
                    adatKeret[j, i, 3] = "0";
                }
            }
        }

        public void NoRoka()
        {
            //ez csak teszt, nyugottan ki lehet törölni a gombbal együtt.

            for (int i = 0; i < adatKeret.GetLength(0); i++)
            {
                for (int j = 0; j < adatKeret.GetLength(1); j++)
                {
                    if (adatKeret[j, i, 0] == "Roka")
                    {
                        adatKeret[j, i, 0] = "Fu";
                    }
                }
            }
            Frissites();
        }

        /*
        public void NyulMove()
        {
            for (int i = 0; i < adatKeret.GetLength(0); i++)
            {
                for (int j = 0; j < adatKeret.GetLength(1); j++)
                {
                    if (adatKeret[j,i]==3)
                    {
                        // stringgé alakítani ha megvan az éhség rendszer
                        int[] seged = { adatKeret[j - 1, i+1], adatKeret[j-1,i-1], adatKeret[j+1,i-1], adatKeret[j+1,i+1] };
                        for (int k = 0;  k < 4;  k++)
                        {
                            
                        }
                    }
                }
            }
        }

        */
        public void PullTeszt()
        {
            //pullteszt
        }
    }
}
