namespace winPawArt
{
    partial class winPawArt
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            Btn_Exit = new Button();
            pictureBox1 = new PictureBox();
            btnComision = new Button();
            btnVentas = new Button();
            btnInventario = new Button();
            panel2 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 233, 191);
            panel1.Controls.Add(Btn_Exit);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnComision);
            panel1.Controls.Add(btnVentas);
            panel1.Controls.Add(btnInventario);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1224, 110);
            panel1.TabIndex = 0;
            // 
            // Btn_Exit
            // 
            Btn_Exit.BackgroundImage = Properties.Resources.CMS;
            Btn_Exit.FlatAppearance.BorderSize = 0;
            Btn_Exit.FlatStyle = FlatStyle.Flat;
            Btn_Exit.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Exit.ForeColor = Color.Chocolate;
            Btn_Exit.Location = new Point(908, 10);
            Btn_Exit.Name = "Btn_Exit";
            Btn_Exit.Size = new Size(77, 94);
            Btn_Exit.TabIndex = 4;
            Btn_Exit.Text = "X";
            Btn_Exit.UseVisualStyleBackColor = true;
            Btn_Exit.Click += Btn_Exit_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.PWRTS;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(330, 110);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // btnComision
            // 
            btnComision.BackgroundImage = Properties.Resources.CMS;
            btnComision.BackgroundImageLayout = ImageLayout.Stretch;
            btnComision.FlatAppearance.BorderSize = 0;
            btnComision.FlatStyle = FlatStyle.Flat;
            btnComision.Location = new Point(721, 0);
            btnComision.Name = "btnComision";
            btnComision.Size = new Size(127, 110);
            btnComision.TabIndex = 2;
            btnComision.UseVisualStyleBackColor = true;
            btnComision.Click += btnComision_Click;
            // 
            // btnVentas
            // 
            btnVentas.BackgroundImage = Properties.Resources.VTS;
            btnVentas.BackgroundImageLayout = ImageLayout.Stretch;
            btnVentas.FlatAppearance.BorderSize = 0;
            btnVentas.FlatStyle = FlatStyle.Flat;
            btnVentas.Location = new Point(571, 0);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(129, 110);
            btnVentas.TabIndex = 1;
            btnVentas.UseVisualStyleBackColor = true;
            btnVentas.Click += btnVentas_Click;
            // 
            // btnInventario
            // 
            btnInventario.BackgroundImage = Properties.Resources.INV;
            btnInventario.BackgroundImageLayout = ImageLayout.Stretch;
            btnInventario.FlatAppearance.BorderSize = 0;
            btnInventario.FlatStyle = FlatStyle.Flat;
            btnInventario.Location = new Point(418, 0);
            btnInventario.Name = "btnInventario";
            btnInventario.Size = new Size(129, 110);
            btnInventario.TabIndex = 0;
            btnInventario.UseVisualStyleBackColor = true;
            btnInventario.Click += btnInventario_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(199, 123, 64);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 110);
            panel2.Name = "panel2";
            panel2.Size = new Size(1224, 402);
            panel2.TabIndex = 1;
            // 
            // winPawArt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1224, 512);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "winPawArt";
            Text = "Form1";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button btnComision;
        private Button btnVentas;
        private Button btnInventario;
        private Button Btn_Exit;
        private PictureBox pictureBox1;
    }
}