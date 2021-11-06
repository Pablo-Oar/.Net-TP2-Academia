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
    public partial class InscripcionesAlumnos : Form
    {
        private AlumnoInscripcionLogic _oAlumnos;
        public InscripcionesAlumnos()
        {
            InitializeComponent();
            this.dgvAlumnos.AutoGenerateColumns = false;
            this.oAlumnos = new AlumnoInscripcionLogic();
            this.dgvAlumnos.DataSource = this.oAlumnos.GetAll();
        }

        public void Listar()
        {
            AlumnoInscripcionLogic ul = new AlumnoInscripcionLogic();
            this.dgvAlumnos.DataSource = ul.GetAll();
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

        public AlumnoInscripcionLogic oAlumnos
        {
            get { return _oAlumnos; }
            set { _oAlumnos = value; }
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
            if(this.dgvAlumnos.SelectedRows.Count > 0){ 
                int ID = ((Business.Entities.Usuario)this.dgvAlumnos.SelectedRows[0].DataBoundItem).ID;
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
            if (this.dgvAlumnos.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Usuario)this.dgvAlumnos.SelectedRows[0].DataBoundItem).ID;
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
