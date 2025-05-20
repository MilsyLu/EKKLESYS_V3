namespace GUI
{
    partial class FrmDetalleEventoAdmin
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
            this.btnEliminarEvento = new FontAwesome.Sharp.IconButton();
            this.btnVerAsistentes = new System.Windows.Forms.Button();
            this.lblAsistentes = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblFechas = new System.Windows.Forms.Label();
            this.lblLugar = new System.Windows.Forms.Label();
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
            this.lblTitulo.Size = new System.Drawing.Size(235, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Título del Evento";
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
            this.panel2.Controls.Add(this.lblLugar);
            this.panel2.Controls.Add(this.btnEliminarEvento);
            this.panel2.Controls.Add(this.btnVerAsistentes);
            this.panel2.Controls.Add(this.lblAsistentes);
            this.panel2.Controls.Add(this.txtDescripcion);
            this.panel2.Controls.Add(this.lblDescripcion);
            this.panel2.Controls.Add(this.lblFechas);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 331);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(23, 21, 23, 21);
            this.panel2.Size = new System.Drawing.Size(781, 297);
            this.panel2.TabIndex = 2;
            // 
            // btnEliminarEvento
            // 
            this.btnEliminarEvento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarEvento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminarEvento.FlatAppearance.BorderSize = 0;
            this.btnEliminarEvento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarEvento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarEvento.ForeColor = System.Drawing.Color.White;
            this.btnEliminarEvento.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnEliminarEvento.IconColor = System.Drawing.Color.White;
            this.btnEliminarEvento.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminarEvento.IconSize = 24;
            this.btnEliminarEvento.Location = new System.Drawing.Point(617, 244);
            this.btnEliminarEvento.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminarEvento.Name = "btnEliminarEvento";
            this.btnEliminarEvento.Size = new System.Drawing.Size(137, 32);
            this.btnEliminarEvento.TabIndex = 8;
            this.btnEliminarEvento.Text = "Eliminar";
            this.btnEliminarEvento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminarEvento.UseVisualStyleBackColor = false;
            this.btnEliminarEvento.Click += new System.EventHandler(this.btnEliminarEvento_Click);
            // 
            // btnVerAsistentes
            // 
            this.btnVerAsistentes.Location = new System.Drawing.Point(13, 244);
            this.btnVerAsistentes.Margin = new System.Windows.Forms.Padding(4);
            this.btnVerAsistentes.Name = "btnVerAsistentes";
            this.btnVerAsistentes.Size = new System.Drawing.Size(137, 32);
            this.btnVerAsistentes.TabIndex = 7;
            this.btnVerAsistentes.Text = "Ver Asistentes";
            this.btnVerAsistentes.UseVisualStyleBackColor = true;
            this.btnVerAsistentes.Click += new System.EventHandler(this.btnVerAsistentes_Click);
            // 
            // lblAsistentes
            // 
            this.lblAsistentes.AutoSize = true;
            this.lblAsistentes.Location = new System.Drawing.Point(13, 211);
            this.lblAsistentes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAsistentes.Name = "lblAsistentes";
            this.lblAsistentes.Size = new System.Drawing.Size(76, 16);
            this.lblAsistentes.TabIndex = 5;
            this.lblAsistentes.Text = "Asistentes: 0";
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
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(15, 84);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(148, 16);
            this.lblDescripcion.TabIndex = 3;
            this.lblDescripcion.Text = "Descripción del evento:";
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
            // lblLugar
            // 
            this.lblLugar.AutoSize = true;
            this.lblLugar.Location = new System.Drawing.Point(15, 52);
            this.lblLugar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLugar.Name = "lblLugar";
            this.lblLugar.Size = new System.Drawing.Size(45, 16);
            this.lblLugar.TabIndex = 9;
            this.lblLugar.Text = "Lugar:";
            // 
            // FrmDetalleEventoAdmin
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
            this.Name = "FrmDetalleEventoAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalle del Evento";
            this.Load += new System.EventHandler(this.FrmDetalleEventoAdmin_Load);
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
        private FontAwesome.Sharp.IconButton btnEliminarEvento;
        private System.Windows.Forms.Button btnVerAsistentes;
        private System.Windows.Forms.Label lblAsistentes;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblFechas;
        private System.Windows.Forms.Label lblLugar;
    }
}