using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Especialidades : Form
    {
        private EspecialidadLogic _oEspecialidades;
        public Especialidades()
        {
            InitializeComponent();
            this.dgvEspecialidad.AutoGenerateColumns = false;
            this.oEspecialidades = new EspecialidadLogic();
            this.dgvEspecialidad.DataSource = this.oEspecialidades.GetAll();
        }

        public void Listar()
        {
            EspecialidadLogic ul = new EspecialidadLogic();
            this.dgvEspecialidad.DataSource = ul.GetAll();
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

        public EspecialidadLogic oEspecialidades
        {
            get { return _oEspecialidades; }
            set { _oEspecialidades = value; }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            EspecialidadDesktop ED = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            ED.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if(this.dgvEspecialidad.SelectedRows.Count > 0){ 
                int ID = ((Business.Entities.Especialidad)this.dgvEspecialidad.SelectedRows[0].DataBoundItem).ID;
                EspecialidadDesktop ED = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                ED.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar un registro");
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvEspecialidad.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Especialidad)this.dgvEspecialidad.SelectedRows[0].DataBoundItem).ID;
                EspecialidadDesktop ED = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Baja);
                ED.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar un registro");
            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void tlUsuarios_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tcUsuarios_RightToolStripPanel_Click(object sender, EventArgs e)
        {

        }
    }
}
