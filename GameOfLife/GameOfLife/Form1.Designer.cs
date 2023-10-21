namespace GameOfLife
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pan_keret = new System.Windows.Forms.Panel();
            this.tb_sorok = new System.Windows.Forms.TextBox();
            this.tb_oszlopok = new System.Windows.Forms.TextBox();
            this.lb_sorok = new System.Windows.Forms.Label();
            this.lb_oszlopok = new System.Windows.Forms.Label();
            this.btn_generate = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.lb_roka = new System.Windows.Forms.Label();
            this.lb_nyulak = new System.Windows.Forms.Label();
            this.tb_rokak = new System.Windows.Forms.TextBox();
            this.tb_nyulak = new System.Windows.Forms.TextBox();
            this.btn_end = new System.Windows.Forms.Button();
            this.t_timer = new System.Windows.Forms.Timer(this.components);
            this.il_fuvek = new System.Windows.Forms.ImageList(this.components);
            this.il_allatok = new System.Windows.Forms.ImageList(this.components);
            this.teszt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pan_keret
            // 
            this.pan_keret.AutoSize = true;
            this.pan_keret.BackColor = System.Drawing.Color.Transparent;
            this.pan_keret.Location = new System.Drawing.Point(6, 61);
            this.pan_keret.Name = "pan_keret";
            this.pan_keret.Size = new System.Drawing.Size(494, 55);
            this.pan_keret.TabIndex = 0;
            // 
            // tb_sorok
            // 
            this.tb_sorok.Location = new System.Drawing.Point(63, 6);
            this.tb_sorok.Name = "tb_sorok";
            this.tb_sorok.Size = new System.Drawing.Size(100, 20);
            this.tb_sorok.TabIndex = 0;
            this.tb_sorok.Text = "3";
            // 
            // tb_oszlopok
            // 
            this.tb_oszlopok.Location = new System.Drawing.Point(63, 35);
            this.tb_oszlopok.Name = "tb_oszlopok";
            this.tb_oszlopok.Size = new System.Drawing.Size(100, 20);
            this.tb_oszlopok.TabIndex = 1;
            this.tb_oszlopok.Text = "3";
            // 
            // lb_sorok
            // 
            this.lb_sorok.AutoSize = true;
            this.lb_sorok.Location = new System.Drawing.Point(3, 9);
            this.lb_sorok.Name = "lb_sorok";
            this.lb_sorok.Size = new System.Drawing.Size(38, 13);
            this.lb_sorok.TabIndex = 2;
            this.lb_sorok.Text = "Sorok:";
            // 
            // lb_oszlopok
            // 
            this.lb_oszlopok.AutoSize = true;
            this.lb_oszlopok.Location = new System.Drawing.Point(3, 38);
            this.lb_oszlopok.Name = "lb_oszlopok";
            this.lb_oszlopok.Size = new System.Drawing.Size(54, 13);
            this.lb_oszlopok.TabIndex = 3;
            this.lb_oszlopok.Text = "Oszlopok:";
            // 
            // btn_generate
            // 
            this.btn_generate.Location = new System.Drawing.Point(335, 4);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(165, 22);
            this.btn_generate.TabIndex = 4;
            this.btn_generate.Text = "Keretrendszer generálása";
            this.btn_generate.UseVisualStyleBackColor = true;
            this.btn_generate.Click += new System.EventHandler(this.btn_generate_Click);
            // 
            // btn_start
            // 
            this.btn_start.Enabled = false;
            this.btn_start.Location = new System.Drawing.Point(335, 33);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(82, 23);
            this.btn_start.TabIndex = 6;
            this.btn_start.Text = "Indítás";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // lb_roka
            // 
            this.lb_roka.AutoSize = true;
            this.lb_roka.Location = new System.Drawing.Point(169, 38);
            this.lb_roka.Name = "lb_roka";
            this.lb_roka.Size = new System.Drawing.Size(42, 13);
            this.lb_roka.TabIndex = 10;
            this.lb_roka.Text = "Rókák:";
            // 
            // lb_nyulak
            // 
            this.lb_nyulak.AutoSize = true;
            this.lb_nyulak.Location = new System.Drawing.Point(169, 9);
            this.lb_nyulak.Name = "lb_nyulak";
            this.lb_nyulak.Size = new System.Drawing.Size(43, 13);
            this.lb_nyulak.TabIndex = 9;
            this.lb_nyulak.Text = "Nyulak:";
            // 
            // tb_rokak
            // 
            this.tb_rokak.Location = new System.Drawing.Point(229, 35);
            this.tb_rokak.Name = "tb_rokak";
            this.tb_rokak.Size = new System.Drawing.Size(100, 20);
            this.tb_rokak.TabIndex = 8;
            this.tb_rokak.Text = "1";
            // 
            // tb_nyulak
            // 
            this.tb_nyulak.Location = new System.Drawing.Point(229, 6);
            this.tb_nyulak.Name = "tb_nyulak";
            this.tb_nyulak.Size = new System.Drawing.Size(100, 20);
            this.tb_nyulak.TabIndex = 7;
            this.tb_nyulak.Text = "1";
            // 
            // btn_end
            // 
            this.btn_end.Enabled = false;
            this.btn_end.Location = new System.Drawing.Point(418, 33);
            this.btn_end.Name = "btn_end";
            this.btn_end.Size = new System.Drawing.Size(82, 23);
            this.btn_end.TabIndex = 11;
            this.btn_end.Text = "Befejezés";
            this.btn_end.UseVisualStyleBackColor = true;
            this.btn_end.Click += new System.EventHandler(this.btn_end_Click);
            // 
            // t_timer
            // 
            this.t_timer.Interval = 200;
            this.t_timer.Tick += new System.EventHandler(this.t_timer_Tick);
            // 
            // il_fuvek
            // 
            this.il_fuvek.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il_fuvek.ImageStream")));
            this.il_fuvek.TransparentColor = System.Drawing.Color.Transparent;
            this.il_fuvek.Images.SetKeyName(0, "Fu_kezdemeny.png");
            this.il_fuvek.Images.SetKeyName(1, "Fu_zsenge.png");
            this.il_fuvek.Images.SetKeyName(2, "Fu_kifejlett.png");
            // 
            // il_allatok
            // 
            this.il_allatok.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il_allatok.ImageStream")));
            this.il_allatok.TransparentColor = System.Drawing.Color.Transparent;
            this.il_allatok.Images.SetKeyName(0, "Nyul.png");
            this.il_allatok.Images.SetKeyName(1, "Roka.png");
            // 
            // teszt
            // 
            this.teszt.Location = new System.Drawing.Point(525, 4);
            this.teszt.Name = "teszt";
            this.teszt.Size = new System.Drawing.Size(102, 52);
            this.teszt.TabIndex = 12;
            this.teszt.Text = "Teszt";
            this.teszt.UseVisualStyleBackColor = true;
            this.teszt.Click += new System.EventHandler(this.teszt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(910, 626);
            this.Controls.Add(this.teszt);
            this.Controls.Add(this.btn_end);
            this.Controls.Add(this.lb_roka);
            this.Controls.Add(this.lb_nyulak);
            this.Controls.Add(this.tb_rokak);
            this.Controls.Add(this.tb_nyulak);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.btn_generate);
            this.Controls.Add(this.lb_oszlopok);
            this.Controls.Add(this.lb_sorok);
            this.Controls.Add(this.tb_oszlopok);
            this.Controls.Add(this.tb_sorok);
            this.Controls.Add(this.pan_keret);
            this.Name = "Form1";
            this.Text = "Élet Játéka";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pan_keret;
        private System.Windows.Forms.TextBox tb_sorok;
        private System.Windows.Forms.TextBox tb_oszlopok;
        private System.Windows.Forms.Label lb_sorok;
        private System.Windows.Forms.Label lb_oszlopok;
        private System.Windows.Forms.Button btn_generate;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label lb_roka;
        private System.Windows.Forms.Label lb_nyulak;
        private System.Windows.Forms.TextBox tb_rokak;
        private System.Windows.Forms.TextBox tb_nyulak;
        private System.Windows.Forms.Button btn_end;
        private System.Windows.Forms.Timer t_timer;
        private System.Windows.Forms.ImageList il_fuvek;
        private System.Windows.Forms.ImageList il_allatok;
        private System.Windows.Forms.Button teszt;
    }
}

