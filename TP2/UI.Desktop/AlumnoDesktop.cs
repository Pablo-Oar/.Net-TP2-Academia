using Business.Entities;
using System;


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

        private AlumnoInscripcion _AlumnoActual;
        public AlumnoInscripcion AlumnoActual { get => _AlumnoActual; set => _AlumnoActual = value; }

        public AlumnoDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public AlumnoDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            Business.Logic.AlumnoInscripcionLogic alu = new Business.Logic.AlumnoInscripcionLogic();
            AlumnoActual = alu.GetOne(ID);
            MapearDeDatos();
            MapearADatos();
        }
    }
}
