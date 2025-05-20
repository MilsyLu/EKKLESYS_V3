using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using ENTITY;

namespace GUI
{
    public partial class RegistroForm : Form
    {
        private readonly UsuarioService usuarioService;
        private readonly ComunaService comunaService;
        private string rutaImagenSeleccionada;

        public RegistroForm()
        {
            InitializeComponent();
            usuarioService = new UsuarioService();
            comunaService = new ComunaService();
            CargarComunas();
        }

        private void CargarComunas()
        {
            var comunas = comunaService.ConsultarTodas();
            cmbComuna.DataSource = comunas;
            cmbComuna.DisplayMember = "nombre_comuna";
            cmbComuna.ValueMember = "id_comuna";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    Usuario usuario = new Usuario
                    {
                        nombre = txtNombre.Text,
                        apellido_paterno = txtApellido.Text,
                        fecha_nacimiento = dtpFechaNacimiento.Value,
                        direccion = txtDireccion.Text,
                        telefono = txtTelefono.Text,
                        telefono_2 = string.IsNullOrWhiteSpace(txtTelefono2.Text) ? null : txtTelefono2.Text,
                        email = txtEmail.Text,
                        cedula = txtCedula.Text,
                        clave = txtPassword.Text,
                        es_miembro = rbSi.Checked ? "S" : "N",
                        ruta_imagen_usuario = rutaImagenSeleccionada,
                        id_comuna = (int)cmbComuna.SelectedValue
                    };

                    string resultado = usuarioService.Guardar(usuario);
                    MessageBox.Show(resultado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (!resultado.StartsWith("Error"))
                    {
                        FrmLogin frmLogin = new FrmLogin();
                        frmLogin.Show();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al registrar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese su nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Por favor, ingrese su apellido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Por favor, ingrese su dirección", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Por favor, ingrese su teléfono", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Por favor, ingrese su correo electrónico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Por favor, ingrese una contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtPassword.Text != txtConfirmarPassword.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("Por favor, ingrese su cédula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbComuna.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione una comuna", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Seleccionar imagen de perfil";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    rutaImagenSeleccionada = openFileDialog.FileName;
                    txtRutaImagen.Text = Path.GetFileName(rutaImagenSeleccionada);
                    pictureBox.Image = System.Drawing.Image.FromFile(rutaImagenSeleccionada);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Close();
        }
    }
}
