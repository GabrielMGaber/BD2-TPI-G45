using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veterinaria.Negocio;

namespace Veterinaria
{
    public partial class frmVistas : Form
    {
        public frmVistas()
        {
            InitializeComponent();
        }

        private void frmVistas_Load(object sender, EventArgs e)
        {
            cboVista.Items.Add("VW_VacunacionesVencidas");
            cboVista.Items.Add("VW_HistorialClinico");
            cboVista.Items.Add("VW_MedicamentosMasUtilizados");
            cboVista.SelectedIndex = 0;
        }

        private void cboVista_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                VistaNegocio negocio = new VistaNegocio();
                dgvVista.DataSource = negocio.listar(cboVista.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la vista: " + ex.Message);
            }
        }
    }
}