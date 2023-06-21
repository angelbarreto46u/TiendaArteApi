namespace winPawArt
{
    partial class winVentas
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
            dgvVentas = new DataGridView();
            txtFechaEntregaVentas = new TextBox();
            txtDireccionVentas = new TextBox();
            txtSolicitudVentas = new TextBox();
            txtNombreClienteVentas = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnEliminarVentas = new Button();
            btnModificarVentas = new Button();
            btnAgregarVentas = new Button();
            txtPrecioDeVentaVentas = new TextBox();
            label5 = new Label();
            txtVentasID = new TextBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // dgvVentas
            // 
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Location = new Point(419, 61);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.ReadOnly = true;
            dgvVentas.RowTemplate.Height = 25;
            dgvVentas.Size = new Size(644, 363);
            dgvVentas.TabIndex = 1;
            dgvVentas.CellClick += dgvVentas_CellClick;
            // 
            // txtFechaEntregaVentas
            // 
            txtFechaEntregaVentas.Location = new Point(198, 261);
            txtFechaEntregaVentas.Name = "txtFechaEntregaVentas";
            txtFechaEntregaVentas.Size = new Size(139, 23);
            txtFechaEntregaVentas.TabIndex = 33;
            // 
            // txtDireccionVentas
            // 
            txtDireccionVentas.Location = new Point(198, 216);
            txtDireccionVentas.Name = "txtDireccionVentas";
            txtDireccionVentas.Size = new Size(139, 23);
            txtDireccionVentas.TabIndex = 32;
            // 
            // txtSolicitudVentas
            // 
            txtSolicitudVentas.Location = new Point(198, 113);
            txtSolicitudVentas.Multiline = true;
            txtSolicitudVentas.Name = "txtSolicitudVentas";
            txtSolicitudVentas.Size = new Size(139, 25);
            txtSolicitudVentas.TabIndex = 31;
            // 
            // txtNombreClienteVentas
            // 
            txtNombreClienteVentas.Location = new Point(198, 61);
            txtNombreClienteVentas.Name = "txtNombreClienteVentas";
            txtNombreClienteVentas.Size = new Size(139, 23);
            txtNombreClienteVentas.TabIndex = 30;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(67, 264);
            label4.Name = "label4";
            label4.Size = new Size(100, 15);
            label4.TabIndex = 29;
            label4.Text = "Fecha de entrega:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(67, 219);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 28;
            label3.Text = "Direccion:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(67, 116);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 27;
            label2.Text = "Solicitud:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 64);
            label1.Name = "label1";
            label1.Size = new Size(111, 15);
            label1.TabIndex = 26;
            label1.Text = "Nombre del cliente:";
            // 
            // btnEliminarVentas
            // 
            btnEliminarVentas.Location = new Point(272, 354);
            btnEliminarVentas.Name = "btnEliminarVentas";
            btnEliminarVentas.Size = new Size(132, 23);
            btnEliminarVentas.TabIndex = 25;
            btnEliminarVentas.Text = "Eliminar Ventas";
            btnEliminarVentas.UseVisualStyleBackColor = true;
            btnEliminarVentas.Click += btnEliminarVentas_Click;
            // 
            // btnModificarVentas
            // 
            btnModificarVentas.Location = new Point(123, 406);
            btnModificarVentas.Name = "btnModificarVentas";
            btnModificarVentas.Size = new Size(144, 23);
            btnModificarVentas.TabIndex = 24;
            btnModificarVentas.Text = "Modificar Ventas";
            btnModificarVentas.UseVisualStyleBackColor = true;
            btnModificarVentas.Click += btnModificarVentas_Click;
            // 
            // btnAgregarVentas
            // 
            btnAgregarVentas.Location = new Point(19, 354);
            btnAgregarVentas.Name = "btnAgregarVentas";
            btnAgregarVentas.Size = new Size(138, 23);
            btnAgregarVentas.TabIndex = 23;
            btnAgregarVentas.Text = "Agregar Ventas";
            btnAgregarVentas.UseVisualStyleBackColor = true;
            btnAgregarVentas.Click += btnAgregarVentas_Click;
            // 
            // txtPrecioDeVentaVentas
            // 
            txtPrecioDeVentaVentas.Location = new Point(198, 166);
            txtPrecioDeVentaVentas.Multiline = true;
            txtPrecioDeVentaVentas.Name = "txtPrecioDeVentaVentas";
            txtPrecioDeVentaVentas.Size = new Size(139, 25);
            txtPrecioDeVentaVentas.TabIndex = 35;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(67, 169);
            label5.Name = "label5";
            label5.Size = new Size(91, 15);
            label5.TabIndex = 34;
            label5.Text = "Precio de venta:";
            // 
            // txtVentasID
            // 
            txtVentasID.Location = new Point(198, 22);
            txtVentasID.Name = "txtVentasID";
            txtVentasID.Size = new Size(139, 23);
            txtVentasID.TabIndex = 37;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(67, 25);
            label6.Name = "label6";
            label6.Size = new Size(21, 15);
            label6.TabIndex = 36;
            label6.Text = "ID:";
            // 
            // winVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1224, 512);
            Controls.Add(txtVentasID);
            Controls.Add(label6);
            Controls.Add(txtPrecioDeVentaVentas);
            Controls.Add(label5);
            Controls.Add(txtFechaEntregaVentas);
            Controls.Add(txtDireccionVentas);
            Controls.Add(txtSolicitudVentas);
            Controls.Add(txtNombreClienteVentas);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnEliminarVentas);
            Controls.Add(btnModificarVentas);
            Controls.Add(btnAgregarVentas);
            Controls.Add(dgvVentas);
            Name = "winVentas";
            Text = "winVentas";
            Load += winVentas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvVentas;
        private TextBox txtFechaEntregaVentas;
        private TextBox txtDireccionVentas;
        private TextBox txtSolicitudVentas;
        private TextBox txtNombreClienteVentas;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnEliminarVentas;
        private Button btnModificarVentas;
        private Button btnAgregarVentas;
        private TextBox txtPrecioDeVentaVentas;
        private Label label5;
        private TextBox txtVentasID;
        private Label label6;
    }
}