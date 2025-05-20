using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using ENTITY;

namespace GUI
{
    public partial class FrmEventosAdmin : Form
    {
        private readonly EventoService eventoService;
        private List<EventoDTO> eventos;

        public FrmEventosAdmin()
        {
            InitializeComponent();
            eventoService = new EventoService();
            CargarEventos();
        }

        private void CargarEventos()
        {
            eventos = eventoService.ConsultarDTO();
            flpEventos.Controls.Clear();

            foreach (var evento in eventos)
            {
                // Panel principal para el evento
                Panel panel = new Panel
                {
                    Width = 300,
                    Height = 220,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10),
                    BackColor = Color.White
                };

                // Título del evento
                Label lblNombre = new Label
                {
                    Text = evento.nombre_evento,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Width = 280,
                    Height = 30,
                    Location = new Point(10, 10)
                };

                // Lugar del evento
                Label lblLugar = new Label
                {
                    Text = $"Lugar: {evento.lugar_evento}",
                    Width = 280,
                    Height = 20,
                    Location = new Point(10, 45)
                };

                // Fechas
                Label lblFechas = new Label
                {
                    Text = $"Inicio: {evento.fecha_inicio_evento.ToShortDateString()} - Fin: {evento.fecha_fin_evento.ToShortDateString()}",
                    Width = 280,
                    Height = 20,
                    Location = new Point(10, 70)
                };

                // Capacidad e inscritos
                Label lblCapacidad = new Label
                {
                    Text = $"Asistentes: {evento.NumeroAsistentes}/{evento.capacidad_max_evento}",
                    Width = 150,
                    Height = 20,
                    Location = new Point(10, 95)
                };

                // Barra de progreso para visualizar ocupación
                ProgressBar progressBar = new ProgressBar
                {
                    Minimum = 0,
                    Maximum = evento.capacidad_max_evento,
                    Value = evento.NumeroAsistentes,
                    Width = 280,
                    Height = 20,
                    Location = new Point(10, 120)
                };

                // Botón para ver detalles
                Button btnVerDetalles = new Button
                {
                    Text = "Ver detalles",
                    Width = 120,
                    Height = 30,
                    Location = new Point(10, 150),
                    Tag = evento.id_evento,
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
                //    Location = new Point(140, 150),
                //    Tag = evento.id_evento,
                //    BackColor = Color.LightGreen,
                //    FlatStyle = FlatStyle.Flat
                //};
                //btnEditar.Click += BtnEditar_Click;

                // Agregar controles al panel
                panel.Controls.Add(lblNombre);
                panel.Controls.Add(lblLugar);
                panel.Controls.Add(lblFechas);
                panel.Controls.Add(lblCapacidad);
                panel.Controls.Add(progressBar);
                panel.Controls.Add(btnVerDetalles);
                //panel.Controls.Add(btnEditar);

                // Agregar panel al FlowLayoutPanel
                flpEventos.Controls.Add(panel);
            }
        }

        private void BtnVerDetalles_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int eventoId = (int)btn.Tag;

            FrmDetalleEventoAdmin detalleForm = new FrmDetalleEventoAdmin(eventoId);
            detalleForm.ShowDialog();

            // Recargar eventos al cerrar el formulario de detalles
            CargarEventos();
        }

        //private void BtnEditar_Click(object sender, EventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    int eventoId = (int)btn.Tag;

        //    FrmEditarEvento editarForm = new FrmEditarEvento(eventoId);
        //    if (editarForm.ShowDialog() == DialogResult.OK)
        //    {
        //        CargarEventos();
        //    }
        //}

        private void btnNuevoEvento_Click(object sender, EventArgs e)
        {
            FrmCrearEvento crearForm = new FrmCrearEvento();
            if (crearForm.ShowDialog() == DialogResult.OK)
            {
                CargarEventos();
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarEventos();
        }

        private void EventosForm_Load(object sender, EventArgs e)
        {
            // Puedes agregar código de inicialización adicional aquí si es necesario
        }
    }
}