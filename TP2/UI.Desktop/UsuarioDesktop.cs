using Business.Entities;
using Business.Logic;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        private Usuario _UsuarioActual;
        public Usuario UsuarioActual { get => _UsuarioActual; set => _UsuarioActual = value; }

        public UsuarioDesktop()
        {
            InitializeComponent();
        }
        public UsuarioDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            Business.Logic.UsuarioLogic user = new Business.Logic.UsuarioLogic();
            UsuarioActual = user.GetOne(ID);
            MapearDeDatos();
            MapearADatos();
        }
        public override void MapearDeDatos()
        {
            this.txtId.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtEmail.Text = this.UsuarioActual.EMail;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.tbIdPersona.Text = this.UsuarioActual.IdPerosna.ToString();
            if (this.Modo == ModoForm.Baja)
            {
                this.txtId.Enabled = false;
                this.chkHabilitado.Enabled = false;
                this.txtNombre.Enabled = false;
                this.txtEmail.Enabled = false;
                this.txtClave.Enabled = false;
                this.txtApellido.Enabled = false;
                this.txtUsuario.Enabled = false;
                this.txtConfirmarClave.Enabled = false;
                this.tbIdPersona.Enabled = false;
            }
        }
        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.btnAceptar.Text = "Guardar";
                Usuario newUser = new Usuario();
                UsuarioActual = newUser;
               
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
                this.UsuarioActual.ID = Convert.ToInt32(this.txtId.Text);
            }
            this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
            this.UsuarioActual.Nombre = this.txtNombre.Text;
            this.UsuarioActual.EMail = this.txtEmail.Text;
            this.UsuarioActual.Clave = this.txtClave.Text;
            this.UsuarioActual.Apellido = this.txtApellido.Text;
            this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
            this.UsuarioActual.IdPerosna = int.Parse(this.tbIdPersona.Text);
            if (this.Modo == ModoForm.Alta)
            {
                this.UsuarioActual.State = Usuario.States.New;
            }
            if (this.Modo == ModoForm.Baja)
            {
                this.UsuarioActual.State = Usuario.States.Deleted;
            }
            if (this.Modo == ModoForm.Modificacion)
            {
                this.UsuarioActual.State = Usuario.States.Modified;
            }
            if (this.Modo == ModoForm.Consulta)
            {
                this.UsuarioActual.State = Usuario.States.Unmodified;
            }
        }
        public override void GuardarCambios()
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.MapearADatos();
                UsuarioLogic ul = new UsuarioLogic();
                ul.Save(this.UsuarioActual);
                MessageBox.Show("creado nuevo usuario");
            }
            else if (this.Modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                UsuarioLogic ul = new UsuarioLogic();
                ul.Save(this.UsuarioActual);
            }
            else if (this.Modo == ModoForm.Baja)
            {
                this.MapearADatos();
                UsuarioLogic ul = new UsuarioLogic();
                ul.Save(this.UsuarioActual);
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
            if (this.txtNombre.Text != "" && this.tbIdPersona.Text != "" &&
           txtEmail.Text != "" &&
           this.txtClave.Text != "" &&
           this.txtApellido.Text != "" &&
           this.txtUsuario.Text != "" && this.txtClave.Text == this.txtConfirmarClave.Text && this.txtClave.Text.Length > 7 && Regex.IsMatch(this.txtEmail.Text, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3} @\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                 @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
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
            Close();
        }
        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

       

        private void lblConfirmarClave_Click(object sender, EventArgs e)
        {

        }
    }

}
