namespace GUI
{
    partial class FrmDetalleCursoAdmin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEliminarCurso = new FontAwesome.Sharp.IconButton();
            this.btnVerEstudiantes = new System.Windows.Forms.Button();
            this.lblInscritos = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblInstructor = new System.Windows.Forms.Label();
            this.lblFechas = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(781, 64);
            this.panel1.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(17, 16);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(220, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Título del Curso";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox.Location = new System.Drawing.Point(0, 64);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(781, 267);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnEliminarCurso);
            this.panel2.Controls.Add(this.btnVerEstudiantes);
            this.panel2.Controls.Add(this.lblInscritos);
            this.panel2.Controls.Add(this.txtDescripcion);
            this.panel2.Controls.Add(this.lblInstructor);
            this.panel2.Controls.Add(this.lblFechas);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 331);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(23, 21, 23, 21);
            this.panel2.Size = new System.Drawing.Size(781, 297);
            this.panel2.TabIndex = 2;
            // 
            // btnEliminarCurso
            // 
            this.btnEliminarCurso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarCurso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminarCurso.FlatAppearance.BorderSize = 0;
            this.btnEliminarCurso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarCurso.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarCurso.ForeColor = System.Drawing.Color.White;
            this.btnEliminarCurso.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnEliminarCurso.IconColor = System.Drawing.Color.White;
            this.btnEliminarCurso.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminarCurso.IconSize = 24;
            this.btnEliminarCurso.Location = new System.Drawing.Point(617, 244);
            this.btnEliminarCurso.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminarCurso.Name = "btnEliminarCurso";
            this.btnEliminarCurso.Size = new System.Drawing.Size(137, 32);
            this.btnEliminarCurso.TabIndex = 8;
            this.btnEliminarCurso.Text = "Eliminar";
            this.btnEliminarCurso.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminarCurso.UseVisualStyleBackColor = false;
            this.btnEliminarCurso.Click += new System.EventHandler(this.btnEliminarCurso_Click);
            // 
            // btnVerEstudiantes
            // 
            this.btnVerEstudiantes.Location = new System.Drawing.Point(13, 244);
            this.btnVerEstudiantes.Margin = new System.Windows.Forms.Padding(4);
            this.btnVerEstudiantes.Name = "btnVerEstudiantes";
            this.btnVerEstudiantes.Size = new System.Drawing.Size(137, 32);
            this.btnVerEstudiantes.TabIndex = 7;
            this.btnVerEstudiantes.Text = "Ver Estudiantes";
            this.btnVerEstudiantes.UseVisualStyleBackColor = true;
            this.btnVerEstudiantes.Click += new System.EventHandler(this.btnVerEstudiantes_Click);
            // 
            // lblInscritos
            // 
            this.lblInscritos.AutoSize = true;
            this.lblInscritos.Location = new System.Drawing.Point(13, 211);
            this.lblInscritos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInscritos.Name = "lblInscritos";
            this.lblInscritos.Size = new System.Drawing.Size(69, 16);
            this.lblInscritos.TabIndex = 5;
            this.lblInscritos.Text = "Inscritos: 0";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.SystemColors.Window;
            this.txtDescripcion.Location = new System.Drawing.Point(18, 114);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(736, 64);
            this.txtDescripcion.TabIndex = 4;
            // 
            // lblInstructor
            // 
            this.lblInstructor.AutoSize = true;
            this.lblInstructor.Location = new System.Drawing.Point(15, 84);
            this.lblInstructor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInstructor.Name = "lblInstructor";
            this.lblInstructor.Size = new System.Drawing.Size(140, 16);
            this.lblInstructor.TabIndex = 3;
            this.lblInstructor.Text = "Descripcion del curso:";
          
            // 
            // lblFechas
            // 
            this.lblFechas.AutoSize = true;
            this.lblFechas.Location = new System.Drawing.Point(15, 21);
            this.lblFechas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechas.Name = "lblFechas";
            this.lblFechas.Size = new System.Drawing.Size(55, 16);
            this.lblFechas.TabIndex = 0;
            this.lblFechas.Text = "Fechas:";
            // 
            // FrmDetalleCursoAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 628);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmDetalleCursoAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalle del Curso";
            this.Load += new System.EventHandler(this.FrmDetalleCursoAdmin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnVerEstudiantes;
        private System.Windows.Forms.Label lblInscritos;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblInstructor;
        private System.Windows.Forms.Label lblFechas;
        private FontAwesome.Sharp.IconButton btnEliminarCurso;
    }
}