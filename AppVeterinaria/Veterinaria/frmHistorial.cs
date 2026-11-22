using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veterinaria.Dominio;
using Veterinaria.Negocio;

namespace Veterinaria
{
    public partial class frmHistorial : Form
    {
        public frmHistorial()
        {
            InitializeComponent();
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {
            try
            {
                MascotaNegocio negocio = new MascotaNegocio();
                cboMascota.DataSource = negocio.listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar las mascotas: " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Mascota seleccionada = (Mascota)cboMascota.SelectedItem;
            if (seleccionada == null)
            {
                MessageBox.Show("Elegí una mascota.");
                return;
            }

            // Si el casillero de la fecha no esta tildado, no se filtra por esa fecha
            DateTime? desde = null;
            DateTime? hasta = null;
            if (dtpDesde.Checked)
                desde = dtpDesde.Value;
            if (dtpHasta.Checked)
                hasta = dtpHasta.Value;

            try
            {
                HistorialNegocio negocio = new HistorialNegocio();
                DataSet resultado = negocio.listar(seleccionada.Id, desde, hasta);

                dgvConsultas.DataSource = resultado.Tables[0];
                dgvVacunaciones.DataSource = resultado.Tables[1];
                dgvResumen.DataSource = resultado.Tables[2];
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo obtener el historial: " + ex.Message);
            }
        }
    }
}