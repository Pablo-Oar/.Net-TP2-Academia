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
    public partial class DocenteDesktop : ApplicationForm
    {
        public DocenteDesktop()
        {
            InitializeComponent();
        }

        private void DocenteDesktop_Load(object sender, EventArgs e)
        {

        }

        private DocenteCurso _DocenteActual;
        public DocenteCurso DocenteActual { get => _DocenteActual; set => _DocenteActual = value; }

        public DocenteDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public DocenteDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            Business.Logic.DocenteCursoLogic doc = new Business.Logic.DocenteCursoLogic();
            DocenteActual = doc.GetOne(ID);
            MapearDeDatos();
            MapearADatos();
        }
        public override void MapearDeDatos()
        {
            this.txtIdDocente.Text = this.DocenteActual.IDDocente.ToString();
            this.txtIdCurso.Text = this.DocenteActual.IDCurso.ToString();
            this.txtCargo.Text = this.DocenteActual.Cargo.ToString();
        }

        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.btnAceptar.Text = "Guardar";
                DocenteCurso newDocCurso = new DocenteCurso();
                DocenteActual = newDocCurso;
                MessageBox.Show("creado docente");
            }
            if (this.Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }
            if (this.Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            if (this.Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }
            if (this.Modo != ModoForm.Alta)
            {
                this.DocenteActual.IDDocente = Convert.ToInt32(this.txtIdCurso.Text);
            }
            this.DocenteActual.IDDocente = Convert.ToInt32(this.txtIdDocente.Text);
            this.DocenteActual.IDCurso = Convert.ToInt32(this.txtIdCurso.Text);
            //this.DocenteActual.Cargo = this.txtCargo.Text;
            if (this.Modo == ModoForm.Alta)
            {
                this.DocenteActual.State = DocenteCurso.States.New;
            }
            if (this.Modo == ModoForm.Baja)
            {
                this.DocenteActual.State = DocenteCurso.States.Deleted;
            }
            if (this.Modo == ModoForm.Modificacion)
            {
                this.DocenteActual.State = DocenteCurso.States.Modified;
            }
            if (this.Modo == ModoForm.Consulta)
            {
                this.DocenteActual.State = DocenteCurso.States.Unmodified;
            }

        }

        public override void GuardarCambios()
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.MapearADatos();
                DocenteCursoLogic dl = new DocenteCursoLogic();
                dl.Save(this.DocenteActual);
            }
            else if (this.Modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                DocenteCursoLogic dl = new DocenteCursoLogic();
                dl.Save(this.DocenteActual);
            }
            else if (this.Modo == ModoForm.Baja)
            {
                this.MapearADatos();
                DocenteCursoLogic dl = new DocenteCursoLogic();
                dl.Save(this.DocenteActual);
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Modo == ModoForm.Baja)
            {
                GuardarCambios();
                Close();
            }
            else if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
