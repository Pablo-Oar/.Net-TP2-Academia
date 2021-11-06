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
    public partial class PlanesDesktop : ApplicationForm
    {
        public PlanesDesktop()
        {
            InitializeComponent();
        }
        private void PlanesDesktop_Load(object sender, EventArgs e)
        {

        }

        private Plan _PlanActual;
        public Plan PlanActual { get => _PlanActual; set => _PlanActual = value; }

        public PlanesDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public PlanesDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            Business.Logic.PlanLogic mat = new Business.Logic.PlanLogic();
            PlanActual = mat.GetOne(ID);
            MapearDeDatos();
            MapearADatos();
        }


        public override void MapearDeDatos()
        {
            this.txtIDPlan.Text = this.PlanActual.ID.ToString();
            this.txtIDEspecialidad.Text = this.PlanActual.IdEspecialidad.ToString();
            this.txtDescPlan.Text = this.PlanActual.Descripcion.ToString();
        }

        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.btnAceptar.Text = "Guardar";
                Plan newPlan = new Plan();
                PlanActual = newPlan;
                MessageBox.Show("creado plan actual");
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
                this.PlanActual.ID = Convert.ToInt32(this.txtIDPlan.Text);
            }
            this.PlanActual.IdEspecialidad = Convert.ToInt32(this.txtIDEspecialidad.Text);
            this.PlanActual.ID = Convert.ToInt32(this.txtIDPlan.Text);
            this.PlanActual.Descripcion = this.txtDescPlan.Text;
            if (this.Modo == ModoForm.Alta)
            {
                this.PlanActual.State = Plan.States.New;
            }
            if (this.Modo == ModoForm.Baja)
            {
                this.PlanActual.State = Plan.States.Deleted;
            }
            if (this.Modo == ModoForm.Modificacion)
            {
                this.PlanActual.State = Plan.States.Modified;
            }
            if (this.Modo == ModoForm.Consulta)
            {
                this.PlanActual.State = Plan.States.Unmodified;
            }

        }

        public override void GuardarCambios()
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.MapearADatos();
                PlanLogic pl = new PlanLogic();
                pl.Save(this.PlanActual);
            }
            else if (this.Modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                PlanLogic pl = new PlanLogic();
                pl.Save(this.PlanActual);
            }
            else if (this.Modo == ModoForm.Baja)
            {
                this.MapearADatos();
                PlanLogic pl = new PlanLogic();
                pl.Save(this.PlanActual);
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
