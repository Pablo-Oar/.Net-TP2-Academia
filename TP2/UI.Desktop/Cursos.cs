using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Cursos : Form
    {
        private CursoLogic _oCursos;
        public Cursos()
        {
            InitializeComponent();
            this.dgvCursos.AutoGenerateColumns = false;
            this.oCursos = new CursoLogic();
            this.dgvCursos.DataSource = this.oCursos.GetAll();
        }

        public void Listar()
        {
            CursoLogic ul = new CursoLogic();
            this.dgvCursos.DataSource = ul.GetAll();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public CursoLogic oCursos
        {
            get { return _oCursos; }
            set { _oCursos = value; }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            CursoDesktop CD = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            CD.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                CursoDesktop CD = new CursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                CD.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar un registro");
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                CursoDesktop CD = new CursoDesktop(ID, ApplicationForm.ModoForm.Baja);
                CD.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar un registro");
            }
        }
    }
}
