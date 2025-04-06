namespace _GameStore.Presentacion
{
    partial class FormTipoVideojuego
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
            txtCodigoTipo = new TextBox();
            label2 = new Label();
            txtDescripcion = new TextBox();
            btnConsultar = new Button();
            btnRegistrar = new Button();
            btnLimpiar = new Button();
            btnSalir = new Button();
            btnEliminar = new Button();
            dgvTiposVideojuego = new DataGridView();
            label3 = new Label();
            txtNombreTipo = new TextBox();
            btnActualizar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTiposVideojuego).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 61);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(152, 15);
            label1.TabIndex = 0;
            label1.Text = "Código Tipo de Videojuego";
            // 
            // txtCodigoTipo
            // 
            txtCodigoTipo.CausesValidation = false;
            txtCodigoTipo.Location = new Point(14, 80);
            txtCodigoTipo.Margin = new Padding(4, 3, 4, 3);
            txtCodigoTipo.Name = "txtCodigoTipo";
            txtCodigoTipo.Size = new Size(350, 23);
            txtCodigoTipo.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 106);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(115, 15);
            label2.TabIndex = 2;
            label2.Text = "Descripción del Tipo";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(14, 125);
            txtDescripcion.Margin = new Padding(4, 3, 4, 3);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(354, 43);
            txtDescripcion.TabIndex = 3;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(14, 565);
            btnConsultar.Margin = new Padding(4, 3, 4, 3);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(88, 27);
            btnConsultar.TabIndex = 4;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(584, 565);
            btnRegistrar.Margin = new Padding(4, 3, 4, 3);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(88, 27);
            btnRegistrar.TabIndex = 5;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(14, 676);
            btnLimpiar.Margin = new Padding(4, 3, 4, 3);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(88, 27);
            btnLimpiar.TabIndex = 6;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(584, 676);
            btnSalir.Margin = new Padding(4, 3, 4, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(88, 27);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(293, 676);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvTiposVideojuego
            // 
            dgvTiposVideojuego.AllowUserToAddRows = false;
            dgvTiposVideojuego.AllowUserToDeleteRows = false;
            dgvTiposVideojuego.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTiposVideojuego.Location = new Point(14, 175);
            dgvTiposVideojuego.Margin = new Padding(4, 3, 4, 3);
            dgvTiposVideojuego.Name = "dgvTiposVideojuego";
            dgvTiposVideojuego.ReadOnly = true;
            dgvTiposVideojuego.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTiposVideojuego.Size = new Size(658, 383);
            dgvTiposVideojuego.TabIndex = 8;
            dgvTiposVideojuego.CellDoubleClick += dgvTiposVideojuego_CellDoubleClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 15);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(176, 15);
            label3.TabIndex = 9;
            label3.Text = "Nombre del Tipo de Videojuego";
            // 
            // txtNombreTipo
            // 
            txtNombreTipo.Location = new Point(14, 35);
            txtNombreTipo.Margin = new Padding(4, 3, 4, 3);
            txtNombreTipo.Name = "txtNombreTipo";
            txtNombreTipo.Size = new Size(354, 23);
            txtNombreTipo.TabIndex = 10;
            txtNombreTipo.Enter += FormTipoVideojuego_Load;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(293, 567);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 12;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // FormTipoVideojuego
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 717);
            Controls.Add(btnActualizar);
            Controls.Add(btnEliminar);
            Controls.Add(txtNombreTipo);
            Controls.Add(label3);
            Controls.Add(dgvTiposVideojuego);
            Controls.Add(btnSalir);
            Controls.Add(btnLimpiar);
            Controls.Add(btnRegistrar);
            Controls.Add(btnConsultar);
            Controls.Add(txtDescripcion);
            Controls.Add(label2);
            Controls.Add(txtCodigoTipo);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FormTipoVideojuego";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administrar Tipos de Videojuegos\n";
            Activated += FormTipoVideojuego_Load;
            Load += FormTipoVideojuego_Load;
            Enter += FormTipoVideojuego_Load;
            Validated += FormTipoVideojuego_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTiposVideojuego).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigoTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvTiposVideojuego;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombreTipo;
        
    }
}