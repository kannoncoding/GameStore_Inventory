namespace _GameStore.Presentacion
{
    partial class FormVideojuego
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtIdVideojuego = new TextBox();
            txtNombre = new TextBox();
            label3 = new Label();
            cmbTipoVideojuego = new ComboBox();
            label4 = new Label();
            txtPlataforma = new TextBox();
            label5 = new Label();
            txtPrecio = new TextBox();
            label6 = new Label();
            btnConsultar = new Button();
            btnRegistrar = new Button();
            dgvVideojuegos = new DataGridView();
            btnLimpiar = new Button();
            btnSalir = new Button();
            cmbClasificacionEdad = new ComboBox();
            label7 = new Label();
            txtDescripcion = new TextBox();
            btnActualizar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvVideojuegos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 10);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(128, 15);
            label1.TabIndex = 0;
            label1.Text = "Código del Videojuego";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(215, 10);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(133, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre del Videojuego";
            // 
            // txtIdVideojuego
            // 
            txtIdVideojuego.Location = new Point(18, 29);
            txtIdVideojuego.Margin = new Padding(4, 3, 4, 3);
            txtIdVideojuego.Name = "txtIdVideojuego";
            txtIdVideojuego.Size = new Size(190, 23);
            txtIdVideojuego.TabIndex = 2;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(215, 28);
            txtNombre.Margin = new Padding(4, 3, 4, 3);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(475, 23);
            txtNombre.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(804, 10);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(110, 15);
            label3.TabIndex = 4;
            label3.Text = "Tipo de Videojuego";
            // 
            // cmbTipoVideojuego
            // 
            cmbTipoVideojuego.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoVideojuego.FormattingEnabled = true;
            cmbTipoVideojuego.Location = new Point(698, 27);
            cmbTipoVideojuego.Margin = new Padding(4, 3, 4, 3);
            cmbTipoVideojuego.Name = "cmbTipoVideojuego";
            cmbTipoVideojuego.Size = new Size(220, 23);
            cmbTipoVideojuego.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 60);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 6;
            label4.Text = "Plataforma";
            // 
            // txtPlataforma
            // 
            txtPlataforma.Location = new Point(18, 80);
            txtPlataforma.Margin = new Padding(4, 3, 4, 3);
            txtPlataforma.Name = "txtPlataforma";
            txtPlataforma.Size = new Size(190, 23);
            txtPlataforma.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 106);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 8;
            label5.Text = "Precio";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(15, 125);
            txtPrecio.Margin = new Padding(4, 3, 4, 3);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(231, 23);
            txtPrecio.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(785, 60);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(124, 15);
            label6.TabIndex = 10;
            label6.Text = "Clasificacion por Edad";
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(14, 164);
            btnConsultar.Margin = new Padding(4, 3, 4, 3);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(88, 27);
            btnConsultar.TabIndex = 12;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(832, 164);
            btnRegistrar.Margin = new Padding(4, 3, 4, 3);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(88, 27);
            btnRegistrar.TabIndex = 13;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // dgvVideojuegos
            // 
            dgvVideojuegos.AllowUserToAddRows = false;
            dgvVideojuegos.AllowUserToDeleteRows = false;
            dgvVideojuegos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVideojuegos.Location = new Point(15, 197);
            dgvVideojuegos.Margin = new Padding(4, 3, 4, 3);
            dgvVideojuegos.Name = "dgvVideojuegos";
            dgvVideojuegos.ReadOnly = true;
            dgvVideojuegos.Size = new Size(902, 365);
            dgvVideojuegos.TabIndex = 14;
            dgvVideojuegos.CellDoubleClick += dgvVideojuegos_CellDoubleClick;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(15, 614);
            btnLimpiar.Margin = new Padding(4, 3, 4, 3);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(88, 27);
            btnLimpiar.TabIndex = 15;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(831, 613);
            btnSalir.Margin = new Padding(4, 3, 4, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(88, 27);
            btnSalir.TabIndex = 16;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // cmbClasificacionEdad
            // 
            cmbClasificacionEdad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClasificacionEdad.FormattingEnabled = true;
            cmbClasificacionEdad.Location = new Point(774, 77);
            cmbClasificacionEdad.Margin = new Padding(4, 3, 4, 3);
            cmbClasificacionEdad.Name = "cmbClasificacionEdad";
            cmbClasificacionEdad.Size = new Size(140, 23);
            cmbClasificacionEdad.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(254, 60);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(69, 15);
            label7.TabIndex = 18;
            label7.Text = "Descripcion";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(258, 77);
            txtDescripcion.Margin = new Padding(4, 3, 4, 3);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(508, 70);
            txtDescripcion.TabIndex = 19;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(403, 164);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 20;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(403, 613);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 21;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // FormVideojuego
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 654);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(txtDescripcion);
            Controls.Add(label7);
            Controls.Add(cmbClasificacionEdad);
            Controls.Add(btnSalir);
            Controls.Add(btnLimpiar);
            Controls.Add(dgvVideojuegos);
            Controls.Add(btnRegistrar);
            Controls.Add(btnConsultar);
            Controls.Add(label6);
            Controls.Add(txtPrecio);
            Controls.Add(label5);
            Controls.Add(txtPlataforma);
            Controls.Add(label4);
            Controls.Add(cmbTipoVideojuego);
            Controls.Add(label3);
            Controls.Add(txtNombre);
            Controls.Add(txtIdVideojuego);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FormVideojuego";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administrar Videojuegos";
            Load += FormVideojuego_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVideojuegos).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdVideojuego;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTipoVideojuego;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPlataforma;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvVideojuegos;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ComboBox cmbClasificacionEdad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescripcion;
    }
}