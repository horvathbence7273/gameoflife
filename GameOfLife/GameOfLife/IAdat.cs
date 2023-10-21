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
        void Mozog(int oszlopok, int sorok);
        bool Eszik(int oszlopok, int sorok);
        void Szul(int oszlopok, int sorok);
        void Meghal(int oszlopok, int sorok);
        void Frissites();
    }
}
