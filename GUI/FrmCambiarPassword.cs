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
using static System.Collections.Specialized.BitVector32;

namespace GUI
{
    public partial class FrmCambiarPassword : Form
    {
        private readonly UsuarioService usuarioService;

        public FrmCambiarPassword()
        {
            InitializeComponent();
            usuarioService = new UsuarioService();
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    string resultado = usuarioService.CambiarPassword(
                        Session.CurrentUser.id_usuario,
                        txtPasswordActual.Text,
                        txtNuevoPassword.Text);

                    MessageBox.Show(resultado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (!resultado.StartsWith("Error"))
                    {
                        // Actualizar usuario en sesión
                        Session.CurrentUser = usuarioService.BuscarPorId(Session.CurrentUser.id_usuario);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cambiar contraseña: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtPasswordActual.Text))
            {
                MessageBox.Show("Por favor, ingrese su contraseña actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNuevoPassword.Text))
            {
                MessageBox.Show("Por favor, ingrese la nueva contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtNuevoPassword.Text != txtConfirmarPassword.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
