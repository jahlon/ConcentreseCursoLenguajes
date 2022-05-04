namespace ServidorConcentrese
{
    partial class VentanaServidor
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.panelEstadisticas = new System.Windows.Forms.Panel();
            this.listBoxEstadisticas = new System.Windows.Forms.ListBox();
            this.panelBotonEstadisticas = new System.Windows.Forms.Panel();
            this.buttonRefrescarEstadisticas = new System.Windows.Forms.Button();
            this.labelEstadisticas = new System.Windows.Forms.Label();
            this.panelEncuentros = new System.Windows.Forms.Panel();
            this.listBoxEncuentros = new System.Windows.Forms.ListBox();
            this.panelBotonEncuentros = new System.Windows.Forms.Panel();
            this.buttonRefrescarEncuentros = new System.Windows.Forms.Button();
            this.labelEncuentros = new System.Windows.Forms.Label();
            this.tablePanel.SuspendLayout();
            this.panelEstadisticas.SuspendLayout();
            this.panelBotonEstadisticas.SuspendLayout();
            this.panelEncuentros.SuspendLayout();
            this.panelBotonEncuentros.SuspendLayout();
            this.SuspendLayout();
            // 
            // tablePanel
            // 
            this.tablePanel.ColumnCount = 1;
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanel.Controls.Add(this.panelEstadisticas, 0, 1);
            this.tablePanel.Controls.Add(this.panelEncuentros, 0, 0);
            this.tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel.Location = new System.Drawing.Point(0, 0);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.RowCount = 2;
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanel.Size = new System.Drawing.Size(539, 461);
            this.tablePanel.TabIndex = 0;
            // 
            // panelEstadisticas
            // 
            this.panelEstadisticas.Controls.Add(this.listBoxEstadisticas);
            this.panelEstadisticas.Controls.Add(this.panelBotonEstadisticas);
            this.panelEstadisticas.Controls.Add(this.labelEstadisticas);
            this.panelEstadisticas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEstadisticas.Location = new System.Drawing.Point(3, 233);
            this.panelEstadisticas.Name = "panelEstadisticas";
            this.panelEstadisticas.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelEstadisticas.Size = new System.Drawing.Size(533, 225);
            this.panelEstadisticas.TabIndex = 1;
            // 
            // listBoxEstadisticas
            // 
            this.listBoxEstadisticas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxEstadisticas.FormattingEnabled = true;
            this.listBoxEstadisticas.Location = new System.Drawing.Point(5, 28);
            this.listBoxEstadisticas.Name = "listBoxEstadisticas";
            this.listBoxEstadisticas.Size = new System.Drawing.Size(523, 154);
            this.listBoxEstadisticas.TabIndex = 2;
            // 
            // panelBotonEstadisticas
            // 
            this.panelBotonEstadisticas.Controls.Add(this.buttonRefrescarEstadisticas);
            this.panelBotonEstadisticas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotonEstadisticas.Location = new System.Drawing.Point(5, 182);
            this.panelBotonEstadisticas.Name = "panelBotonEstadisticas";
            this.panelBotonEstadisticas.Size = new System.Drawing.Size(523, 38);
            this.panelBotonEstadisticas.TabIndex = 1;
            // 
            // buttonRefrescarEstadisticas
            // 
            this.buttonRefrescarEstadisticas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRefrescarEstadisticas.Location = new System.Drawing.Point(218, 7);
            this.buttonRefrescarEstadisticas.Name = "buttonRefrescarEstadisticas";
            this.buttonRefrescarEstadisticas.Size = new System.Drawing.Size(85, 23);
            this.buttonRefrescarEstadisticas.TabIndex = 0;
            this.buttonRefrescarEstadisticas.Text = "Refrescar";
            this.buttonRefrescarEstadisticas.UseVisualStyleBackColor = true;
            this.buttonRefrescarEstadisticas.Click += new System.EventHandler(this.buttonRefrescarEstadisticas_Click);
            // 
            // labelEstadisticas
            // 
            this.labelEstadisticas.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelEstadisticas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstadisticas.Location = new System.Drawing.Point(5, 5);
            this.labelEstadisticas.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.labelEstadisticas.Name = "labelEstadisticas";
            this.labelEstadisticas.Size = new System.Drawing.Size(523, 23);
            this.labelEstadisticas.TabIndex = 0;
            this.labelEstadisticas.Text = "Estadísticas de los jugadores";
            this.labelEstadisticas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelEncuentros
            // 
            this.panelEncuentros.Controls.Add(this.listBoxEncuentros);
            this.panelEncuentros.Controls.Add(this.panelBotonEncuentros);
            this.panelEncuentros.Controls.Add(this.labelEncuentros);
            this.panelEncuentros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEncuentros.Location = new System.Drawing.Point(3, 3);
            this.panelEncuentros.Name = "panelEncuentros";
            this.panelEncuentros.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelEncuentros.Size = new System.Drawing.Size(533, 224);
            this.panelEncuentros.TabIndex = 2;
            // 
            // listBoxEncuentros
            // 
            this.listBoxEncuentros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxEncuentros.FormattingEnabled = true;
            this.listBoxEncuentros.Location = new System.Drawing.Point(5, 29);
            this.listBoxEncuentros.Name = "listBoxEncuentros";
            this.listBoxEncuentros.Size = new System.Drawing.Size(523, 154);
            this.listBoxEncuentros.TabIndex = 3;
            // 
            // panelBotonEncuentros
            // 
            this.panelBotonEncuentros.Controls.Add(this.buttonRefrescarEncuentros);
            this.panelBotonEncuentros.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotonEncuentros.Location = new System.Drawing.Point(5, 183);
            this.panelBotonEncuentros.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.panelBotonEncuentros.Name = "panelBotonEncuentros";
            this.panelBotonEncuentros.Size = new System.Drawing.Size(523, 36);
            this.panelBotonEncuentros.TabIndex = 2;
            // 
            // buttonRefrescarEncuentros
            // 
            this.buttonRefrescarEncuentros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRefrescarEncuentros.Location = new System.Drawing.Point(218, 7);
            this.buttonRefrescarEncuentros.Name = "buttonRefrescarEncuentros";
            this.buttonRefrescarEncuentros.Size = new System.Drawing.Size(85, 23);
            this.buttonRefrescarEncuentros.TabIndex = 0;
            this.buttonRefrescarEncuentros.Text = "Refrescar";
            this.buttonRefrescarEncuentros.UseVisualStyleBackColor = true;
            this.buttonRefrescarEncuentros.Click += new System.EventHandler(this.buttonRefrescarEncuentros_Click);
            // 
            // labelEncuentros
            // 
            this.labelEncuentros.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelEncuentros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEncuentros.Location = new System.Drawing.Point(5, 5);
            this.labelEncuentros.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.labelEncuentros.Name = "labelEncuentros";
            this.labelEncuentros.Size = new System.Drawing.Size(523, 24);
            this.labelEncuentros.TabIndex = 0;
            this.labelEncuentros.Text = "Encuentros";
            this.labelEncuentros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VentanaServidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 461);
            this.Controls.Add(this.tablePanel);
            this.MinimumSize = new System.Drawing.Size(500, 499);
            this.Name = "VentanaServidor";
            this.Text = "Servidor Concéntrese";
            this.tablePanel.ResumeLayout(false);
            this.panelEstadisticas.ResumeLayout(false);
            this.panelBotonEstadisticas.ResumeLayout(false);
            this.panelEncuentros.ResumeLayout(false);
            this.panelBotonEncuentros.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tablePanel;
        private System.Windows.Forms.Panel panelEstadisticas;
        private System.Windows.Forms.Panel panelEncuentros;
        private System.Windows.Forms.Panel panelBotonEncuentros;
        private System.Windows.Forms.Label labelEncuentros;
        private System.Windows.Forms.Button buttonRefrescarEncuentros;
        private System.Windows.Forms.ListBox listBoxEstadisticas;
        private System.Windows.Forms.Panel panelBotonEstadisticas;
        private System.Windows.Forms.Button buttonRefrescarEstadisticas;
        private System.Windows.Forms.Label labelEstadisticas;
        private System.Windows.Forms.ListBox listBoxEncuentros;
    }
}

