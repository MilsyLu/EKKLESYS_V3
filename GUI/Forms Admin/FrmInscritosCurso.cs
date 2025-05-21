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
    public partial class FrmInscritosCurso : Form
    {
        private readonly CursoService cursoService;
        private readonly int idCurso;

        public FrmInscritosCurso(int idCurso)
        {
            InitializeComponent();
            cursoService = new CursoService();
            this.idCurso = idCurso;
            CargarDatos();
        }

        public FrmInscritosCurso()
        {
        }

        private void CargarDatos()
        {
            var curso = cursoService.BuscarPorId(idCurso);
            if (curso != null)
            {
                lblTitulo.Text = $"Inscritos en el curso: {curso.nombre_curso}";
                lblCapacidad.Text = $"Capacidad: {curso.NumeroInscritos} / {curso.capacidad_max_curso}";

                dgvInscritos.Rows.Clear();
                foreach (var estudiante in curso.Estudiantes)
                {
                    dgvInscritos.Rows.Add(estudiante.id_usuario, estudiante.NombreCompleto, estudiante.email, estudiante.telefono);
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
