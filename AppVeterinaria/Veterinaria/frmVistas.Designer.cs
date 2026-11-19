namespace Veterinaria
{
    partial class frmVistas
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
            this.lblVista = new System.Windows.Forms.Label();
            this.cboVista = new System.Windows.Forms.ComboBox();
            this.dgvVista = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVista)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVista
            // 
            this.lblVista.AutoSize = true;
            this.lblVista.Location = new System.Drawing.Point(160, 73);
            this.lblVista.Name = "lblVista";
            this.lblVista.Size = new System.Drawing.Size(30, 13);
            this.lblVista.TabIndex = 0;
            this.lblVista.Text = "Vista";
            // 
            // cboVista
            // 
            this.cboVista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVista.FormattingEnabled = true;
            this.cboVista.Location = new System.Drawing.Point(163, 108);
            this.cboVista.Name = "cboVista";
            this.cboVista.Size = new System.Drawing.Size(250, 21);
            this.cboVista.TabIndex = 1;
            this.cboVista.SelectedIndexChanged += new System.EventHandler(this.cboVista_SelectedIndexChanged);
            // 
            // dgvVista
            // 
            this.dgvVista.AllowUserToAddRows = false;
            this.dgvVista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvVista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVista.Location = new System.Drawing.Point(49, 147);
            this.dgvVista.Name = "dgvVista";
            this.dgvVista.ReadOnly = true;
            this.dgvVista.Size = new System.Drawing.Size(700, 266);
            this.dgvVista.TabIndex = 2;
            // 
            // frmVistas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvVista);
            this.Controls.Add(this.cboVista);
            this.Controls.Add(this.lblVista);
            this.Name = "frmVistas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vistas";
            this.Load += new System.EventHandler(this.frmVistas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVista;
        private System.Windows.Forms.ComboBox cboVista;
        private System.Windows.Forms.DataGridView dgvVista;
    }
}