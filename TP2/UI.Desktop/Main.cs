using Business.Entities;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Main : Form
    {
        private UsuarioPersona userlogged;
        private static Main mainSingleton;
        private Main()
        {
            InitializeComponent();

        }

        private Main(UsuarioPersona usu)
        {
            InitializeComponent();
            userlogged = usu;
            this.lblBienvenido.Text = "¡¡Bienvenido al Sistema Gestion de Academia!! \n" + usu.Nombre + ", " + usu.Apellido;
            this.LblTipo.Text = "Permisos: " + usu.TipoPersona.ToString();
            switch (usu.TipoPersona)
            {
                case UsuarioPersona.TiposPersonas.Admin:
                break;
                case UsuarioPersona.TiposPersonas.Alumno:
                    mnuInscripcionesAlumnos.Visible = true;
                    mnuUsuarios.Visible = false;
                    alumnosToolStripMenuItem.Visible = false;
                    docentesToolStripMenuItem.Visible = false;
                    mnuCursos.Visible = false;
                    mnuMaterias.Visible = false;
                    mnuComisiones.Visible = false;
                    mnuPlanes.Visible = false;
                    mnuEspecialidades.Visible = false;
                    mnuReportes.Visible = false;
                    reporteDePlanesToolStripMenuItem.Visible = false;
                break;
                case UsuarioPersona.TiposPersonas.Docente:
                    mnuInscripcionesAlumnos.Visible = true;
                    mnuUsuarios.Visible = false;
                    alumnosToolStripMenuItem.Visible = false;
                    docentesToolStripMenuItem.Visible = true;
                    mnuCursos.Visible = true;
                    mnuMaterias.Visible = false;
                    mnuComisiones.Visible = false;
                    mnuPlanes.Visible = false;
                    mnuEspecialidades.Visible = false;
                    mnuReportes.Visible = false;
                    reporteDePlanesToolStripMenuItem.Visible = false;
                break;
            }
        }

        public static Main ObtenerMain(UsuarioPersona usu)
        {

            if(mainSingleton == null)
            {
                mainSingleton = new Main(usu);
            }
            return mainSingleton;
        }

        private void mnuUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios frmUsuarios = new Usuarios();
            frmUsuarios.ShowDialog();
        }

        private void mnuCursos_Click(object sender, EventArgs e)
        {
            Cursos frmCursos = new Cursos();
            frmCursos.ShowDialog();
        }

        private void mnuMaterias_Click(object sender, EventArgs e)
        {
            Materias frmMaterias = new Materias();
            frmMaterias.ShowDialog();
        }

        private void mnuComisiones_Click(object sender, EventArgs e)
        {
            Comisiones frmComisiones = new Comisiones();
            frmComisiones.ShowDialog();
        }

        private void mnuPlanes_Click(object sender, EventArgs e)
        {
            Planes frmPlanes = new Planes();
            frmPlanes.ShowDialog();
        }

        private void mnuEspecialidades_Click(object sender, EventArgs e)
        {
            Especialidades frmEspecialidad = new Especialidades();
            frmEspecialidad.ShowDialog();
        }

        private void mnuInscripcionesAlumnos_Click(object sender, EventArgs e)
        {
            InscripcionAlumno frmInscripcionAlumnos = new InscripcionAlumno(userlogged);
            frmInscripcionAlumnos.ShowDialog();
        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alumnos frmAlumnos = new Alumnos();
            frmAlumnos.ShowDialog();
        }

        private void docentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Docentes frmDocentes = new Docentes();
            frmDocentes.ShowDialog();
        }

        private void mnuReportes_Click(object sender, EventArgs e)
        {
            CursosReport cur = new CursosReport();
            cur.ShowDialog();
        }

        private void reporteDePlanesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlanesReport pla = new PlanesReport();
            pla.ShowDialog();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }
    }
}
