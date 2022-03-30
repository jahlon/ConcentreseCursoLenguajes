namespace Concentrese.UI
{
    partial class VentanaPrincipalCliente
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
            this.panelAcciones = new System.Windows.Forms.Panel();
            this.buttonConectarAServidor = new System.Windows.Forms.Button();
            this.splitContainerAreaJuego = new System.Windows.Forms.SplitContainer();
            this.tablePanelTablero = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.labelTituloInfo = new System.Windows.Forms.Label();
            this.panelAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAreaJuego)).BeginInit();
            this.splitContainerAreaJuego.Panel1.SuspendLayout();
            this.splitContainerAreaJuego.Panel2.SuspendLayout();
            this.splitContainerAreaJuego.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAcciones
            // 
            this.panelAcciones.Controls.Add(this.buttonConectarAServidor);
            this.panelAcciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAcciones.Location = new System.Drawing.Point(0, 0);
            this.panelAcciones.Name = "panelAcciones";
            this.panelAcciones.Size = new System.Drawing.Size(1084, 48);
            this.panelAcciones.TabIndex = 0;
            // 
            // buttonConectarAServidor
            // 
            this.buttonConectarAServidor.Location = new System.Drawing.Point(12, 12);
            this.buttonConectarAServidor.Name = "buttonConectarAServidor";
            this.buttonConectarAServidor.Size = new System.Drawing.Size(152, 23);
            this.buttonConectarAServidor.TabIndex = 0;
            this.buttonConectarAServidor.Text = "Conectar a servidor";
            this.buttonConectarAServidor.UseVisualStyleBackColor = true;
            this.buttonConectarAServidor.Click += new System.EventHandler(this.buttonConectarAServidor_Click);
            // 
            // splitContainerAreaJuego
            // 
            this.splitContainerAreaJuego.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerAreaJuego.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerAreaJuego.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerAreaJuego.Location = new System.Drawing.Point(0, 48);
            this.splitContainerAreaJuego.Name = "splitContainerAreaJuego";
            // 
            // splitContainerAreaJuego.Panel1
            // 
            this.splitContainerAreaJuego.Panel1.Controls.Add(this.tablePanelTablero);
            this.splitContainerAreaJuego.Panel1MinSize = 800;
            // 
            // splitContainerAreaJuego.Panel2
            // 
            this.splitContainerAreaJuego.Panel2.Controls.Add(this.textBoxInfo);
            this.splitContainerAreaJuego.Panel2.Controls.Add(this.labelTituloInfo);
            this.splitContainerAreaJuego.Size = new System.Drawing.Size(1084, 506);
            this.splitContainerAreaJuego.SplitterDistance = 800;
            this.splitContainerAreaJuego.TabIndex = 1;
            // 
            // tablePanelTablero
            // 
            this.tablePanelTablero.ColumnCount = 6;
            this.tablePanelTablero.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tablePanelTablero.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tablePanelTablero.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tablePanelTablero.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tablePanelTablero.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tablePanelTablero.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tablePanelTablero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanelTablero.Location = new System.Drawing.Point(0, 0);
            this.tablePanelTablero.Name = "tablePanelTablero";
            this.tablePanelTablero.RowCount = 5;
            this.tablePanelTablero.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tablePanelTablero.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tablePanelTablero.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tablePanelTablero.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tablePanelTablero.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tablePanelTablero.Size = new System.Drawing.Size(798, 504);
            this.tablePanelTablero.TabIndex = 0;
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.BackColor = System.Drawing.Color.White;
            this.textBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxInfo.Location = new System.Drawing.Point(0, 26);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.ReadOnly = true;
            this.textBoxInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInfo.Size = new System.Drawing.Size(278, 478);
            this.textBoxInfo.TabIndex = 1;
            // 
            // labelTituloInfo
            // 
            this.labelTituloInfo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelTituloInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTituloInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTituloInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTituloInfo.Location = new System.Drawing.Point(0, 0);
            this.labelTituloInfo.Name = "labelTituloInfo";
            this.labelTituloInfo.Size = new System.Drawing.Size(278, 26);
            this.labelTituloInfo.TabIndex = 0;
            this.labelTituloInfo.Text = "Información";
            this.labelTituloInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VentanaPrincipalCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 554);
            this.Controls.Add(this.splitContainerAreaJuego);
            this.Controls.Add(this.panelAcciones);
            this.Name = "VentanaPrincipalCliente";
            this.Text = "VentanaPrincipalCliente";
            this.panelAcciones.ResumeLayout(false);
            this.splitContainerAreaJuego.Panel1.ResumeLayout(false);
            this.splitContainerAreaJuego.Panel2.ResumeLayout(false);
            this.splitContainerAreaJuego.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAreaJuego)).EndInit();
            this.splitContainerAreaJuego.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAcciones;
        private System.Windows.Forms.SplitContainer splitContainerAreaJuego;
        private System.Windows.Forms.Label labelTituloInfo;
        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.Button buttonConectarAServidor;
        private System.Windows.Forms.TableLayoutPanel tablePanelTablero;
    }
}