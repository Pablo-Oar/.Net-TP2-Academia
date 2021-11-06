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
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}//Fin

