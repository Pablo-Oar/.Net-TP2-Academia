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
    public partial class InscripcionAlumnoDesktop : ApplicationForm
    {
        public InscripcionAlumnoDesktop()
        {
            InitializeComponent();
        }

        private void AlumnoDesktop_Load(object sender, EventArgs e)
        {

        }

        private AlumnoInscripcion _AlumnoActual;
        public AlumnoInscripcion AlumnoActual { get => _AlumnoActual; set => _AlumnoActual = value; }

        public InscripcionAlumnoDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public InscripcionAlumnoDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            Business.Logic.AlumnoInscripcionLogic alu = new Business.Logic.AlumnoInscripcionLogic();
            AlumnoActual = alu.GetOne(ID);
            MapearDeDatos();
            MapearADatos();
        }
    }
}
