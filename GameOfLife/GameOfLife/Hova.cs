using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public static class Hova
    {
        public static int[] Egyre(int random, int oszlop, int sor)
        {
            int[] egyre = new int[2];

            switch (random)
            {
                case 0:
                    egyre[0] = oszlop + 1;
                    egyre[1] = sor;
                    break;
                case 1:
                    egyre[0] = oszlop;
                    egyre[1] = sor + 1;
                    break;
                case 2:
                    egyre[0] = oszlop - 1;
                    egyre[1] = sor;
                    break;
                case 3:
                    egyre[0] = oszlop;
                    egyre[1] = sor - 1;
                    break;

            }

            return egyre;
        }

        public static int[] Ketoore(int random, int oszlop, int sor)
        {
            int[] kettore = new int[2];

            switch (random)
            {
                case 0:
                    kettore[0] = oszlop + 2;
                    kettore[1] = sor;
                    break;
                case 1:
                    kettore[0] = oszlop;
                    kettore[1] = sor + 2;
                    break;
                case 2:
                    kettore[0] = oszlop - 2;
                    kettore[1] = sor;
                    break;
                case 3:
                    kettore[0] = oszlop;
                    kettore[1] = sor - 2;
                    break;

            }

            return kettore;
        }

    }
}



