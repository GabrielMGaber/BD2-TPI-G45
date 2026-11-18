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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                MedicamentoNegocio negocio = new MedicamentoNegocio();
                dgvStock.DataSource = negocio.listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los medicamentos: " + ex.Message);
            }
        }
    }
}
