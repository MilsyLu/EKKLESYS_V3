using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using ENTITY;

namespace GUI
{
    public partial class FrmCursosAdmin : Form
    {
        private readonly CursoService cursoService;
        private List<CursoDTO> cursos;

        public FrmCursosAdmin()
        {
            InitializeComponent();
            cursoService = new CursoService();
            CargarCursos();
        }

        private void CargarCursos()
        {
            cursos = cursoService.ConsultarDTO();
            flpCursos.Controls.Clear();

            foreach (var curso in cursos)
            {
                // Panel principal para el curso
                Panel panel = new Panel
                {
                    Width = 300,
                    Height = 200,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10),
                    BackColor = Color.White
                };

                // Título del curso
                Label lblNombre = new Label
                {
                    Text = curso.nombre_curso,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Width = 280,
                    Height = 30,
                    Location = new Point(10, 10)
                };

                // Fechas
                Label lblFechas = new Label
                {
                    Text = $"Inicio: {curso.fecha_inicio_curso.ToShortDateString()} - Fin: {curso.fecha_fin_curso.ToShortDateString()}",
                    Width = 280,
                    Height = 20,
                    Location = new Point(10, 45)
                };

                // Capacidad e inscritos
                Label lblCapacidad = new Label
                {
                    Text = $"Inscritos: {curso.NumeroInscritos}/{curso.capacidad_max_curso}",
                    Width = 150,
                    Height = 20,
                    Location = new Point(10, 70)
                };

                // Barra de progreso para visualizar ocupación
                ProgressBar progressBar = new ProgressBar
                {
                    Minimum = 0,
                    Maximum = curso.capacidad_max_curso,
                    Value = curso.NumeroInscritos,
                    Width = 280,
                    Height = 20,
                    Location = new Point(10, 95)
                };

                // Botón para ver detalles
                Button btnVerDetalles = new Button
                {
                    Text = "Ver detalles",
                    Width = 120,
                    Height = 30,
                    Location = new Point(10, 125),
                    Tag = curso.id_curso,
                    BackColor = Color.LightSteelBlue,
                    FlatStyle = FlatStyle.Flat
                };
                btnVerDetalles.Click += BtnVerDetalles_Click;

                //// Botón para editar
                //Button btnEditar = new Button
                //{
                //    Text = "Editar",
                //    Width = 120,
                //    Height = 30,
                //    Location = new Point(140, 125),
                //    Tag = curso.id_curso,
                //    BackColor = Color.LightGreen,
                //    FlatStyle = FlatStyle.Flat
                //};
                //btnEditar.Click += BtnEditar_Click;

                // Agregar controles al panel
                panel.Controls.Add(lblNombre);
                panel.Controls.Add(lblFechas);
                panel.Controls.Add(lblCapacidad);
                panel.Controls.Add(progressBar);
                panel.Controls.Add(btnVerDetalles);
                //panel.Controls.Add(btnEditar);

                // Agregar panel al FlowLayoutPanel
                flpCursos.Controls.Add(panel);
            }
        }

        private void BtnVerDetalles_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int cursoId = (int)btn.Tag;

            FrmDetalleCursoAdmin detalleForm = new FrmDetalleCursoAdmin(cursoId);
            detalleForm.ShowDialog();

            // Recargar cursos al cerrar el formulario de detalles
            CargarCursos();
        }

        //private void BtnEditar_Click(object sender, EventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    int cursoId = (int)btn.Tag;

        //    FrmEditarCurso editarForm = new FrmEditarCurso(cursoId);
        //    if (editarForm.ShowDialog() == DialogResult.OK)
        //    {
        //        CargarCursos();
        //    }
        //}

        private void btnNuevoCurso_Click(object sender, EventArgs e)
        {
            FrmCrearCurso crearForm = new FrmCrearCurso();
            if (crearForm.ShowDialog() == DialogResult.OK)
            {
                CargarCursos();
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarCursos();
        }

        private void CursosForm_Load(object sender, EventArgs e)
        {

        }
    }
}