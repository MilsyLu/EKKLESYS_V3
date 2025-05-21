using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmInicio2 : Form
    {
        public FrmInicio2()
        {
            InitializeComponent();
            ConfigureTabControl();
            SetActiveTab(tabInicio); // Mostrar la pestaña de inicio por defecto
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
        }

        private void ConfigureTabControl()
        {
            // Ocultar los headers de las pestañas
            tabControlMain.Appearance = TabAppearance.FlatButtons;
            tabControlMain.ItemSize = new Size(0, 1);
            tabControlMain.SizeMode = TabSizeMode.Fixed;
        }

        private void SetActiveTab(TabPage tabPage)
        {
            tabControlMain.SelectTab(tabPage);

            // Actualizar el estado de los botones de navegación
            btnInicio.BackColor = tabPage == tabInicio ? Color.FromArgb(60, 80, 140) : Color.Transparent;
            btnCursos.BackColor = tabPage == tabCursos ? Color.FromArgb(60, 80, 140) : Color.Transparent;
            btnEventos.BackColor = tabPage == tabEventos ? Color.FromArgb(60, 80, 140) : Color.Transparent;
            btnContacto.BackColor = tabPage == tabContacto ? Color.FromArgb(60, 80, 140) : Color.Transparent;
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            var loginForm = new FrmLogin();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            var registroForm = new RegistroForm();
            this.Hide();
            registroForm.ShowDialog();
            this.Close();
        }

        private void btnComenzarAhora_Click(object sender, EventArgs e)
        {
            SetActiveTab(tabCursos); // Cambiar a la pestaña de servicios/cursos
        }

        private void btnConocerMas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("EKKLESYS es un sistema de gestión integral para iglesias.", "Acerca de EKKLESYS");
        }

        private void btnVerDetallesCurso_Click(object sender, EventArgs e)
        {
            //var detalleForm = new FrmDetalleEventoUser();
            //detalleForm.ShowDialog();
        }

        // Manejadores para los botones de navegación
        private void btnInicio_Click(object sender, EventArgs e)
        {
            SetActiveTab(tabInicio);
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            SetActiveTab(tabCursos);
        }

        private void btnEventos_Click(object sender, EventArgs e)
        {
            SetActiveTab(tabEventos);
        }

        private void btnContacto_Click(object sender, EventArgs e)
        {
            SetActiveTab(tabContacto);
        }
    }
}