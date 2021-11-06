using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class EspecialidadDesktop : ApplicationForm
    {
        public EspecialidadDesktop()
        {
            InitializeComponent();
        }

        private void EspecialidadDesktop_Load(object sender, EventArgs e)
        {

        }

        private Especialidad _EspecialidadActual;
        public Especialidad EspecialidadActual { get => _EspecialidadActual; set => _EspecialidadActual = value; }

        public EspecialidadDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public EspecialidadDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            Business.Logic.EspecialidadLogic esp = new Business.Logic.EspecialidadLogic();
            EspecialidadActual = esp.GetOne(ID);
            MapearDeDatos();
            MapearADatos();
        }

        public override void MapearDeDatos()
        {
            this.txtIdEspecialidad.Text = this.EspecialidadActual.ID.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion;
        }

        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.btnAceptar.Text = "Guardar";
                Especialidad newEspecialidad = new Especialidad();
                EspecialidadActual = newEspecialidad;
                MessageBox.Show("creada especialidad actual");
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
                this.EspecialidadActual.ID = Convert.ToInt32(this.txtIdEspecialidad.Text);
            }
            this.EspecialidadActual.ID = Convert.ToInt32(this.txtIdEspecialidad.Text);
            this.EspecialidadActual.Descripcion = this.txtDescripcion.Text;
            if (this.Modo == ModoForm.Alta)
            {
                this.EspecialidadActual.State = Especialidad.States.New;
            }
            if (this.Modo == ModoForm.Baja)
            {
                this.EspecialidadActual.State = Especialidad.States.Deleted;
            }
            if (this.Modo == ModoForm.Modificacion)
            {
                this.EspecialidadActual.State = Especialidad.States.Modified;
            }
            if (this.Modo == ModoForm.Consulta)
            {
                this.EspecialidadActual.State = Especialidad.States.Unmodified;
            }

        }

        public override void GuardarCambios()
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.MapearADatos();
                EspecialidadLogic pl = new EspecialidadLogic();
                pl.Save(this.EspecialidadActual);
            }
            else if (this.Modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                EspecialidadLogic pl = new EspecialidadLogic();
                pl.Save(this.EspecialidadActual);
            }
            else if (this.Modo == ModoForm.Baja)
            {
                this.MapearADatos();
                EspecialidadLogic pl = new EspecialidadLogic();
                pl.Save(this.EspecialidadActual);
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
