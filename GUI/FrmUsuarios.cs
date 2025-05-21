using System;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using ENTITY;

namespace GUI
{
    public partial class FrmUsuarios : Form
    {
        private readonly UsuarioService _usuarioService;
        //private readonly RGBColors _rgbColors;

        public FrmUsuarios()
        {
            InitializeComponent();
            _usuarioService = new UsuarioService();
            //_rgbColors = new RGBColors();
            ConfigurarDataGridView();
            CargarUsuarios();
        }

        private void ConfigurarDataGridView()
        {
            // Configuración básica del DataGridView
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // Establecer el estilo de las filas alternas
            dgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
        }

        private void CargarUsuarios()
        {
            try
            {
                var usuarios = _usuarioService.ConsultarDTO();
                dgvUsuarios.Rows.Clear();

                foreach (var usuario in usuarios)
                {
                    dgvUsuarios.Rows.Add(
                        usuario.id_usuario,
                        usuario.NombreCompleto,
                        usuario.email,
                        usuario.es_miembro == "S" ? "Sí" : "No"
                    );
                }

                // Ajustar el ancho de las columnas después de cargar los datos
                dgvUsuarios.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los usuarios: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void btnRefrescar_Click(object sender, EventArgs e)
        //{
        //    CargarUsuarios();
        //}

        //private void btnNuevoUsuario_Click(object sender, EventArgs e)
        //{
        //    FrmCrearUsuario frmCrearUsuario = new FrmCrearUsuario();
        //    if (frmCrearUsuario.ShowDialog() == DialogResult.OK)
        //    {
        //        CargarUsuarios();
        //    }
        //}

        //private void btnEditarUsuario_Click(object sender, EventArgs e)
        //{
        //    if (dgvUsuarios.SelectedRows.Count == 0)
        //    {
        //        MessageBox.Show("Por favor seleccione un usuario para editar", "Advertencia",
        //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    int usuarioId = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["colId"].Value);
        //    FrmEditarUsuario frmEditarUsuario = new FrmEditarUsuario(usuarioId);
        //    if (frmEditarUsuario.ShowDialog() == DialogResult.OK)
        //    {
        //        CargarUsuarios();
        //    }
        //}

        //private void btnEliminarUsuario_Click(object sender, EventArgs e)
        //{
        //    if (dgvUsuarios.SelectedRows.Count == 0)
        //    {
        //        MessageBox.Show("Por favor seleccione un usuario para eliminar", "Advertencia",
        //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    if (Session.CurrentUser?.es_administrador != "S")
        //    {
        //        MessageBox.Show("Solo los administradores pueden eliminar usuarios", "Acceso denegado",
        //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    int usuarioId = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["colId"].Value);
        //    string nombreUsuario = dgvUsuarios.SelectedRows[0].Cells["colNombre"].Value.ToString();

        //    var confirmacion = MessageBox.Show(
        //        $"¿Está seguro que desea eliminar al usuario: {nombreUsuario}?\n\nEsta acción no se puede deshacer.",
        //        "Confirmar eliminación",
        //        MessageBoxButtons.YesNo,
        //        MessageBoxIcon.Warning,
        //        MessageBoxDefaultButton.Button2);

        //    if (confirmacion == DialogResult.Yes)
        //    {
        //        try
        //        {
        //            var resultado = _usuarioService.Eliminar(usuarioId);

        //            if (resultado.StartsWith("Error"))
        //            {
        //                MessageBox.Show(resultado, "Error al eliminar",
        //                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //            else
        //            {
        //                MessageBox.Show("Usuario eliminado exitosamente", "Éxito",
        //                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                CargarUsuarios();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Error al procesar la eliminación: {ex.Message}",
        //                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            // Configurar visibilidad de botones según rol
            //btnEliminarUsuario.Visible = Session.CurrentUser?.es_administrador == "S";
            //btnEditarUsuario.Visible = Session.CurrentUser?.es_administrador == "S";
            //btnNuevoUsuario.Visible = Session.CurrentUser?.es_administrador == "S";
        }
    }
}