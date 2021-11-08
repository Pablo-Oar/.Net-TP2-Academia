using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

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
            if (this.Modo == ModoForm.Baja)
            {
                this.txtIDPlan.Enabled = false;
                this.txtIDEspecialidad.Enabled = false;
                this.txtDescPlan.Enabled = false;
            }
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

        public override bool Validar()
        {
            if (this.txtIDPlan.Text != "" &&
           this.txtDescPlan.Text != "" &&
           this.txtIDEspecialidad.Text != "") { 
                //MessageBox.Show("valida ok");
                return true;
            }
            else
            {
                System.Windows.Forms.MessageBoxButtons boton = new System.Windows.Forms.MessageBoxButtons();
                System.Windows.Forms.MessageBoxIcon icono = new System.Windows.Forms.MessageBoxIcon();
                Notificar("Error", "Datos invalidos", boton, icono);
                return false;
            }
        }
    }
}
