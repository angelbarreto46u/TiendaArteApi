namespace winPawArt
{
    partial class winComision
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
            dgvComision = new DataGridView();
            btnAgregarComision = new Button();
            btnModificarComision = new Button();
            btnEliminarComision = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtNombreClienteComision = new TextBox();
            txtDescripcionComision = new TextBox();
            txtDireccionComision = new TextBox();
            txtFechaEntregaComision = new TextBox();
            txtComisionID = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvComision).BeginInit();
            SuspendLayout();
            // 
            // dgvComision
            // 
            dgvComision.AllowUserToAddRows = false;
            dgvComision.AllowUserToDeleteRows = false;
            dgvComision.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvComision.Location = new Point(394, 17);
            dgvComision.Name = "dgvComision";
            dgvComision.ReadOnly = true;
            dgvComision.RowTemplate.Height = 25;
            dgvComision.Size = new Size(644, 363);
            dgvComision.TabIndex = 0;
            dgvComision.CellClick += dgvComision_CellClick;
            dgvComision.CellContentClick += dgvComision_CellContentClick;
            // 
            // btnAgregarComision
            // 
            btnAgregarComision.Location = new Point(62, 303);
            btnAgregarComision.Name = "btnAgregarComision";
            btnAgregarComision.Size = new Size(138, 23);
            btnAgregarComision.TabIndex = 1;
            btnAgregarComision.Text = "Agregar Comision";
            btnAgregarComision.UseVisualStyleBackColor = true;
            btnAgregarComision.Click += btnAgregarComision_Click;
            // 
            // btnModificarComision
            // 
            btnModificarComision.Location = new Point(135, 344);
            btnModificarComision.Name = "btnModificarComision";
            btnModificarComision.Size = new Size(144, 23);
            btnModificarComision.TabIndex = 2;
            btnModificarComision.Text = "Modificar Comision";
            btnModificarComision.UseVisualStyleBackColor = true;
            btnModificarComision.Click += btnModificarComision_Click;
            // 
            // btnEliminarComision
            // 
            btnEliminarComision.Location = new Point(206, 303);
            btnEliminarComision.Name = "btnEliminarComision";
            btnEliminarComision.Size = new Size(132, 23);
            btnEliminarComision.TabIndex = 3;
            btnEliminarComision.Text = "Eliminar Comision";
            btnEliminarComision.UseVisualStyleBackColor = true;
            btnEliminarComision.Click += btnEliminarComision_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(62, 66);
            label1.Name = "label1";
            label1.Size = new Size(117, 15);
            label1.TabIndex = 4;
            label1.Text = "Nombre del cliente:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(62, 116);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 5;
            label2.Text = "Descripcion:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(62, 220);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 6;
            label3.Text = "Direccion:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(62, 264);
            label4.Name = "label4";
            label4.Size = new Size(105, 15);
            label4.TabIndex = 7;
            label4.Text = "Fecha de Entrega:";
            // 
            // txtNombreClienteComision
            // 
            txtNombreClienteComision.Location = new Point(175, 61);
            txtNombreClienteComision.Name = "txtNombreClienteComision";
            txtNombreClienteComision.Size = new Size(139, 23);
            txtNombreClienteComision.TabIndex = 8;
            // 
            // txtDescripcionComision
            // 
            txtDescripcionComision.Location = new Point(175, 113);
            txtDescripcionComision.Multiline = true;
            txtDescripcionComision.Name = "txtDescripcionComision";
            txtDescripcionComision.Size = new Size(139, 70);
            txtDescripcionComision.TabIndex = 9;
            // 
            // txtDireccionComision
            // 
            txtDireccionComision.Location = new Point(175, 216);
            txtDireccionComision.Name = "txtDireccionComision";
            txtDireccionComision.Size = new Size(139, 23);
            txtDireccionComision.TabIndex = 10;
            // 
            // txtFechaEntregaComision
            // 
            txtFechaEntregaComision.Location = new Point(175, 261);
            txtFechaEntregaComision.Name = "txtFechaEntregaComision";
            txtFechaEntregaComision.Size = new Size(139, 23);
            txtFechaEntregaComision.TabIndex = 11;
            // 
            // txtComisionID
            // 
            txtComisionID.Location = new Point(175, 17);
            txtComisionID.Name = "txtComisionID";
            txtComisionID.Size = new Size(139, 23);
            txtComisionID.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(62, 22);
            label5.Name = "label5";
            label5.Size = new Size(20, 15);
            label5.TabIndex = 12;
            label5.Text = "ID";
            label5.Click += label5_Click;
            // 
            // winComision
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(199, 123, 64);
            ClientSize = new Size(1224, 512);
            Controls.Add(txtComisionID);
            Controls.Add(label5);
            Controls.Add(txtFechaEntregaComision);
            Controls.Add(txtDireccionComision);
            Controls.Add(txtDescripcionComision);
            Controls.Add(txtNombreClienteComision);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnEliminarComision);
            Controls.Add(btnModificarComision);
            Controls.Add(btnAgregarComision);
            Controls.Add(dgvComision);
            Name = "winComision";
            Text = "winComision";
            Load += winComision_Load;
            ((System.ComponentModel.ISupportInitialize)dgvComision).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvComision;
        private Button btnAgregarComision;
        private Button btnModificarComision;
        private Button btnEliminarComision;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtNombreClienteComision;
        private TextBox txtDescripcionComision;
        private TextBox txtDireccionComision;
        private TextBox txtFechaEntregaComision;
        private TextBox txtComisionID;
        private Label label5;
    }
}