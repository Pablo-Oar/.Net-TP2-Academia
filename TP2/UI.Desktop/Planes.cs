using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Planes : Form
    {
        private PlanLogic _oPlanes;
        public Planes()
        {
            InitializeComponent();
            this.dgvPlanes.AutoGenerateColumns = false;
            this.oPlanes = new PlanLogic();
            this.dgvPlanes.DataSource = this.oPlanes.GetAll();
        }

        public void Listar()
        {
            PlanLogic pl = new PlanLogic();
            this.dgvPlanes.DataSource = pl.GetAll();
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

        public PlanLogic oPlanes
        {
            get { return _oPlanes; }
            set { _oPlanes = value; }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PlanesDesktop PD = new PlanesDesktop(ApplicationForm.ModoForm.Alta);
            PD.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlanes.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                PlanesDesktop UD = new PlanesDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                UD.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar un registro");
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlanes.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                PlanesDesktop UD = new PlanesDesktop(ID, ApplicationForm.ModoForm.Baja);
                UD.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar un registro");
            }
        }
    }
}
