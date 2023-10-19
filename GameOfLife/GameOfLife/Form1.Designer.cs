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
            this.il_Kepek = new System.Windows.Forms.ImageList(this.components);
            this.start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pan_keret
            // 
            this.pan_keret.AutoSize = true;
            this.pan_keret.BackColor = System.Drawing.Color.Transparent;
            this.pan_keret.Location = new System.Drawing.Point(3, 37);
            this.pan_keret.Name = "pan_keret";
            this.pan_keret.Size = new System.Drawing.Size(631, 315);
            this.pan_keret.TabIndex = 0;
            // 
            // tb_sorok
            // 
            this.tb_sorok.Location = new System.Drawing.Point(66, 11);
            this.tb_sorok.Name = "tb_sorok";
            this.tb_sorok.Size = new System.Drawing.Size(100, 20);
            this.tb_sorok.TabIndex = 0;
            // 
            // tb_oszlopok
            // 
            this.tb_oszlopok.Location = new System.Drawing.Point(328, 11);
            this.tb_oszlopok.Name = "tb_oszlopok";
            this.tb_oszlopok.Size = new System.Drawing.Size(100, 20);
            this.tb_oszlopok.TabIndex = 1;
            // 
            // lb_sorok
            // 
            this.lb_sorok.AutoSize = true;
            this.lb_sorok.Location = new System.Drawing.Point(22, 15);
            this.lb_sorok.Name = "lb_sorok";
            this.lb_sorok.Size = new System.Drawing.Size(38, 13);
            this.lb_sorok.TabIndex = 2;
            this.lb_sorok.Text = "Sorok:";
            // 
            // lb_oszlopok
            // 
            this.lb_oszlopok.AutoSize = true;
            this.lb_oszlopok.Location = new System.Drawing.Point(268, 14);
            this.lb_oszlopok.Name = "lb_oszlopok";
            this.lb_oszlopok.Size = new System.Drawing.Size(54, 13);
            this.lb_oszlopok.TabIndex = 3;
            this.lb_oszlopok.Text = "Oszlopok:";
            // 
            // btn_generate
            // 
            this.btn_generate.Location = new System.Drawing.Point(467, 9);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(165, 22);
            this.btn_generate.TabIndex = 4;
            this.btn_generate.Text = "Keretrendszer generálása";
            this.btn_generate.UseVisualStyleBackColor = true;
            this.btn_generate.Click += new System.EventHandler(this.btn_generate_Click);
            // 
            // il_Kepek
            // 
            this.il_Kepek.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il_Kepek.ImageStream")));
            this.il_Kepek.TransparentColor = System.Drawing.Color.Transparent;
            this.il_Kepek.Images.SetKeyName(0, "Fu_kezdemeny.png");
            this.il_Kepek.Images.SetKeyName(1, "Fu_zsenge.png");
            this.il_Kepek.Images.SetKeyName(2, "Fu_kifejlett.png");
            this.il_Kepek.Images.SetKeyName(3, "Nyul.png");
            this.il_Kepek.Images.SetKeyName(4, "Roka.png");
            // 
            // start
            // 
            this.start.Enabled = false;
            this.start.Location = new System.Drawing.Point(753, 8);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(110, 23);
            this.start.TabIndex = 6;
            this.start.Text = "Indítás";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(910, 626);
            this.Controls.Add(this.start);
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
        private System.Windows.Forms.ImageList il_Kepek;
        private System.Windows.Forms.Button start;
    }
}

