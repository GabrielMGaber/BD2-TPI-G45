namespace Veterinaria
{
    partial class frmHistorial
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
            this.lblMascota = new System.Windows.Forms.Label();
            this.cboMascota = new System.Windows.Forms.ComboBox();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblConsultas = new System.Windows.Forms.Label();
            this.dgvConsultas = new System.Windows.Forms.DataGridView();
            this.lblVacunaciones = new System.Windows.Forms.Label();
            this.dgvVacunaciones = new System.Windows.Forms.DataGridView();
            this.lblResumen = new System.Windows.Forms.Label();
            this.dgvResumen = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVacunaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumen)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMascota
            // 
            this.lblMascota.AutoSize = true;
            this.lblMascota.Location = new System.Drawing.Point(20, 20);
            this.lblMascota.Name = "lblMascota";
            this.lblMascota.Size = new System.Drawing.Size(48, 13);
            this.lblMascota.TabIndex = 0;
            this.lblMascota.Text = "Mascota";
            // 
            // cboMascota
            // 
            this.cboMascota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMascota.FormattingEnabled = true;
            this.cboMascota.Location = new System.Drawing.Point(80, 17);
            this.cboMascota.Name = "cboMascota";
            this.cboMascota.Size = new System.Drawing.Size(180, 21);
            this.cboMascota.TabIndex = 1;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(280, 20);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(38, 13);
            this.lblDesde.TabIndex = 2;
            this.lblDesde.Text = "Desde";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Checked = false;
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(325, 17);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.ShowCheckBox = true;
            this.dtpDesde.Size = new System.Drawing.Size(130, 20);
            this.dtpDesde.TabIndex = 3;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(475, 20);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(35, 13);
            this.lblHasta.TabIndex = 4;
            this.lblHasta.Text = "Hasta";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Checked = false;
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(515, 17);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.ShowCheckBox = true;
            this.dtpHasta.Size = new System.Drawing.Size(130, 20);
            this.dtpHasta.TabIndex = 5;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(665, 15);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 25);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblConsultas
            // 
            this.lblConsultas.AutoSize = true;
            this.lblConsultas.Location = new System.Drawing.Point(20, 55);
            this.lblConsultas.Name = "lblConsultas";
            this.lblConsultas.Size = new System.Drawing.Size(54, 13);
            this.lblConsultas.TabIndex = 7;
            this.lblConsultas.Text = "Consultas";
            // 
            // dgvConsultas
            // 
            this.dgvConsultas.AllowUserToAddRows = false;
            this.dgvConsultas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvConsultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultas.Location = new System.Drawing.Point(20, 75);
            this.dgvConsultas.Name = "dgvConsultas";
            this.dgvConsultas.ReadOnly = true;
            this.dgvConsultas.Size = new System.Drawing.Size(850, 170);
            this.dgvConsultas.TabIndex = 8;
            // 
            // lblVacunaciones
            // 
            this.lblVacunaciones.AutoSize = true;
            this.lblVacunaciones.Location = new System.Drawing.Point(20, 255);
            this.lblVacunaciones.Name = "lblVacunaciones";
            this.lblVacunaciones.Size = new System.Drawing.Size(74, 13);
            this.lblVacunaciones.TabIndex = 9;
            this.lblVacunaciones.Text = "Vacunaciones";
            // 
            // dgvVacunaciones
            // 
            this.dgvVacunaciones.AllowUserToAddRows = false;
            this.dgvVacunaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvVacunaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVacunaciones.Location = new System.Drawing.Point(20, 275);
            this.dgvVacunaciones.Name = "dgvVacunaciones";
            this.dgvVacunaciones.ReadOnly = true;
            this.dgvVacunaciones.Size = new System.Drawing.Size(850, 130);
            this.dgvVacunaciones.TabIndex = 10;
            // 
            // lblResumen
            // 
            this.lblResumen.AutoSize = true;
            this.lblResumen.Location = new System.Drawing.Point(20, 415);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(52, 13);
            this.lblResumen.TabIndex = 11;
            this.lblResumen.Text = "Resumen";
            // 
            // dgvResumen
            // 
            this.dgvResumen.AllowUserToAddRows = false;
            this.dgvResumen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResumen.Location = new System.Drawing.Point(20, 435);
            this.dgvResumen.Name = "dgvResumen";
            this.dgvResumen.ReadOnly = true;
            this.dgvResumen.Size = new System.Drawing.Size(850, 70);
            this.dgvResumen.TabIndex = 12;
            // 
            // frmHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 520);
            this.Controls.Add(this.dgvResumen);
            this.Controls.Add(this.lblResumen);
            this.Controls.Add(this.dgvVacunaciones);
            this.Controls.Add(this.lblVacunaciones);
            this.Controls.Add(this.dgvConsultas);
            this.Controls.Add(this.lblConsultas);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.lblDesde);
            this.Controls.Add(this.cboMascota);
            this.Controls.Add(this.lblMascota);
            this.Name = "frmHistorial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial de mascota";
            this.Load += new System.EventHandler(this.frmHistorial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVacunaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMascota;
        private System.Windows.Forms.ComboBox cboMascota;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblConsultas;
        private System.Windows.Forms.DataGridView dgvConsultas;
        private System.Windows.Forms.Label lblVacunaciones;
        private System.Windows.Forms.DataGridView dgvVacunaciones;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.DataGridView dgvResumen;
    }
}