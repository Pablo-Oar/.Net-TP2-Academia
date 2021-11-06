using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Comisiones : Form
    {
        private ComisionLogic _oComision;
        public Comisiones()
        {
            InitializeComponent();
            this.dgvComision.AutoGenerateColumns = false;
            this.oComision = new ComisionLogic();
            this.dgvComision.DataSource = this.oComision.GetAll();
        }

        public void Listar()
        {
            ComisionLogic ul = new ComisionLogic();
            this.dgvComision.DataSource = ul.GetAll();
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

        public ComisionLogic oComision
        {
            get { return _oComision; }
            set { _oComision = value; }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ComisionDesktop UD = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            UD.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvComision.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Comision)this.dgvComision.SelectedRows[0].DataBoundItem).ID;
                ComisionDesktop UD = new ComisionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
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
            if (this.dgvComision.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Comision)this.dgvComision.SelectedRows[0].DataBoundItem).ID;
                ComisionDesktop UD = new ComisionDesktop(ID, ApplicationForm.ModoForm.Baja);
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
