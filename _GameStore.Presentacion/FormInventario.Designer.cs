namespace _GameStore.Presentacion
{
    partial class FormInventario
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
            cmbTienda = new ComboBox();
            label3 = new Label();
            cmbVideojuego = new ComboBox();
            label4 = new Label();
            txtCantidad = new TextBox();
            dgvInventario = new DataGridView();
            btnConsultar = new Button();
            btnEliminar = new Button();
            btnRegistrar = new Button();
            btnLimpiar = new Button();
            btnSalir = new Button();
            btnActualizar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 15);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(125, 15);
            label1.TabIndex = 0;
            label1.Text = "Administrar Inventario\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 62);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(115, 15);
            label2.TabIndex = 1;
            label2.Text = "Seleccionar la tienda\n";
            // 
            // cmbTienda
            // 
            cmbTienda.FormattingEnabled = true;
            cmbTienda.Location = new Point(15, 82);
            cmbTienda.Margin = new Padding(4, 3, 4, 3);
            cmbTienda.Name = "cmbTienda";
            cmbTienda.Size = new Size(219, 23);
            cmbTienda.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(243, 62);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(141, 15);
            label3.TabIndex = 3;
            label3.Text = "Seleccionar el videojuego\n";
            // 
            // cmbVideojuego
            // 
            cmbVideojuego.FormattingEnabled = true;
            cmbVideojuego.Location = new Point(243, 82);
            cmbVideojuego.Margin = new Padding(4, 3, 4, 3);
            cmbVideojuego.Name = "cmbVideojuego";
            cmbVideojuego.Size = new Size(308, 23);
            cmbVideojuego.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(560, 62);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 5;
            label4.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(564, 82);
            txtCantidad.Margin = new Padding(4, 3, 4, 3);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(98, 23);
            txtCantidad.TabIndex = 6;
            // 
            // dgvInventario
            // 
            dgvInventario.AllowUserToAddRows = false;
            dgvInventario.AllowUserToDeleteRows = false;
            dgvInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventario.Location = new Point(14, 113);
            dgvInventario.Margin = new Padding(4, 3, 4, 3);
            dgvInventario.Name = "dgvInventario";
            dgvInventario.ReadOnly = true;
            dgvInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventario.Size = new Size(649, 278);
            dgvInventario.TabIndex = 7;
            dgvInventario.CellDoubleClick += dgvInventario_CellDoubleClick;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(14, 398);
            btnConsultar.Margin = new Padding(4, 3, 4, 3);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(88, 27);
            btnConsultar.TabIndex = 8;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(290, 479);
            btnEliminar.Margin = new Padding(4, 3, 4, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(88, 27);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(575, 398);
            btnRegistrar.Margin = new Padding(4, 3, 4, 3);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(88, 27);
            btnRegistrar.TabIndex = 10;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(14, 479);
            btnLimpiar.Margin = new Padding(4, 3, 4, 3);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(88, 27);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(575, 479);
            btnSalir.Margin = new Padding(4, 3, 4, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(88, 27);
            btnSalir.TabIndex = 12;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(290, 402);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(88, 23);
            btnActualizar.TabIndex = 13;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // FormInventario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(677, 519);
            Controls.Add(btnActualizar);
            Controls.Add(btnSalir);
            Controls.Add(btnLimpiar);
            Controls.Add(btnRegistrar);
            Controls.Add(btnEliminar);
            Controls.Add(btnConsultar);
            Controls.Add(dgvInventario);
            Controls.Add(txtCantidad);
            Controls.Add(label4);
            Controls.Add(cmbVideojuego);
            Controls.Add(label3);
            Controls.Add(cmbTienda);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FormInventario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administrar Inventario\n";
            Load += FormInventario_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTienda;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbVideojuego;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;
        private Button btnActualizar;
    }
}