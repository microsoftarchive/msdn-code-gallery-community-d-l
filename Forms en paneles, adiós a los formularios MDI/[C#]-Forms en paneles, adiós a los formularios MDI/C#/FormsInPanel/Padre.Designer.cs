namespace WindowsFormsApplication1
{
    partial class Padre
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btMostrarHijo1 = new System.Windows.Forms.Button();
            this.btMostrarHijo2 = new System.Windows.Forms.Button();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btMostrarHijo1
            // 
            this.btMostrarHijo1.Location = new System.Drawing.Point(12, 28);
            this.btMostrarHijo1.Name = "btMostrarHijo1";
            this.btMostrarHijo1.Size = new System.Drawing.Size(110, 32);
            this.btMostrarHijo1.TabIndex = 0;
            this.btMostrarHijo1.Text = "Mostrar Hijo 1";
            this.btMostrarHijo1.UseVisualStyleBackColor = true;
            this.btMostrarHijo1.Click += new System.EventHandler(this.btMostrarHijo1_Click);
            // 
            // btMostrarHijo2
            // 
            this.btMostrarHijo2.Location = new System.Drawing.Point(12, 66);
            this.btMostrarHijo2.Name = "btMostrarHijo2";
            this.btMostrarHijo2.Size = new System.Drawing.Size(110, 32);
            this.btMostrarHijo2.TabIndex = 1;
            this.btMostrarHijo2.Text = "Mostrar Hijo 2";
            this.btMostrarHijo2.UseVisualStyleBackColor = true;
            this.btMostrarHijo2.Click += new System.EventHandler(this.btMostrarHijo2_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.Location = new System.Drawing.Point(128, 28);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(358, 349);
            this.panelContenedor.TabIndex = 2;
            // 
            // Padre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 389);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.btMostrarHijo2);
            this.Controls.Add(this.btMostrarHijo1);
            this.Name = "Padre";
            this.Text = "Padre";            
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btMostrarHijo1;
        private System.Windows.Forms.Button btMostrarHijo2;
        private System.Windows.Forms.Panel panelContenedor;

    }
}

