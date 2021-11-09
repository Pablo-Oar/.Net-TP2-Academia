using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public UsuarioPersona usuarioLogueado //Seteado cuando el logueo del usuario es exitoso! 
        {
            get; set;
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioPersona usu = new UsuarioPersona();
            try
            {
                usu = ul.LogIn(txtUsuario.Text, txtContraseña.Text);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!String.IsNullOrEmpty(usu.NombreUsuario))
            {
                this.txtUsuario.Clear();
                this.txtContraseña.Clear();
                usuarioLogueado = usu; //Seteo el usuario logueado que se realizo de forma correcta! 
                Main main = Main.ObtenerMain(usu);
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Error de logueo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}//Fin

