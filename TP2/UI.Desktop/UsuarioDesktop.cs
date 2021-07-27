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
using System.Text.RegularExpressions;

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

        public UsuarioDesktop(int ID, ModoForm modo) : this() //Terminar punto 12.
        {
            ModoForm ModoForm = modo;
            Business.Logic.UsuarioLogic user = new Business.Logic.UsuarioLogic();
            UsuarioActual= user.GetOne(ID); ;
            MapearDeDatos();
        }
        public virtual void MapearDeDatos() {
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
            this.txtId.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtEmail.Text = this.UsuarioActual.EMail;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;            
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
        public virtual void MapearADatos() { }
        public virtual void GuardarCambios() {
            MapearADatos();
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(UsuarioActual);
        }
        public virtual bool Validar() {
            if (this.txtNombre.Text == "" &&
            this.txtEmail.Text == "" &&
            this.txtClave.Text == "" &&
            this.txtApellido.Text == "" &&
            this.txtUsuario.Text == "" && this.txtClave.Text == this.txtConfirmarClave.Text && this.txtClave.Text.Length < 7 && Regex.IsMatch(this.txtEmail.Text, @"/^[^\s@]+@[^\s@]+\.[^\s@]+$/"))
            {
                System.Windows.Forms.MessageBoxButtons boton = new System.Windows.Forms.MessageBoxButtons();                
                System.Windows.Forms.MessageBoxIcon icono = new System.Windows.Forms.MessageBoxIcon();
                Notificar("Error","Datos invalidos",boton,icono); // ----------------------- no se como pasar botones de parametros, revisar tema id que a veces va y a veces no
                return true;
            } else return false;
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}
