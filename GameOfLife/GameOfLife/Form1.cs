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
        int oszlop = 0;
        int sorok = 0;

        public Form1()
        {
            InitializeComponent();

        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            pan_keret.Controls.Clear();

            try
            {
                oszlop = int.Parse(tb_oszlopok.Text);
                sorok = int.Parse(tb_sorok.Text);
                if (oszlop <= 0 || sorok <= 0)
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

            if (oszlop >= 25 || sorok >= 25)
            {
                if (MessageBox.Show("Eléggé nagy számokat írtál be.\nEgy ideig eltarthat a legenerálás. Biztos vagy benne?", "Igen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            Keret = new List<KeretAdat[]>();


            for (int i = 0; i < oszlop; i++)
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

                    string allat;
                    int ehesseg;
                    int fuAllapot;

                    switch (rnd.Next(1, 11))
                    {
                        case 3:
                            allat = "Nyul";
                            ehesseg = 5;
                            break;
                        case 4:
                            allat = "Roka";
                            ehesseg = 10;
                            break;
                        default:
                            allat = null;
                            ehesseg = 0;
                            break;
                    }
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
            nyul.NyulAction(oszlop, sorok, Keret);
            roka.RokaAction(oszlop, sorok, Keret);
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
