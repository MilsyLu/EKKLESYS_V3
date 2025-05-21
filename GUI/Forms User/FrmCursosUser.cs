using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using ENTITY;

namespace GUI
{
    public partial class FrmCursosUser : Form
    {
        private readonly CursoService cursoService;
        private List<CursoDTO> cursos;

        public FrmCursosUser()
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
                Panel panel = new Panel
                {
                    Width = 300,
                    Height = 200,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10),
                    BackColor = Color.White
                };

                Label lblNombre = new Label
                {
                    Text = curso.nombre_curso,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Width = 280,
                    Height = 30,
                    Location = new Point(10, 10)
                };

                Label lblFechas = new Label
                {
                    Text = $"Inicio: {curso.fecha_inicio_curso.ToShortDateString()} - Fin: {curso.fecha_fin_curso.ToShortDateString()}",
                    Width = 280,
                    Height = 20,
                    Location = new Point(10, 45)
                };

                Label lblCapacidad = new Label
                {
                    Text = $"Inscritos: {curso.NumeroInscritos}/{curso.capacidad_max_curso}",
                    Width = 150,
                    Height = 20,
                    Location = new Point(10, 70)
                };

                ProgressBar progressBar = new ProgressBar
                {
                    Minimum = 0,
                    Maximum = curso.capacidad_max_curso,
                    Value = curso.NumeroInscritos,
                    Width = 280,
                    Height = 20,
                    Location = new Point(10, 95)
                };

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

                panel.Controls.Add(lblNombre);
                panel.Controls.Add(lblFechas);
                panel.Controls.Add(lblCapacidad);
                panel.Controls.Add(progressBar);
                panel.Controls.Add(btnVerDetalles);

                flpCursos.Controls.Add(panel);
            }
        }

        private void BtnVerDetalles_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int cursoId = (int)btn.Tag;

            FrmDetalleCursoUser detalleForm = new FrmDetalleCursoUser(cursoId);
            detalleForm.ShowDialog();

            CargarCursos(); // Por si cambia el estado del curso
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarCursos();
        }

        private void FrmCursosUser_Load(object sender, EventArgs e)
        {
            // Evento opcional para carga inicial
        }

        private void flpCursos_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
