using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

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

        private Personas _DocenteActual;
        public Personas DocenteActual { get => _DocenteActual; set => _DocenteActual = value; }

        public DocenteDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public DocenteDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            Business.Logic.PersonasLogic doc = new Business.Logic.PersonasLogic();
            DocenteActual = doc.GetOne(ID);
            MapearDeDatos();
            MapearADatos();
        }
        public override void MapearDeDatos()
        {
            this.txtNombre.Text = this.DocenteActual.Nombre;
            this.txtApellido.Text = this.DocenteActual.Apellido;
            this.txtDireccion.Text = this.DocenteActual.Direccion;
            this.txtEmail.Text = this.DocenteActual.Email;
            this.txtTelefono.Text = this.DocenteActual.Telefono;
            this.dtpFechaNacimiento.Value = this.DocenteActual.FechaNacimiento;
            this.txtLegajo.Text = this.DocenteActual.Legajo.ToString();
            this.txtIdPlan.Text = this.DocenteActual.IDPlan.ToString();

        }

        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.btnAceptar.Text = "Guardar";
                Personas newDocCurso = new Personas();
                DocenteActual = newDocCurso;
                MessageBox.Show("¡Docente Creado!");
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
                this.DocenteActual.IDPlan = Convert.ToInt32(this.txtIdPlan.Text);
            }
            this.DocenteActual.Nombre = this.txtNombre.Text;
            this.DocenteActual.Apellido = this.txtApellido.Text;
            this.DocenteActual.Direccion = this.txtDireccion.Text;
            this.DocenteActual.Email = this.txtEmail.Text;
            this.DocenteActual.Telefono = this.txtTelefono.Text;
            this.DocenteActual.FechaNacimiento = this.dtpFechaNacimiento.Value;
            this.DocenteActual.Legajo = Convert.ToInt32(this.txtLegajo.Text);
            this.DocenteActual.IDPlan = Convert.ToInt32(this.txtIdPlan.Text);
            this.DocenteActual.TipoPersona = (Personas.TiposPersonas) 2;

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
                PersonasLogic dl = new PersonasLogic();
                dl.Save(this.DocenteActual);
            }
            else if (this.Modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                PersonasLogic dl = new PersonasLogic();
                dl.Save(this.DocenteActual);
            }
            else if (this.Modo == ModoForm.Baja)
            {
                this.MapearADatos();
                PersonasLogic dl = new PersonasLogic();
                dl.Save(this.DocenteActual);
            }
        }

        public override bool Validar()
        {
            if (this.txtNombre.Text != "" && this.txtEmail.Text != "" && this.txtDireccion.Text != "" && this.txtApellido.Text != "" &&
                this.txtIdPlan.Text != "" && this.txtLegajo.Text != "" && this.txtTelefono.Text != "" && this.dtpFechaNacimiento.Text != "")
            {
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
