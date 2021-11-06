
namespace UI.Desktop
{
    partial class Main
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.linklblInscripcion = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuModificarDatos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMaterias = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuComisiones = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPlanes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEspecialidades = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInscripcionesAlumnos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInscripcionesDocentes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPermisos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(152, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "¡Bienvenido!";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(166, 106);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(65, 18);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "nombre";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.Location = new System.Drawing.Point(231, 106);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(67, 18);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido";
            // 
            // linklblInscripcion
            // 
            this.linklblInscripcion.AutoSize = true;
            this.linklblInscripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblInscripcion.Location = new System.Drawing.Point(183, 162);
            this.linklblInscripcion.Name = "linklblInscripcion";
            this.linklblInscripcion.Size = new System.Drawing.Size(82, 13);
            this.linklblInscripcion.TabIndex = 3;
            this.linklblInscripcion.TabStop = true;
            this.linklblInscripcion.Text = "Inscripciones";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(183, 198);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(96, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Modificar Datos";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.consultaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(1);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(460, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuModificarDatos,
            this.mnuSalir});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // mnuModificarDatos
            // 
            this.mnuModificarDatos.Name = "mnuModificarDatos";
            this.mnuModificarDatos.Size = new System.Drawing.Size(180, 22);
            this.mnuModificarDatos.Text = "Modificar Datos";
            // 
            // mnuSalir
            // 
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(180, 22);
            this.mnuSalir.Text = "Salir";
            // 
            // consultaToolStripMenuItem
            // 
            this.consultaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUsuarios,
            this.mnuCursos,
            this.mnuMaterias,
            this.mnuComisiones,
            this.mnuPlanes,
            this.mnuEspecialidades,
            this.mnuInscripcionesAlumnos,
            this.mnuInscripcionesDocentes,
            this.mnuPermisos,
            this.mnuReportes});
            this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
            this.consultaToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.consultaToolStripMenuItem.Text = "Consulta";
            // 
            // mnuUsuarios
            // 
            this.mnuUsuarios.Name = "mnuUsuarios";
            this.mnuUsuarios.Size = new System.Drawing.Size(202, 22);
            this.mnuUsuarios.Text = "Usuarios";
            // 
            // mnuCursos
            // 
            this.mnuCursos.Name = "mnuCursos";
            this.mnuCursos.Size = new System.Drawing.Size(202, 22);
            this.mnuCursos.Text = "Cursos";
            // 
            // mnuMaterias
            // 
            this.mnuMaterias.Name = "mnuMaterias";
            this.mnuMaterias.Size = new System.Drawing.Size(202, 22);
            this.mnuMaterias.Text = "Materias";
            // 
            // mnuComisiones
            // 
            this.mnuComisiones.Name = "mnuComisiones";
            this.mnuComisiones.Size = new System.Drawing.Size(202, 22);
            this.mnuComisiones.Text = "Comisiones";
            // 
            // mnuPlanes
            // 
            this.mnuPlanes.Name = "mnuPlanes";
            this.mnuPlanes.Size = new System.Drawing.Size(202, 22);
            this.mnuPlanes.Text = "Planes";
            // 
            // mnuEspecialidades
            // 
            this.mnuEspecialidades.Name = "mnuEspecialidades";
            this.mnuEspecialidades.Size = new System.Drawing.Size(202, 22);
            this.mnuEspecialidades.Text = "Especialidades";
            // 
            // mnuInscripcionesAlumnos
            // 
            this.mnuInscripcionesAlumnos.Name = "mnuInscripcionesAlumnos";
            this.mnuInscripcionesAlumnos.Size = new System.Drawing.Size(202, 22);
            this.mnuInscripcionesAlumnos.Text = "Inscripciones Alumnos";
            // 
            // mnuInscripcionesDocentes
            // 
            this.mnuInscripcionesDocentes.Name = "mnuInscripcionesDocentes";
            this.mnuInscripcionesDocentes.Size = new System.Drawing.Size(202, 22);
            this.mnuInscripcionesDocentes.Text = "Inscripciones Docentes";
            // 
            // mnuPermisos
            // 
            this.mnuPermisos.Name = "mnuPermisos";
            this.mnuPermisos.Size = new System.Drawing.Size(202, 22);
            this.mnuPermisos.Text = "Permisos";
            // 
            // mnuReportes
            // 
            this.mnuReportes.Name = "mnuReportes";
            this.mnuReportes.Size = new System.Drawing.Size(202, 22);
            this.mnuReportes.Text = "Reportes";
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.Location = new System.Drawing.Point(356, 0);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(104, 23);
            this.btnCerrarSesion.TabIndex = 6;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(460, 217);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.linklblInscripcion);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Academia";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.LinkLabel linklblInscripcion;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuModificarDatos;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
        private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mnuCursos;
        private System.Windows.Forms.ToolStripMenuItem mnuMaterias;
        private System.Windows.Forms.ToolStripMenuItem mnuComisiones;
        private System.Windows.Forms.ToolStripMenuItem mnuPlanes;
        private System.Windows.Forms.ToolStripMenuItem mnuEspecialidades;
        private System.Windows.Forms.ToolStripMenuItem mnuInscripcionesAlumnos;
        private System.Windows.Forms.ToolStripMenuItem mnuInscripcionesDocentes;
        private System.Windows.Forms.ToolStripMenuItem mnuPermisos;
        private System.Windows.Forms.ToolStripMenuItem mnuReportes;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}