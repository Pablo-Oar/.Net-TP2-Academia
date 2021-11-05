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
    public partial class Docentes : Form
    {
        private DocenteCursoLogic _oDocentes;
        public Docentes()
        {
            InitializeComponent();
            this.dgvDocentes.AutoGenerateColumns = false;
            this.oDocentes = new DocenteCursoLogic();
            this.dgvDocentes.DataSource = this.oDocentes.GetAll();
        }

        public void Listar()
        {
            DocenteCursoLogic ul = new DocenteCursoLogic();
            this.dgvDocentes.DataSource = ul.GetAll();
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

        public DocenteCursoLogic oDocentes
        {
            get { return _oDocentes; }
            set { _oDocentes = value; }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuarioDesktop UD = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            UD.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if(this.dgvDocentes.SelectedRows.Count > 0){ 
                int ID = ((Business.Entities.Usuario)this.dgvDocentes.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop UD = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
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
            if (this.dgvDocentes.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Usuario)this.dgvDocentes.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop UD = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Baja);
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
