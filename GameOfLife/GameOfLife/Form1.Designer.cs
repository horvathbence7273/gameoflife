﻿namespace GameOfLife
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
            this.Kepek = new System.Windows.Forms.ImageList(this.components);
            this.Nbtn_test = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pan_keret
            // 
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
            // Kepek
            // 
            this.Kepek.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Kepek.ImageStream")));
            this.Kepek.TransparentColor = System.Drawing.Color.Transparent;
            this.Kepek.Images.SetKeyName(0, "Fu_kezdemeny.png");
            this.Kepek.Images.SetKeyName(1, "Fu_kifejlett.png");
            this.Kepek.Images.SetKeyName(2, "Fu_zsenge.png");
            this.Kepek.Images.SetKeyName(3, "Nyul.png");
            this.Kepek.Images.SetKeyName(4, "Roka.png");
            // 
            // Nbtn_test
            // 
            this.Nbtn_test.Enabled = false;
            this.Nbtn_test.Location = new System.Drawing.Point(638, 8);
            this.Nbtn_test.Name = "Nbtn_test";
            this.Nbtn_test.Size = new System.Drawing.Size(109, 23);
            this.Nbtn_test.TabIndex = 5;
            this.Nbtn_test.Text = "No more róka";
            this.Nbtn_test.UseVisualStyleBackColor = true;
            this.Nbtn_test.Click += new System.EventHandler(this.Nbtn_test_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(910, 626);
            this.Controls.Add(this.Nbtn_test);
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
        private System.Windows.Forms.ImageList Kepek;
        private System.Windows.Forms.Button Nbtn_test;
    }
}

