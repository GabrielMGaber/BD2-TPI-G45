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
    public partial class frmRecetas : Form
    {
        public frmRecetas()
        {
            InitializeComponent();
        }

        private void frmRecetas_Load(object sender, EventArgs e)
        {
            try
            {
                MedicamentoNegocio medicamentoNegocio = new MedicamentoNegocio();
                cboMedicamento.DataSource = medicamentoNegocio.listar();

                ConsultaNegocio consultaNegocio = new ConsultaNegocio();
                cboConsulta.DataSource = consultaNegocio.listar();

                cargarStock();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos: " + ex.Message);
            }
        }

        private void cargarStock()
        {
            MedicamentoNegocio negocio = new MedicamentoNegocio();
            dgvStock.DataSource = negocio.listar();
        }

        private void cargarDetalle()
        {
            Consulta seleccionada = (Consulta)cboConsulta.SelectedItem;
            if (seleccionada == null)
                return;

            DetalleConsultaNegocio negocio = new DetalleConsultaNegocio();
            dgvDetalle.DataSource = negocio.listar(seleccionada.Id);
        }

        private void cboConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cargarDetalle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el detalle: " + ex.Message);
            }
        }

        private void btnRecetar_Click(object sender, EventArgs e)
        {
            Consulta consulta = (Consulta)cboConsulta.SelectedItem;
            Medicamento medicamento = (Medicamento)cboMedicamento.SelectedItem;
            int cantidad = (int)nudCantidad.Value;

            // La tabla no permite el mismo medicamento dos veces en una consulta
            List<DetalleConsulta> detalle = (List<DetalleConsulta>)dgvDetalle.DataSource;
            foreach (DetalleConsulta item in detalle)
            {
                if (item.Medicamento.Id == medicamento.Id)
                {
                    MessageBox.Show("Ese medicamento ya está en la consulta.");
                    return;
                }
            }

            try
            {
                DetalleConsultaNegocio negocio = new DetalleConsultaNegocio();
                negocio.agregar(consulta.Id, medicamento.Id, cantidad);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo recetar: " + ex.Message);
            }

            // Se recarga siempre, para que se vea el efecto del trigger (o que no hubo cambio)
            cargarDetalle();
            cargarStock();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow == null)
            {
                MessageBox.Show("Elegí un medicamento de la lista.");
                return;
            }

            DetalleConsulta seleccionado = (DetalleConsulta)dgvDetalle.CurrentRow.DataBoundItem;

            try
            {
                DetalleConsultaNegocio negocio = new DetalleConsultaNegocio();
                negocio.eliminar(seleccionado.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo quitar: " + ex.Message);
            }

            cargarDetalle();
            cargarStock();
        }
    }
}