using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Alumnos : Form
    {
        private PersonasLogic _oAlumnos;
        public Alumnos()
        {
            InitializeComponent();
            this.dgvAlumnos.AutoGenerateColumns = false;
            this.oAlumnos = new PersonasLogic();
            this.dgvAlumnos.DataSource = this.oAlumnos.GetByTipo(1);
        }

        public void Listar()
        {
            PersonasLogic ul = new PersonasLogic();
            this.dgvAlumnos.DataSource = ul.GetByTipo(1);
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

        public PersonasLogic oAlumnos
        {
            get { return _oAlumnos; }
            set { _oAlumnos = value; }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            AlumnoDesktop AD = new AlumnoDesktop(ApplicationForm.ModoForm.Alta);
            AD.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvAlumnos.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Personas)this.dgvAlumnos.SelectedRows[0].DataBoundItem).ID;
                AlumnoDesktop AD = new AlumnoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                AD.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar un registro");
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvAlumnos.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Personas)this.dgvAlumnos.SelectedRows[0].DataBoundItem).ID;
                AlumnoDesktop AD = new AlumnoDesktop(ID, ApplicationForm.ModoForm.Baja);
                AD.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar un registro");
            }
        }
    }
}
