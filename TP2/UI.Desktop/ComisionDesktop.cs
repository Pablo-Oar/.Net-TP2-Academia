using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class ComisionDesktop : ApplicationForm
    {
        public ComisionDesktop()
        {
            InitializeComponent();
        }

        private void ComisionDesktop_Load(object sender, EventArgs e)
        {

        }

        private Comision _ComisionActual;
        public Comision ComisionActual { get => _ComisionActual; set => _ComisionActual = value; }

        public ComisionDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public ComisionDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            Business.Logic.ComisionLogic com = new Business.Logic.ComisionLogic();
            ComisionActual = com.GetOne(ID);
            MapearDeDatos();
            MapearADatos();
        }
        public override void MapearDeDatos()
        {
            this.txtIdComision.Text = this.ComisionActual.ID.ToString();
            this.txtIdPlan.Text = this.ComisionActual.IdPlan.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion.ToString();
            this.txtAñoEspecialidad.Text = this.ComisionActual.AñoEspecialidad.ToString();
        }

        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.btnAceptar.Text = "Guardar";
                Comision newComision = new Comision();
                ComisionActual = newComision;
                MessageBox.Show("creada la Comision");
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
                this.ComisionActual.ID = Convert.ToInt32(this.txtIdComision.Text);
            }
            this.ComisionActual.ID = Convert.ToInt32(this.txtIdComision.Text);
            this.ComisionActual.IdPlan = Convert.ToInt32(this.txtIdPlan.Text);
            this.ComisionActual.Descripcion = this.txtDescripcion.Text;
            this.ComisionActual.AñoEspecialidad = Convert.ToInt32(this.txtAñoEspecialidad.Text);
            if (this.Modo == ModoForm.Alta)
            {
                this.ComisionActual.State = Comision.States.New;
            }
            if (this.Modo == ModoForm.Baja)
            {
                this.ComisionActual.State = Comision.States.Deleted;
            }
            if (this.Modo == ModoForm.Modificacion)
            {
                this.ComisionActual.State = Comision.States.Modified;
            }
            if (this.Modo == ModoForm.Consulta)
            {
                this.ComisionActual.State = Comision.States.Unmodified;
            }

        }

        public override void GuardarCambios()
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.MapearADatos();
                ComisionLogic cl = new ComisionLogic();
                cl.Save(this.ComisionActual);
            }
            else if (this.Modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                ComisionLogic cl = new ComisionLogic();
                cl.Save(this.ComisionActual);
            }
            else if (this.Modo == ModoForm.Baja)
            {
                this.MapearADatos();
                ComisionLogic cl = new ComisionLogic();
                cl.Save(this.ComisionActual);
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
