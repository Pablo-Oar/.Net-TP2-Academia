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
            ModoForm ModoForm = modo; //No se si de esta manera esta bien... punto 10 Lab04 - Formulario ABMC
        }

        public UsuarioDesktop(int ID, ModoForm modo) : this() //Terminar punto 12.
        {
            ModoForm ModoForm = modo;
            Business.Logic.UsuarioLogic user = new Business.Logic.UsuarioLogic();
            

            MapearDeDatos();
        }
        public virtual void MapearDeDatos() { }
        public virtual void MapearADatos() { }
        public virtual void GuardarCambios() { }
        public virtual bool Validar() { return false; }
    }

}
