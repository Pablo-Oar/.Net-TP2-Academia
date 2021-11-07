using Business.Entities;
using System;
using System.Windows.Forms;
using Business.Logic;

namespace UI.Desktop
{
    public partial class AlumnoDesktop : ApplicationForm
    {
        public AlumnoDesktop()
        {
            InitializeComponent();
        }

        private void AlumnoDesktop_Load(object sender, EventArgs e)
        {

        }

        private Personas _AlumnoActual;
        public Personas AlumnoActual { get => _AlumnoActual; set => _AlumnoActual = value; }

        public AlumnoDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public AlumnoDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            Business.Logic.PersonasLogic alu = new Business.Logic.PersonasLogic();
            AlumnoActual = alu.GetOne(ID);
            MapearDeDatos();
            MapearADatos();
        }

        public override void MapearDeDatos()
        {
            this.txtNombre.Text = this.AlumnoActual.Nombre.ToString();
            this.txtApellido.Text = this.AlumnoActual.Apellido.ToString();
            this.txtEmail.Text = this.AlumnoActual.Email.ToString();
            this.txtDireccion.Text = this.AlumnoActual.Direccion.ToString();
            this.txtIdPlan.Text = this.AlumnoActual.IDPlan.ToString();
            this.txtLegajo.Text = this.AlumnoActual.Legajo.ToString();
            this.dtsFechaNacimiento.Value = this.AlumnoActual.FechaNacimiento;
            this.txtTelefono.Text = this.AlumnoActual.Telefono.ToString();
        }

        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.btnAceptar.Text = "Guardar";
                Personas newAlumno = new Personas();
                AlumnoActual = newAlumno;
                MessageBox.Show("¡¡Alumno creado!!");
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

            this.AlumnoActual.Nombre = this.txtNombre.Text;
            this.AlumnoActual.Apellido = this.txtApellido.Text;
            this.AlumnoActual.Email = this.txtEmail.Text;
            this.AlumnoActual.Direccion = this.txtDireccion.Text;
            this.AlumnoActual.IDPlan = Convert.ToInt32(this.txtIdPlan.Text);
            this.AlumnoActual.Legajo = Convert.ToInt32(this.txtLegajo.Text);
            this.AlumnoActual.FechaNacimiento = this.dtsFechaNacimiento.Value;
            this.AlumnoActual.Telefono = this.txtTelefono.Text;
            this.AlumnoActual.TipoPersona = (Personas.TiposPersonas)1;
            if (this.Modo == ModoForm.Alta)
            {
                this.AlumnoActual.State = Personas.States.New;
            }
            if (this.Modo == ModoForm.Baja)
            {
                this.AlumnoActual.State = Personas.States.Deleted;
            }
            if (this.Modo == ModoForm.Modificacion)
            {
                this.AlumnoActual.State = Personas.States.Modified;
            }
            if (this.Modo == ModoForm.Consulta)
            {
                this.AlumnoActual.State = Personas.States.Unmodified;
            }

        }

        public override void GuardarCambios()
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.MapearADatos();
                PersonasLogic pl = new PersonasLogic();
                pl.Save(this.AlumnoActual);
            }
            else if (this.Modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                PersonasLogic pl = new PersonasLogic();
                pl.Save(this.AlumnoActual);
            }
            else if (this.Modo == ModoForm.Baja)
            {
                this.MapearADatos();
                PersonasLogic pl = new PersonasLogic();
                pl.Save(this.AlumnoActual);
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
        public override bool Validar()
        {
            if (this.txtNombre.Text != "" && this.txtEmail.Text != "" && this.txtDireccion.Text != "" && this.txtApellido.Text != "" &&
                this.txtIdPlan.Text != "" && this.txtLegajo.Text != "" &&this.txtTelefono.Text != "" && this.dtsFechaNacimiento.Text != "")
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
