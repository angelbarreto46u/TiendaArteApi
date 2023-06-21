namespace winPawArt
{
    partial class winInventario
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
            dgvInventario = new DataGridView();
            txtPrecioDeVentaInventario = new TextBox();
            txtProductoUnitarioInventario = new TextBox();
            txtDescripcionInventario = new TextBox();
            txtNombreProductoInventario = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnEliminarInventario = new Button();
            btnModificarInventario = new Button();
            btnAgregarInventario = new Button();
            txtProductoID = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
            SuspendLayout();
            // 
            // dgvInventario
            // 
            dgvInventario.AllowUserToAddRows = false;
            dgvInventario.AllowUserToDeleteRows = false;
            dgvInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventario.Location = new Point(397, 16);
            dgvInventario.Name = "dgvInventario";
            dgvInventario.ReadOnly = true;
            dgvInventario.RowTemplate.Height = 25;
            dgvInventario.Size = new Size(644, 363);
            dgvInventario.TabIndex = 1;
            dgvInventario.CellClick += dgvInventario_CellClick;
            dgvInventario.CellContentClick += dgvInventario_CellContentClick;
            // 
            // txtPrecioDeVentaInventario
            // 
            txtPrecioDeVentaInventario.Location = new Point(197, 255);
            txtPrecioDeVentaInventario.Name = "txtPrecioDeVentaInventario";
            txtPrecioDeVentaInventario.Size = new Size(139, 23);
            txtPrecioDeVentaInventario.TabIndex = 22;
            // 
            // txtProductoUnitarioInventario
            // 
            txtProductoUnitarioInventario.Location = new Point(197, 210);
            txtProductoUnitarioInventario.Name = "txtProductoUnitarioInventario";
            txtProductoUnitarioInventario.Size = new Size(139, 23);
            txtProductoUnitarioInventario.TabIndex = 21;
            // 
            // txtDescripcionInventario
            // 
            txtDescripcionInventario.Location = new Point(197, 107);
            txtDescripcionInventario.Multiline = true;
            txtDescripcionInventario.Name = "txtDescripcionInventario";
            txtDescripcionInventario.Size = new Size(139, 70);
            txtDescripcionInventario.TabIndex = 20;
            // 
            // txtNombreProductoInventario
            // 
            txtNombreProductoInventario.Location = new Point(197, 55);
            txtNombreProductoInventario.Name = "txtNombreProductoInventario";
            txtNombreProductoInventario.Size = new Size(139, 23);
            txtNombreProductoInventario.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(66, 258);
            label4.Name = "label4";
            label4.Size = new Size(97, 15);
            label4.TabIndex = 18;
            label4.Text = "Precio de venta:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(66, 213);
            label3.Name = "label3";
            label3.Size = new Size(109, 15);
            label3.TabIndex = 17;
            label3.Text = "Producto Unitario:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(66, 110);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 16;
            label2.Text = "Descripcion:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(66, 58);
            label1.Name = "label1";
            label1.Size = new Size(130, 15);
            label1.TabIndex = 15;
            label1.Text = "Nombre del Producto:";
            // 
            // btnEliminarInventario
            // 
            btnEliminarInventario.Location = new Point(210, 305);
            btnEliminarInventario.Name = "btnEliminarInventario";
            btnEliminarInventario.Size = new Size(132, 23);
            btnEliminarInventario.TabIndex = 14;
            btnEliminarInventario.Text = "Eliminar Inventario";
            btnEliminarInventario.UseVisualStyleBackColor = true;
            btnEliminarInventario.Click += btnEliminarInventario_Click;
            // 
            // btnModificarInventario
            // 
            btnModificarInventario.Location = new Point(139, 345);
            btnModificarInventario.Name = "btnModificarInventario";
            btnModificarInventario.Size = new Size(144, 23);
            btnModificarInventario.TabIndex = 13;
            btnModificarInventario.Text = "Modificar Inventario";
            btnModificarInventario.UseVisualStyleBackColor = true;
            btnModificarInventario.Click += btnModificarInventario_Click;
            // 
            // btnAgregarInventario
            // 
            btnAgregarInventario.Location = new Point(66, 305);
            btnAgregarInventario.Name = "btnAgregarInventario";
            btnAgregarInventario.Size = new Size(138, 23);
            btnAgregarInventario.TabIndex = 12;
            btnAgregarInventario.Text = "Agregar Inventario";
            btnAgregarInventario.UseVisualStyleBackColor = true;
            btnAgregarInventario.Click += btnAgregarInventario_Click;
            // 
            // txtProductoID
            // 
            txtProductoID.Location = new Point(197, 16);
            txtProductoID.Name = "txtProductoID";
            txtProductoID.Size = new Size(139, 23);
            txtProductoID.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(66, 19);
            label5.Name = "label5";
            label5.Size = new Size(20, 15);
            label5.TabIndex = 23;
            label5.Text = "ID";
            // 
            // winInventario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(199, 123, 64);
            ClientSize = new Size(1224, 426);
            Controls.Add(txtProductoID);
            Controls.Add(label5);
            Controls.Add(txtPrecioDeVentaInventario);
            Controls.Add(txtProductoUnitarioInventario);
            Controls.Add(txtDescripcionInventario);
            Controls.Add(txtNombreProductoInventario);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnEliminarInventario);
            Controls.Add(btnModificarInventario);
            Controls.Add(btnAgregarInventario);
            Controls.Add(dgvInventario);
            Name = "winInventario";
            Text = "winInventario";
            Load += winInventario_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvInventario;
        private TextBox txtPrecioDeVentaInventario;
        private TextBox txtProductoUnitarioInventario;
        private TextBox txtDescripcionInventario;
        private TextBox txtNombreProductoInventario;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnEliminarInventario;
        private Button btnModificarInventario;
        private Button btnAgregarInventario;
        private TextBox txtProductoID;
        private Label label5;
    }
}