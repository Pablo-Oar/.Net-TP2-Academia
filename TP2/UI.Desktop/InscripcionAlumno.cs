using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class InscripcionAlumno : ApplicationForm
    {
        private AlumnoInscripcionLogic _oAlumnos;
        public InscripcionAlumno()
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

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuarioDesktop UD = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            UD.ShowDialog();
            this.Listar();
        }

        private void tsbNuevo_Click_1(object sender, EventArgs e)
        {
            InscripcionAlumnoDesktop IAD = new InscripcionAlumnoDesktop(ApplicationForm.ModoForm.Alta);
            IAD.ShowDialog();
            this.Listar();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {

            if (this.dgvAlumnos.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.AlumnoInscripcion)this.dgvAlumnos.SelectedRows[0].DataBoundItem).ID;
                InscripcionAlumnoDesktop UD = new InscripcionAlumnoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                UD.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar un registro");
            }

        }
    }
}//Fin
