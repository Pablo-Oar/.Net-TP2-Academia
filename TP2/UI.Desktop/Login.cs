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

        public Usuario usuarioLogged //Setted when user log in is successfull
        {
            get; set;
        }



        private void btnSalir_Ingresar(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            UsuarioLogic ul = new UsuarioLogic();
            Usuario usu = new Usuario();
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
                //this.DialogResult = DialogResult.OK;
                this.usuarioLogged = usu;
                Main main = new Main(usu);
                main.ShowDialog();
                //this.Close();//Close after successfull login
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Error de logueo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}//Fin

