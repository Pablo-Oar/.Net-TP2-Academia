using Business.Entities;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        public Main(Usuario usu)
        {
            InitializeComponent();
            this.lblNombre.Text = usu.Nombre;
            this.lblApellido.Text = usu.Apellido;
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

        }
    }
}
