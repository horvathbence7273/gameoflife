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
        Random rnd = new Random();
        List<KeretAdat[]> Keret;
        Nyul nyul = new Nyul();
        Roka roka = new Roka();
        int oszlopok = 0;
        int sorok = 0;

        public Form1()
        {
            InitializeComponent();

        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            pan_keret.Controls.Clear();

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
            

            Keret = new List<KeretAdat[]>();


            for (int i = 0; i < oszlopok; i++)
            {
                KeretAdat[] oszlopKeret = new KeretAdat[sorok];

                for (int j = 0; j < sorok; j++)
                {
                    PictureBox kep = new PictureBox();
                    pan_keret.Controls.Add(kep);
                    kep.Size = new Size(50, 50);
                    kep.BorderStyle = BorderStyle.FixedSingle;
                    kep.Location = new Point(i * 50, j * 50);
                    kep.Visible = true;

                    string allat = null;
                    int ehesseg = 0;
                    int fuAllapot = 0;

                    switch (rnd.Next(0, 3))
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
                    oszlopKeret[j] = new KeretAdat(allat, ehesseg, fuAllapot, kep, il_Kepek);
                }
                Keret.Add(oszlopKeret);
            }

            while (nyulak > 0)
            {
                int x = rnd.Next(0, oszlopok);
                int y = rnd.Next(0, sorok);

                if (Keret[x][y].Allat == null)
                {
                    Keret[x][y].Allat = "Nyul";
                    Keret[x][y].Ehesseg = 5;
                    nyulak--;
                }
            }

            while (rokak > 0)
            {
                int x = rnd.Next(0, oszlopok);
                int y = rnd.Next(0, sorok);

                if (Keret[x][y].Allat == null)
                {
                    Keret[x][y].Allat = "Roka";
                    Keret[x][y].Ehesseg = 10;
                    rokak--;
                }
            }

            foreach (var item in Keret)
            {
                foreach (var iitem in item)
                {
                    iitem.Frissites();
                }
            }
            start.Enabled = true;
        }

        private void start_Click(object sender, EventArgs e)
        {
            start.Enabled = false;
            t_timer.Enabled = true;
            btn_end.Enabled = true;
            btn_generate.Enabled = false;

        }

        private void btn_end_Click(object sender, EventArgs e)
        {
            start.Enabled = true;
            t_timer.Enabled = false;
            btn_end.Enabled = false;
            btn_generate.Enabled = true;
        }

        private void t_timer_Tick(object sender, EventArgs e)
        {
            nyul.NyulAction(oszlopok, sorok, Keret);
            roka.RokaAction(oszlopok, sorok, Keret);
            foreach (var item in Keret)
            {
                foreach (var iitem in item)
                {
                    iitem.KorVege();
                    iitem.FuNo();
                }
            }
        }
    }
}
