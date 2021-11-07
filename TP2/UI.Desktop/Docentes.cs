using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Docentes : Form
    {
        private PersonasLogic _oDocentes;
        public Docentes()
        {
            InitializeComponent();
            this.dgvDocentes.AutoGenerateColumns = false;
            this.oDocentes = new PersonasLogic();
            this.dgvDocentes.DataSource = this.oDocentes.GetByTipo((int)Personas.TiposPersonas.Docente);
        }

        public void Listar()
        {
            PersonasLogic ul = new PersonasLogic();
            this.dgvDocentes.DataSource = ul.GetByTipo((int)Personas.TiposPersonas.Docente);
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

        public PersonasLogic oDocentes
        {
            get { return _oDocentes; }
            set { _oDocentes = value; }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            DocenteDesktop UD = new DocenteDesktop(ApplicationForm.ModoForm.Alta);
            UD.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvDocentes.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Personas)this.dgvDocentes.SelectedRows[0].DataBoundItem).ID;
                DocenteDesktop DD = new DocenteDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                DD.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar un registro");
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvDocentes.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.DocenteCurso)this.dgvDocentes.SelectedRows[0].DataBoundItem).ID;
                DocenteDesktop DD = new DocenteDesktop(ID, ApplicationForm.ModoForm.Baja);
                DD.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar un registro");
            }
        }
    }
}
