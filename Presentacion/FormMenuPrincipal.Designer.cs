namespace _45GAMES4U_Inventario.Presentacion
{
    partial class FormMenuPrincipal
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnTipoVideojuego = new System.Windows.Forms.Button();
            this.btnVideojuego = new System.Windows.Forms.Button();
            this.btnAdministrador = new System.Windows.Forms.Button();
            this.btnTienda = new System.Windows.Forms.Button();
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Menú Principal - 45GAMES4U";
            // 
            // btnTipoVideojuego
            // 
            this.btnTipoVideojuego.Location = new System.Drawing.Point(13, 30);
            this.btnTipoVideojuego.Name = "btnTipoVideojuego";
            this.btnTipoVideojuego.Size = new System.Drawing.Size(285, 23);
            this.btnTipoVideojuego.TabIndex = 1;
            this.btnTipoVideojuego.Text = "Gestionar Tipos de Videojuegos\n";
            this.btnTipoVideojuego.UseVisualStyleBackColor = true;
            // 
            // btnVideojuego
            // 
            this.btnVideojuego.Location = new System.Drawing.Point(12, 61);
            this.btnVideojuego.Name = "btnVideojuego";
            this.btnVideojuego.Size = new System.Drawing.Size(286, 23);
            this.btnVideojuego.TabIndex = 2;
            this.btnVideojuego.Text = "Gestionar Videojuegos\n";
            this.btnVideojuego.UseVisualStyleBackColor = true;
            // 
            // btnAdministrador
            // 
            this.btnAdministrador.Location = new System.Drawing.Point(13, 91);
            this.btnAdministrador.Name = "btnAdministrador";
            this.btnAdministrador.Size = new System.Drawing.Size(285, 23);
            this.btnAdministrador.TabIndex = 3;
            this.btnAdministrador.Text = "Gestionar Administradores\n";
            this.btnAdministrador.UseVisualStyleBackColor = true;
            // 
            // btnTienda
            // 
            this.btnTienda.Location = new System.Drawing.Point(13, 121);
            this.btnTienda.Name = "btnTienda";
            this.btnTienda.Size = new System.Drawing.Size(285, 23);
            this.btnTienda.TabIndex = 4;
            this.btnTienda.Text = "Gestionar Tiendas\n";
            this.btnTienda.UseVisualStyleBackColor = true;
            // 
            // btnCliente
            // 
            this.btnCliente.Location = new System.Drawing.Point(13, 151);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(285, 23);
            this.btnCliente.TabIndex = 5;
            this.btnCliente.Text = "Gestionar Clientes\n";
            this.btnCliente.UseVisualStyleBackColor = true;
            // 
            // btnInventario
            // 
            this.btnInventario.Location = new System.Drawing.Point(12, 181);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(286, 23);
            this.btnInventario.TabIndex = 6;
            this.btnInventario.Text = "Gestionar Inventario\n";
            this.btnInventario.UseVisualStyleBackColor = true;
           
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(117, 282);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            
            // 
            // FormMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 317);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnInventario);
            this.Controls.Add(this.btnCliente);
            this.Controls.Add(this.btnTienda);
            this.Controls.Add(this.btnAdministrador);
            this.Controls.Add(this.btnVideojuego);
            this.Controls.Add(this.btnTipoVideojuego);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú Principal - 45GAMES4U";
            this.Load += new System.EventHandler(this.FormMenuPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTipoVideojuego;
        private System.Windows.Forms.Button btnVideojuego;
        private System.Windows.Forms.Button btnAdministrador;
        private System.Windows.Forms.Button btnTienda;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnSalir;
    }
}