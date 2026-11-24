namespace Veterinaria
{
    partial class frmRecetas
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
            this.lblConsulta = new System.Windows.Forms.Label();
            this.cboConsulta = new System.Windows.Forms.ComboBox();
            this.lblMedicamento = new System.Windows.Forms.Label();
            this.cboMedicamento = new System.Windows.Forms.ComboBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnRecetar = new System.Windows.Forms.Button();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.lblStock = new System.Windows.Forms.Label();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.SuspendLayout();
            // 
            // lblConsulta
            // 
            this.lblConsulta.AutoSize = true;
            this.lblConsulta.Location = new System.Drawing.Point(20, 20);
            this.lblConsulta.Name = "lblConsulta";
            this.lblConsulta.Size = new System.Drawing.Size(51, 13);
            this.lblConsulta.TabIndex = 0;
            this.lblConsulta.Text = "Consulta";
            // 
            // cboConsulta
            // 
            this.cboConsulta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConsulta.FormattingEnabled = true;
            this.cboConsulta.Location = new System.Drawing.Point(110, 17);
            this.cboConsulta.Name = "cboConsulta";
            this.cboConsulta.Size = new System.Drawing.Size(300, 21);
            this.cboConsulta.TabIndex = 1;
            this.cboConsulta.SelectedIndexChanged += new System.EventHandler(this.cboConsulta_SelectedIndexChanged);
            // 
            // lblMedicamento
            // 
            this.lblMedicamento.AutoSize = true;
            this.lblMedicamento.Location = new System.Drawing.Point(20, 55);
            this.lblMedicamento.Name = "lblMedicamento";
            this.lblMedicamento.Size = new System.Drawing.Size(71, 13);
            this.lblMedicamento.TabIndex = 2;
            this.lblMedicamento.Text = "Medicamento";
            // 
            // cboMedicamento
            // 
            this.cboMedicamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMedicamento.FormattingEnabled = true;
            this.cboMedicamento.Location = new System.Drawing.Point(110, 52);
            this.cboMedicamento.Name = "cboMedicamento";
            this.cboMedicamento.Size = new System.Drawing.Size(200, 21);
            this.cboMedicamento.TabIndex = 3;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(320, 55);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(49, 13);
            this.lblCantidad.TabIndex = 4;
            this.lblCantidad.Text = "Cantidad";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(380, 52);
            this.nudCantidad.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(70, 20);
            this.nudCantidad.TabIndex = 5;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnRecetar
            // 
            this.btnRecetar.Location = new System.Drawing.Point(470, 50);
            this.btnRecetar.Name = "btnRecetar";
            this.btnRecetar.Size = new System.Drawing.Size(90, 25);
            this.btnRecetar.TabIndex = 6;
            this.btnRecetar.Text = "Recetar";
            this.btnRecetar.UseVisualStyleBackColor = true;
            this.btnRecetar.Click += new System.EventHandler(this.btnRecetar_Click);
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Location = new System.Drawing.Point(20, 90);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(146, 13);
            this.lblDetalle.TabIndex = 7;
            this.lblDetalle.Text = "Medicamentos de la consulta";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(20, 110);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(540, 150);
            this.dgvDetalle.TabIndex = 8;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(20, 268);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(150, 25);
            this.btnQuitar.TabIndex = 9;
            this.btnQuitar.Text = "Quitar seleccionado";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(20, 305);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(117, 13);
            this.lblStock.TabIndex = 10;
            this.lblStock.Text = "Stock de medicamentos";
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Location = new System.Drawing.Point(20, 325);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.ReadOnly = true;
            this.dgvStock.Size = new System.Drawing.Size(540, 170);
            this.dgvStock.TabIndex = 11;
            // 
            // frmRecetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 515);
            this.Controls.Add(this.dgvStock);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.btnRecetar);
            this.Controls.Add(this.nudCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.cboMedicamento);
            this.Controls.Add(this.lblMedicamento);
            this.Controls.Add(this.cboConsulta);
            this.Controls.Add(this.lblConsulta);
            this.Name = "frmRecetas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recetar medicamentos";
            this.Load += new System.EventHandler(this.frmRecetas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConsulta;
        private System.Windows.Forms.ComboBox cboConsulta;
        private System.Windows.Forms.Label lblMedicamento;
        private System.Windows.Forms.ComboBox cboMedicamento;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Button btnRecetar;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.DataGridView dgvStock;
    }
}