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
        public int[,] fuKeret { get; set; }
        public int[,] allatKeret { get; set; }
        public ImageList kepLista { get; set; }

        public KeretAdat(PictureBox[,] lista, int[,] fu, int[,] allat, ImageList kepek)
        {
            kepKeret = lista;
            fuKeret = fu;
            allatKeret = allat;
            kepLista = kepek;
        }

        public void Frissites()
        {
            for (int i = 0; i < kepKeret.GetLength(0); i++)
            {
                for (int j = 0; j < kepKeret.GetLength(1); j++)
                {
                    if (allatKeret[j, i] == 0)
                    {
                        kepKeret[j, i].Image = null;
                    }
                    else
                    {
                        kepKeret[j, i].Image = kepLista.Images[allatKeret[j,i]];
                    }
                    kepKeret[j, i].BackgroundImage = kepLista.Images[fuKeret[j, i]];
                }
            }
        }

        public void NoRoka()
        {
            //ez csak teszt, nyugottan ki lehet törölni a gombbal együtt.

            for (int i = 0; i < allatKeret.GetLength(0); i++)
            {
                for (int j = 0; j < allatKeret.GetLength(1); j++)
                {
                    if (allatKeret[j, i] == 4)
                    {
                        allatKeret[j, i] = 0;
                    }
                }
            }
            Frissites();
        }

        public void PullTeszt()
        {
            //pullteszt
        }
    }
}
