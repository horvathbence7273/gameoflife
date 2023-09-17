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
        KeretAdat Keret;
        public Form1()
        {           
            InitializeComponent();
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            pan_keret.Controls.Clear();
            int oszlop;
            int sorok;
            try
            {
                oszlop = int.Parse(tb_oszlopok.Text);
                sorok = int.Parse(tb_sorok.Text);
                if (oszlop <= 0 || sorok <= 0)
                {
                    MessageBox.Show("Az értékek legalább legyenek 1-ek");
                    return;
                }
            }catch(Exception ex)
            {
                MessageBox.Show("nem megfelelő bemeneti érték");
                return;
            }

            if(oszlop >= 25 || sorok >= 25)
            {               
                if (MessageBox.Show("Eléggé nagy számokat írtál be.\nEgy ideig eltarthat a legenerálás. Biztos vagy benne?", "Igen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            PictureBox[,] keretLista = new PictureBox[sorok, oszlop];
            int[,] allat = new int[sorok, oszlop];
            int[,] fu = new int[sorok, oszlop];

            pan_keret.Size = new Size(oszlop * 50, sorok * 50);

            for (int i = 0; i < oszlop; i++)
            {
                for (int j = 0; j < sorok; j++) 
                { 
                    PictureBox kep = new PictureBox();
                    pan_keret.Controls.Add(kep);
                    kep.Size = new Size(50, 50);
                    kep.BorderStyle = BorderStyle.FixedSingle;
                    kep.Location = new Point(i * 50, j * 50);
                    switch (rnd.Next(0, 4))
                    {
                        case 0:
                            fu[j, i] = 0;
                            break;
                        case 1:
                            fu[j, i] = 1;
                            break;
                        case 2:
                            fu[j, i] = 2;
                            break;
                        default:
                            break;
                    }
                    switch (rnd.Next(1, 11))
                    {
                        case 3:
                            allat[j, i] = 3;
                            break;
                        case 4:
                            allat[j, i] = 4;
                            break;
                        default:
                            break;
                    }
                    kep.Visible = true;
                    keretLista[j,i] = kep;
                }
            }
            Keret = new KeretAdat(keretLista,fu,allat,Kepek);
            Nbtn_test.Enabled = true;
            Keret.Frissites();
                       
        }

        private void Nbtn_test_Click(object sender, EventArgs e)
        {
            Keret.NoRoka();
        }
    }
}
