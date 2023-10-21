using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        int oszlopok = 0;
        int sorok = 0;

        public Form1()
        {
            InitializeComponent();
            Kepek.Fuvek = il_fuvek;
            Kepek.Allatok = il_allatok;
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            int rokak = 0;
            int nyulak = 0;

            try
            {
                oszlopok = int.Parse(tb_oszlopok.Text);
                sorok = int.Parse(tb_sorok.Text);
                rokak = int.Parse(tb_rokak.Text);
                nyulak = int.Parse(tb_nyulak.Text);
                if (oszlopok <= 0 || sorok <= 0 || rokak <= 0 || nyulak <= 0)
                {
                    MessageBox.Show("Az értékek legalább legyenek 1-ek");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("nem megfelelő bemeneti érték");
                return;
            }

            if (rokak + nyulak >= oszlopok * sorok)
            {
                MessageBox.Show("Túl sok állatot adtál meg");
                return;
            }
            if (oszlopok >= 25 || sorok >= 25)
            {
                if (MessageBox.Show("Eléggé nagy számokat írtál be.\nEgy ideig eltarthat a legenerálás. Biztos vagy benne?", "Igen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            if (rokak + nyulak >= oszlopok * sorok / 2)
            {
                if (MessageBox.Show("Eléggé sok állatot szeretnél legenerálni.\nBiztos vagy benne?", "Igen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            pan_keret.Controls.Clear();
            Adatok.Mezo = new MezoAdat[oszlopok,sorok];

            for (int i = 0; i < oszlopok; i++)
            {
                for (int j = 0; j < sorok; j++)
                {
                    PictureBox KepDoboz = new PictureBox();
                    pan_keret.Controls.Add(KepDoboz);
                    KepDoboz.Size = new Size(50, 50);
                    KepDoboz.BorderStyle = BorderStyle.FixedSingle;
                    KepDoboz.Location = new Point(i * 50, j * 50);
                    KepDoboz.Visible = true;

                    int ehesseg = 0;
                    int fuAllapot = 0;

                    switch (rnd.rand.Next(0, 3))
                    {
                        case 0:
                            fuAllapot = 0;
                            break;
                        case 1:
                            fuAllapot = 1;
                            break;
                        default:
                            fuAllapot = 2;
                            break;
                    }
                    Adatok.Mezo[i,j] = new MezoAdat(ehesseg, fuAllapot, KepDoboz);
                }
            }

            while (nyulak > 0)
            {
                int x = rnd.rand.Next(0, oszlopok);
                int y = rnd.rand.Next(0, sorok);

                if (Adatok.Mezo[x, y] is MezoAdat)
                {
                    Adatok.Mezo[x, y] = new Nyul(5, Adatok.Mezo[x, y].FuAllapot, Adatok.Mezo[x, y].KepDoboz);
                    nyulak--;
                }
            }

            while (rokak > 0)
            {
                int x = rnd.rand.Next(0, oszlopok);
                int y = rnd.rand.Next(0, sorok);

                if (Adatok.Mezo[x,y] is MezoAdat)
                {
                    Adatok.Mezo[x, y] = new Roka(10, Adatok.Mezo[x, y].FuAllapot, Adatok.Mezo[x, y].KepDoboz);
                    rokak--;
                }
            }

            for (int i = 0; i < Adatok.Mezo.GetLength(0); i++)
            {
                for (int j = 0; j < Adatok.Mezo.GetLength(1); j++)
                {
                    Adatok.Mezo[i, j].Frissites();
                }
            }
            btn_start.Enabled = true;
        }

        private void btn_end_Click(object sender, EventArgs e)
        {
            btn_start.Enabled = true;
            t_timer.Enabled = false;
            btn_end.Enabled = false;
            btn_generate.Enabled = true;
        }

        private void t_timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Adatok.Mezo.GetLength(0); i++)
            {
                for (int j = 0; j < Adatok.Mezo.GetLength(1); j++)
                {
                    Adatok.Mezo[i, j].Meghal(i,j);
                    if (Adatok.Mezo[i, j].Eszik(i, j) == false)
                    {
                        if (Adatok.Mezo[i, j].Mozgott == false)
                        {
                            Adatok.Mezo[i, j].Mozog(i, j);   
                        }
                    }
                    if (Adatok.Mezo[i, j].Szult == false)
                    {
                        Adatok.Mezo[i, j].Szul(i, j);
                    }
                }
            }
            for (int i = 0; i < Adatok.Mezo.GetLength(0); i++)
            {
                for (int j = 0; j < Adatok.Mezo.GetLength(1); j++)
                {
                    Adatok.Mezo[i, j].KorVege();
                }
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            btn_start.Enabled = false;
            t_timer.Enabled = true;
            btn_end.Enabled = true;
            btn_generate.Enabled = false;
        }

        private void teszt_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Adatok.Mezo.GetLength(0); i++)
            {
                for (int j = 0; j < Adatok.Mezo.GetLength(1); j++)
                {
                    Adatok.Mezo[i, j].Meghal(i, j);
                    if (Adatok.Mezo[i, j].Eszik(i, j) == false)
                    {
                        if (Adatok.Mezo[i, j].Mozgott == false)
                        {
                            Adatok.Mezo[i, j].Mozog(i, j);
                        }
                    }
                    if (Adatok.Mezo[i, j].Szult == false)
                    {
                        Adatok.Mezo[i, j].Szul(i, j);
                    }
                }
            }
            for (int i = 0; i < Adatok.Mezo.GetLength(0); i++)
            {
                for (int j = 0; j < Adatok.Mezo.GetLength(1); j++)
                {
                    Adatok.Mezo[i, j].KorVege();
                }
            }
        }
    }
}
