namespace SyCResidencias.Formularios
{
    partial class frmMENU
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.candidatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empresasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asesoresExternosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.residentesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirDelSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarAsesorInternoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusMensajes = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusFecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.candidatosToolStripMenuItem,
            this.empresasToolStripMenuItem,
            this.asesoresExternosToolStripMenuItem,
            this.asignarAsesorInternoToolStripMenuItem,
            this.residentesToolStripMenuItem,
            this.acercaDeToolStripMenuItem,
            this.salirDelSistemaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(970, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // candidatosToolStripMenuItem
            // 
            this.candidatosToolStripMenuItem.Image = global::SyCResidencias.Properties.Resources.bootloader_users_person_people_6080;
            this.candidatosToolStripMenuItem.Name = "candidatosToolStripMenuItem";
            this.candidatosToolStripMenuItem.Size = new System.Drawing.Size(116, 25);
            this.candidatosToolStripMenuItem.Text = "Candidatos";
            this.candidatosToolStripMenuItem.Click += new System.EventHandler(this.candidatosToolStripMenuItem_Click);
            // 
            // empresasToolStripMenuItem
            // 
            this.empresasToolStripMenuItem.Image = global::SyCResidencias.Properties.Resources._3986696_building_enterprise_icon_112275;
            this.empresasToolStripMenuItem.Name = "empresasToolStripMenuItem";
            this.empresasToolStripMenuItem.Size = new System.Drawing.Size(105, 25);
            this.empresasToolStripMenuItem.Text = "Empresas";
            this.empresasToolStripMenuItem.Click += new System.EventHandler(this.empresasToolStripMenuItem_Click);
            // 
            // asesoresExternosToolStripMenuItem
            // 
            this.asesoresExternosToolStripMenuItem.Image = global::SyCResidencias.Properties.Resources.tie;
            this.asesoresExternosToolStripMenuItem.Name = "asesoresExternosToolStripMenuItem";
            this.asesoresExternosToolStripMenuItem.Size = new System.Drawing.Size(163, 25);
            this.asesoresExternosToolStripMenuItem.Text = "Asesores Externos";
            this.asesoresExternosToolStripMenuItem.Click += new System.EventHandler(this.asesoresExternosToolStripMenuItem_Click);
            // 
            // residentesToolStripMenuItem
            // 
            this.residentesToolStripMenuItem.Image = global::SyCResidencias.Properties.Resources.school_students_icon_144607;
            this.residentesToolStripMenuItem.Name = "residentesToolStripMenuItem";
            this.residentesToolStripMenuItem.Size = new System.Drawing.Size(113, 25);
            this.residentesToolStripMenuItem.Text = "Residentes";
            this.residentesToolStripMenuItem.Click += new System.EventHandler(this.residentesToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Image = global::SyCResidencias.Properties.Resources.questionmark1_83827__1_;
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(109, 25);
            this.acercaDeToolStripMenuItem.Text = "Acerca de ";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // salirDelSistemaToolStripMenuItem
            // 
            this.salirDelSistemaToolStripMenuItem.Image = global::SyCResidencias.Properties.Resources.shutdown_105168;
            this.salirDelSistemaToolStripMenuItem.Name = "salirDelSistemaToolStripMenuItem";
            this.salirDelSistemaToolStripMenuItem.Size = new System.Drawing.Size(153, 25);
            this.salirDelSistemaToolStripMenuItem.Text = "Salir del Sistema";
            this.salirDelSistemaToolStripMenuItem.Click += new System.EventHandler(this.salirDelSistemaToolStripMenuItem_Click);
            // 
            // asignarAsesorInternoToolStripMenuItem
            // 
            this.asignarAsesorInternoToolStripMenuItem.Image = global::SyCResidencias.Properties.Resources.teacher;
            this.asignarAsesorInternoToolStripMenuItem.Name = "asignarAsesorInternoToolStripMenuItem";
            this.asignarAsesorInternoToolStripMenuItem.Size = new System.Drawing.Size(196, 25);
            this.asignarAsesorInternoToolStripMenuItem.Text = "Asignar Asesor Interno";
            this.asignarAsesorInternoToolStripMenuItem.Click += new System.EventHandler(this.asignarAsesorInternoToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusMensajes,
            this.toolStripStatusFecha,
            this.toolStripStatusHora});
            this.statusStrip1.Location = new System.Drawing.Point(0, 345);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(970, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusMensajes
            // 
            this.toolStripStatusMensajes.Name = "toolStripStatusMensajes";
            this.toolStripStatusMensajes.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusMensajes.Text = "Mensajes";
            this.toolStripStatusMensajes.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // toolStripStatusFecha
            // 
            this.toolStripStatusFecha.Name = "toolStripStatusFecha";
            this.toolStripStatusFecha.Size = new System.Drawing.Size(101, 17);
            this.toolStripStatusFecha.Text = "Fecha del Sistema";
            // 
            // toolStripStatusHora
            // 
            this.toolStripStatusHora.Name = "toolStripStatusHora";
            this.toolStripStatusHora.Size = new System.Drawing.Size(95, 17);
            this.toolStripStatusHora.Text = "Hora del sistema";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMENU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 367);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMENU";
            this.Text = "MENÚ PRINCIPAL - Coordinación de Proyectos de Vinculación";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMENU_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem candidatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empresasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem residentesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirDelSistemaToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusMensajes;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusFecha;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusHora;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem asesoresExternosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignarAsesorInternoToolStripMenuItem;
    }
}