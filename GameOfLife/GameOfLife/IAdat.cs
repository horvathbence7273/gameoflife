using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    internal interface IAdat
    {
        void Mozog(int oszlop, int sor);
        bool Eszik(int oszlop, int sor);
        void Szul(int oszlop, int sor);
        void Meghal(int oszlop, int sor);
        void Frissites(int oszlop, int sor);
    }
}
