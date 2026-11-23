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
    public partial class frmNuevaConsulta : Form
    {
        public frmNuevaConsulta()
        {
            InitializeComponent();
        }

        private void frmNuevaConsulta_Load(object sender, EventArgs e)
        {
            try
            {
                MascotaNegocio mascotaNegocio = new MascotaNegocio();
                cboMascota.DataSource = mascotaNegocio.listar();

                VeterinarioNegocio veterinarioNegocio = new VeterinarioNegocio();
                cboVeterinario.DataSource = veterinarioNegocio.listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Las validaciones las hace el procedimiento SP_RegistrarConsulta:
            // si algo esta mal, su mensaje se muestra en el catch.
            Consulta nueva = new Consulta();
            nueva.Mascota = (Mascota)cboMascota.SelectedItem;
            nueva.Veterinario = (Veterinario)cboVeterinario.SelectedItem;
            nueva.Fecha = dtpFecha.Value;
            nueva.Motivo = txtMotivo.Text;
            nueva.Diagnostico = txtDiagnostico.Text;
            nueva.Observaciones = txtObservaciones.Text;

            try
            {
                ConsultaNegocio negocio = new ConsultaNegocio();
                int id = negocio.registrar(nueva);

                MessageBox.Show("Consulta registrada con el número " + id + ".");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo registrar la consulta: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}