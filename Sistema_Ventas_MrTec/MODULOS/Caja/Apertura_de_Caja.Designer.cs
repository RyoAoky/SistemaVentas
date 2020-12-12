
namespace Sistema_Ventas_MrTec.MODULOS.Caja
{
    partial class Apertura_de_Caja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Apertura_de_Caja));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Label2 = new System.Windows.Forms.Label();
            this.Button1 = new System.Windows.Forms.Button();
            this.txtfecha = new System.Windows.Forms.DateTimePicker();
            this.txtip = new System.Windows.Forms.Label();
            this.txtmonto = new System.Windows.Forms.TextBox();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnIniciar_Apertura = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOmitir_Apertura = new System.Windows.Forms.ToolStripMenuItem();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.datalistado_caja = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblSerialPc = new System.Windows.Forms.Label();
            this.txtidcaja = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datalistado_caja)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.Add(this.panel4);
            this.Panel1.Controls.Add(this.Panel2);
            this.Panel1.Controls.Add(this.txtmonto);
            this.Panel1.Controls.Add(this.MenuStrip1);
            this.Panel1.Controls.Add(this.Label9);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Location = new System.Drawing.Point(180, 163);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(402, 234);
            this.Panel1.TabIndex = 567;
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.White;
            this.Panel2.Controls.Add(this.Label2);
            this.Panel2.Controls.Add(this.Button1);
            this.Panel2.Controls.Add(this.txtfecha);
            this.Panel2.Controls.Add(this.txtip);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(0, 0);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(402, 60);
            this.Panel2.TabIndex = 565;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(0, 0);
            this.Label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(402, 60);
            this.Label2.TabIndex = 532;
            this.Label2.Text = "Dinero en Caja";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Button1
            // 
            this.Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(197)))), ((int)(((byte)(76)))));
            this.Button1.FlatAppearance.BorderSize = 0;
            this.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.ForeColor = System.Drawing.Color.White;
            this.Button1.Location = new System.Drawing.Point(372, 3);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(27, 32);
            this.Button1.TabIndex = 540;
            this.Button1.Text = "X";
            this.Button1.UseVisualStyleBackColor = false;
            // 
            // txtfecha
            // 
            this.txtfecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtfecha.Location = new System.Drawing.Point(137, 6);
            this.txtfecha.Name = "txtfecha";
            this.txtfecha.Size = new System.Drawing.Size(74, 20);
            this.txtfecha.TabIndex = 566;
            // 
            // txtip
            // 
            this.txtip.AutoSize = true;
            this.txtip.BackColor = System.Drawing.Color.Transparent;
            this.txtip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtip.ForeColor = System.Drawing.Color.White;
            this.txtip.Location = new System.Drawing.Point(90, 38);
            this.txtip.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.txtip.Name = "txtip";
            this.txtip.Size = new System.Drawing.Size(90, 13);
            this.txtip.TabIndex = 527;
            this.txtip.Text = "tu nomvbre de pc";
            // 
            // txtmonto
            // 
            this.txtmonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtmonto.Location = new System.Drawing.Point(45, 131);
            this.txtmonto.Name = "txtmonto";
            this.txtmonto.Size = new System.Drawing.Size(284, 30);
            this.txtmonto.TabIndex = 564;
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.AutoSize = false;
            this.MenuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnIniciar_Apertura,
            this.btnOmitir_Apertura});
            this.MenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MenuStrip1.Location = new System.Drawing.Point(45, 164);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.ShowItemToolTips = true;
            this.MenuStrip1.Size = new System.Drawing.Size(216, 43);
            this.MenuStrip1.TabIndex = 562;
            this.MenuStrip1.Text = "MenuStrip7";
            // 
            // btnIniciar_Apertura
            // 
            this.btnIniciar_Apertura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(63)))), ((int)(((byte)(67)))));
            this.btnIniciar_Apertura.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnIniciar_Apertura.ForeColor = System.Drawing.Color.White;
            this.btnIniciar_Apertura.Name = "btnIniciar_Apertura";
            this.btnIniciar_Apertura.Size = new System.Drawing.Size(70, 39);
            this.btnIniciar_Apertura.Text = "Iniciar";
            this.btnIniciar_Apertura.ToolTipText = "Iniciar";
            this.btnIniciar_Apertura.Click += new System.EventHandler(this.btnIniciar_Apertura_Click);
            // 
            // btnOmitir_Apertura
            // 
            this.btnOmitir_Apertura.BackColor = System.Drawing.Color.White;
            this.btnOmitir_Apertura.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnOmitir_Apertura.ForeColor = System.Drawing.Color.Black;
            this.btnOmitir_Apertura.Name = "btnOmitir_Apertura";
            this.btnOmitir_Apertura.Size = new System.Drawing.Size(71, 39);
            this.btnOmitir_Apertura.Text = "Omitir";
            this.btnOmitir_Apertura.ToolTipText = "Omitir";
            this.btnOmitir_Apertura.Click += new System.EventHandler(this.btnOmitir_Apertura_Click);
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.BackColor = System.Drawing.Color.Transparent;
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(12, 75);
            this.Label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(0, 13);
            this.Label9.TabIndex = 533;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(27, 95);
            this.Label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(317, 31);
            this.Label1.TabIndex = 511;
            this.Label1.Text = "¿Efectivo inicial en Caja?";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(143)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 157);
            this.panel3.TabIndex = 568;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.datalistado_caja);
            this.panel4.Controls.Add(this.lblSerialPc);
            this.panel4.Controls.Add(this.txtidcaja);
            this.panel4.Location = new System.Drawing.Point(389, 151);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 10);
            this.panel4.TabIndex = 569;
            // 
            // datalistado_caja
            // 
            this.datalistado_caja.AllowUserToAddRows = false;
            this.datalistado_caja.AllowUserToResizeRows = false;
            this.datalistado_caja.BackgroundColor = System.Drawing.Color.White;
            this.datalistado_caja.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datalistado_caja.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.datalistado_caja.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.datalistado_caja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datalistado_caja.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn2});
            this.datalistado_caja.EnableHeadersVisualStyles = false;
            this.datalistado_caja.Location = new System.Drawing.Point(120, 106);
            this.datalistado_caja.Name = "datalistado_caja";
            this.datalistado_caja.ReadOnly = true;
            this.datalistado_caja.RowHeadersVisible = false;
            this.datalistado_caja.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datalistado_caja.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.datalistado_caja.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.datalistado_caja.RowTemplate.Height = 30;
            this.datalistado_caja.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datalistado_caja.Size = new System.Drawing.Size(246, 38);
            this.datalistado_caja.TabIndex = 623;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn2.Image")));
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            // 
            // lblSerialPc
            // 
            this.lblSerialPc.AutoSize = true;
            this.lblSerialPc.Location = new System.Drawing.Point(298, 85);
            this.lblSerialPc.Name = "lblSerialPc";
            this.lblSerialPc.Size = new System.Drawing.Size(35, 13);
            this.lblSerialPc.TabIndex = 621;
            this.lblSerialPc.Text = "label3";
            // 
            // txtidcaja
            // 
            this.txtidcaja.AutoSize = true;
            this.txtidcaja.Location = new System.Drawing.Point(184, 80);
            this.txtidcaja.Name = "txtidcaja";
            this.txtidcaja.Size = new System.Drawing.Size(35, 13);
            this.txtidcaja.TabIndex = 622;
            this.txtidcaja.Text = "label3";
            // 
            // Apertura_de_Caja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Apertura_de_Caja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apertura_de_Caja";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.Load += new System.EventHandler(this.Apertura_de_Caja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datalistado_caja)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.DateTimePicker txtfecha;
        internal System.Windows.Forms.Label txtip;
        internal System.Windows.Forms.TextBox txtmonto;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem btnIniciar_Apertura;
        internal System.Windows.Forms.ToolStripMenuItem btnOmitir_Apertura;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView datalistado_caja;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.Label lblSerialPc;
        private System.Windows.Forms.Label txtidcaja;
    }
}