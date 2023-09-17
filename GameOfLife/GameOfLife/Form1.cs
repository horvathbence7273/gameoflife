using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        public Form1()
        {           
            InitializeComponent();
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
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

            PictureBox[,] fuvek_kepek = new PictureBox[sorok, oszlop];
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
                    kep.Visible = true;
                    switch (rnd.Next(1,4))
                    {
                        case 1:
                            kep.BackColor = Color.Green;
                            break;
                        case 2:
                            kep.BackColor = Color.Red;
                            break;
                        case 3:
                            kep.BackColor = Color.Blue;
                            break;
                        default:
                            kep.BackColor = Color.Transparent;
                            break;
                    }
                    fuvek_kepek[j,i] = kep;
                }
            }

            PictureBox[,] allatok_kepek = new PictureBox[sorok, oszlop];

            for (int i = 0; i < oszlop; i++)
            {
                for (int j = 0; j < sorok; j++)
                {
                    PictureBox kep = new PictureBox();
                    pan_keret.Controls.Add(kep);
                    kep.Size = new Size(50, 50);
                    kep.BorderStyle = BorderStyle.FixedSingle;
                    kep.Location = new Point(i * 50, j * 50);
                    kep.Visible = true;
                    kep.BackColor = fuvek_kepek[j,i].BackColor;
                    kep.BringToFront();
                    allatok_kepek[j, i] = kep;
                }
            }
        }
    }
}
