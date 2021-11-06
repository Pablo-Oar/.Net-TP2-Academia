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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        public Main(Usuario usu)
        {
            InitializeComponent();
            this.lblNombre.Text = usu.Nombre;
            this.lblApellido.Text = usu.Apellido;
        }

        
    }
}
