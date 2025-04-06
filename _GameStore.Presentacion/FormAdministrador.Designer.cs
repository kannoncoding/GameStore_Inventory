namespace _GameStore.Presentacion
{
    partial class FormAdministrador
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
            labeladminid = new Label();
            txtIdAdministrador = new TextBox();
            labelnombre = new Label();
            txtNombre = new TextBox();
            label1 = new Label();
            txtTelefono = new TextBox();
            label2 = new Label();
            txtCorreo = new TextBox();
            label3 = new Label();
            cmbTienda = new ComboBox();
            dgvAdministradores = new DataGridView();
            btnConsultar = new Button();
            btnRegistrar = new Button();
            btnLimpiar = new Button();
            btnSalir = new Button();
            btnEliminar = new Button();
            label4 = new Label();
            txtApellido = new TextBox();
            btnActualizar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAdministradores).BeginInit();
            SuspendLayout();
            // 
            // labeladminid
            // 
            labeladminid.AutoSize = true;
            labeladminid.Location = new Point(15, 15);
            labeladminid.Margin = new Padding(4, 0, 4, 0);
            labeladminid.Name = "labeladminid";
            labeladminid.Size = new Size(97, 15);
            labeladminid.TabIndex = 0;
            labeladminid.Text = "ID Administrador";
            // 
            // txtIdAdministrador
            // 
            txtIdAdministrador.Location = new Point(19, 35);
            txtIdAdministrador.Margin = new Padding(4, 3, 4, 3);
            txtIdAdministrador.Name = "txtIdAdministrador";
            txtIdAdministrador.Size = new Size(179, 23);
            txtIdAdministrador.TabIndex = 1;
            // 
            // labelnombre
            // 
            labelnombre.AutoSize = true;
            labelnombre.Location = new Point(206, 15);
            labelnombre.Margin = new Padding(4, 0, 4, 0);
            labelnombre.Name = "labelnombre";
            labelnombre.Size = new Size(51, 15);
            labelnombre.TabIndex = 2;
            labelnombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(210, 35);
            txtNombre.Margin = new Padding(4, 3, 4, 3);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(176, 23);
            txtNombre.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(723, 15);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 4;
            label1.Text = "Teléfono";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(618, 35);
            txtTelefono.Margin = new Padding(4, 3, 4, 3);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(160, 23);
            txtTelefono.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 66);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 6;
            label2.Text = "Correo Electrónico";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(19, 85);
            txtCorreo.Margin = new Padding(4, 3, 4, 3);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(367, 23);
            txtCorreo.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(679, 66);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(95, 15);
            label3.TabIndex = 8;
            label3.Text = "Tienda Asignada\t";
            // 
            // cmbTienda
            // 
            cmbTienda.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTienda.FormattingEnabled = true;
            cmbTienda.Location = new Point(393, 85);
            cmbTienda.Margin = new Padding(4, 3, 4, 3);
            cmbTienda.Name = "cmbTienda";
            cmbTienda.Size = new Size(384, 23);
            cmbTienda.TabIndex = 9;
            // 
            // dgvAdministradores
            // 
            dgvAdministradores.AllowUserToAddRows = false;
            dgvAdministradores.AllowUserToDeleteRows = false;
            dgvAdministradores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAdministradores.Location = new Point(15, 117);
            dgvAdministradores.Margin = new Padding(4, 3, 4, 3);
            dgvAdministradores.Name = "dgvAdministradores";
            dgvAdministradores.ReadOnly = true;
            dgvAdministradores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdministradores.Size = new Size(764, 279);
            dgvAdministradores.TabIndex = 10;
            dgvAdministradores.CellDoubleClick += dgvAdministradores_CellDoubleClick;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(15, 404);
            btnConsultar.Margin = new Padding(4, 3, 4, 3);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(88, 27);
            btnConsultar.TabIndex = 11;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(693, 404);
            btnRegistrar.Margin = new Padding(4, 3, 4, 3);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(88, 27);
            btnRegistrar.TabIndex = 13;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(15, 527);
            btnLimpiar.Margin = new Padding(4, 3, 4, 3);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(88, 27);
            btnLimpiar.TabIndex = 14;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(693, 527);
            btnSalir.Margin = new Padding(4, 3, 4, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(88, 27);
            btnSalir.TabIndex = 15;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(354, 527);
            btnEliminar.Margin = new Padding(4, 3, 4, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(88, 27);
            btnEliminar.TabIndex = 16;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(394, 15);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 17;
            label4.Text = "Apellido";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(394, 35);
            txtApellido.Margin = new Padding(4, 3, 4, 3);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(216, 23);
            txtApellido.TabIndex = 18;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(354, 408);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(88, 23);
            btnActualizar.TabIndex = 19;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // FormAdministrador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 568);
            Controls.Add(btnActualizar);
            Controls.Add(txtApellido);
            Controls.Add(label4);
            Controls.Add(btnEliminar);
            Controls.Add(btnSalir);
            Controls.Add(btnLimpiar);
            Controls.Add(btnRegistrar);
            Controls.Add(btnConsultar);
            Controls.Add(dgvAdministradores);
            Controls.Add(cmbTienda);
            Controls.Add(label3);
            Controls.Add(txtCorreo);
            Controls.Add(label2);
            Controls.Add(txtTelefono);
            Controls.Add(label1);
            Controls.Add(txtNombre);
            Controls.Add(labelnombre);
            Controls.Add(txtIdAdministrador);
            Controls.Add(labeladminid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FormAdministrador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administrar Administradores\n";
            Load += FormAdministrador_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAdministradores).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labeladminid;
        private System.Windows.Forms.TextBox txtIdAdministrador;
        private System.Windows.Forms.Label labelnombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTienda;
        private System.Windows.Forms.DataGridView dgvAdministradores;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtApellido;
    }
}