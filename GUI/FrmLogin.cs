﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using ENTITY;
using static System.Collections.Specialized.BitVector32;

namespace GUI
{
    public partial class FrmLogin : Form
    {
        private readonly UsuarioService usuarioService;

        public FrmLogin()
        {
            InitializeComponent();
            usuarioService = new UsuarioService();
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Por favor, ingrese su correo electrónico y contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Usuario usuario = usuarioService.Login(txtEmail.Text, txtPassword.Text);
            if (usuario == null)
            {
                MessageBox.Show("Correo electrónico o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Guardar usuario en sesión
            Session.CurrentUser = usuario;

            // Abrir formulario principal según el tipo de usuario
            if (usuario.es_administrador == "S")
            {
                FrmPrincipalAdmin frmPrincipalAdmin = new FrmPrincipalAdmin();
                frmPrincipalAdmin.Show();
            }
            else
            {
                FrmPrincipalUser frmPrincipalUser = new FrmPrincipalUser();
                frmPrincipalUser.Show();
            }

            this.Hide();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            RegistroForm registroForm = new RegistroForm();
            registroForm.Show();
            this.Hide();
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblinkRegistrarse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistroForm registroForm = new RegistroForm();
            registroForm.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
