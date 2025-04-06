namespace _GameStore.Presentacion
{
    partial class FormTienda
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
            txtIdTienda = new TextBox();
            label2 = new Label();
            txtNombreTienda = new TextBox();
            label3 = new Label();
            txtTelefono = new TextBox();
            label4 = new Label();
            txtDireccion = new TextBox();
            dgvTiendas = new DataGridView();
            btnConsultar = new Button();
            btnRegistrar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            btnSalir = new Button();
            btnActualizar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTiendas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 15);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 0;
            label1.Text = "Código Tienda";
            // 
            // txtIdTienda
            // 
            txtIdTienda.Location = new Point(19, 35);
            txtIdTienda.Margin = new Padding(4, 3, 4, 3);
            txtIdTienda.Name = "txtIdTienda";
            txtIdTienda.Size = new Size(205, 23);
            txtIdTienda.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(232, 15);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 2;
            label2.Text = "Nombre Tienda";
            // 
            // txtNombreTienda
            // 
            txtNombreTienda.Location = new Point(232, 35);
            txtNombreTienda.Margin = new Padding(4, 3, 4, 3);
            txtNombreTienda.Name = "txtNombreTienda";
            txtNombreTienda.Size = new Size(378, 23);
            txtNombreTienda.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(733, 10);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 4;
            label3.Text = "Teléfono";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(618, 35);
            txtTelefono.Margin = new Padding(4, 3, 4, 3);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(170, 23);
            txtTelefono.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 66);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 6;
            label4.Text = "Dirección";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(19, 85);
            txtDireccion.Margin = new Padding(4, 3, 4, 3);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(769, 23);
            txtDireccion.TabIndex = 7;
            // 
            // dgvTiendas
            // 
            dgvTiendas.AllowUserToAddRows = false;
            dgvTiendas.AllowUserToDeleteRows = false;
            dgvTiendas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTiendas.Location = new Point(15, 117);
            dgvTiendas.Margin = new Padding(4, 3, 4, 3);
            dgvTiendas.Name = "dgvTiendas";
            dgvTiendas.ReadOnly = true;
            dgvTiendas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTiendas.Size = new Size(775, 292);
            dgvTiendas.TabIndex = 8;
            dgvTiendas.CellDoubleClick += dgvTiendas_CellDoubleClick;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(15, 417);
            btnConsultar.Margin = new Padding(4, 3, 4, 3);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(88, 27);
            btnConsultar.TabIndex = 9;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(702, 417);
            btnRegistrar.Margin = new Padding(4, 3, 4, 3);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(88, 27);
            btnRegistrar.TabIndex = 10;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(348, 417);
            btnEliminar.Margin = new Padding(4, 3, 4, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(88, 27);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(15, 479);
            btnLimpiar.Margin = new Padding(4, 3, 4, 3);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(88, 27);
            btnLimpiar.TabIndex = 12;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(702, 479);
            btnSalir.Margin = new Padding(4, 3, 4, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(88, 27);
            btnSalir.TabIndex = 13;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(348, 479);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(88, 23);
            btnActualizar.TabIndex = 14;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // FormTienda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 519);
            Controls.Add(btnActualizar);
            Controls.Add(btnSalir);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnRegistrar);
            Controls.Add(btnConsultar);
            Controls.Add(dgvTiendas);
            Controls.Add(txtDireccion);
            Controls.Add(label4);
            Controls.Add(txtTelefono);
            Controls.Add(label3);
            Controls.Add(txtNombreTienda);
            Controls.Add(label2);
            Controls.Add(txtIdTienda);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FormTienda";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administrar Tiendas";
            Load += FormTienda_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTiendas).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdTienda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreTienda;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.DataGridView dgvTiendas;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;
    }
}