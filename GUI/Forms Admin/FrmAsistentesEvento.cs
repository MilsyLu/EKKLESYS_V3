using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class FrmAsistentesEvento : Form
    {
        private readonly EventoService eventoService;
        private readonly int idEvento;

        public FrmAsistentesEvento(int idEvento)
        {
            InitializeComponent();
            eventoService = new EventoService();
            this.idEvento = idEvento;
            CargarDatos();
        }

        private void CargarDatos()
        {
            var evento = eventoService.BuscarPorId(idEvento);
            if (evento != null)
            {
                lblTitulo.Text = $"Asistentes al evento: {evento.nombre_evento}";
                lblCapacidad.Text = $"Capacidad: {evento.NumeroAsistentes} / {evento.capacidad_max_evento}";

                dgvAsistentes.Rows.Clear();
                foreach (var asistente in evento.Asistentes)
                {
                    dgvAsistentes.Rows.Add(asistente.id_usuario, asistente.NombreCompleto, asistente.email, asistente.telefono);
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
