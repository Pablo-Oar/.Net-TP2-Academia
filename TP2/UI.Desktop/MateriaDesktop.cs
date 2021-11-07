using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class MateriaDesktop : ApplicationForm
    {
        private void MateriaDesktop_Load(object sender, EventArgs e)
        {

        }
        public MateriaDesktop()
        {
            InitializeComponent();
        }

        private Materia _MateriaActual;
        public Materia MateriaActual { get => _MateriaActual; set => _MateriaActual = value; }

        public MateriaDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public MateriaDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            Business.Logic.MateriaLogic mat = new Business.Logic.MateriaLogic();
            MateriaActual = mat.GetOne(ID);
            MapearDeDatos();
            MapearADatos();
        }

        public override void MapearDeDatos()
        {
            this.txtHsSemanales.Text = this.MateriaActual.HSSemanales.ToString();
            this.txtHsTotales.Text = this.MateriaActual.HSTotales.ToString();
            this.txtIDPlan.Text = this.MateriaActual.IDPlan.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion;
        }



        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.btnAceptar.Text = "Guardar";
                Materia newMat = new Materia();
                MateriaActual = newMat;
                MessageBox.Show("¡Materia creada!");
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
                this.MateriaActual.ID = Convert.ToInt32(this.txtIDPlan.Text);
            }
            this.MateriaActual.HSSemanales = Convert.ToInt32(this.txtHsSemanales.Text);
            this.MateriaActual.HSTotales = Convert.ToInt32(this.txtHsTotales.Text);
            this.MateriaActual.IDPlan = Convert.ToInt32(this.txtIDPlan.Text);
            this.MateriaActual.Descripcion = this.txtDescripcion.Text;
            if (this.Modo == ModoForm.Alta)
            {
                this.MateriaActual.State = Materia.States.New;
            }
            if (this.Modo == ModoForm.Baja)
            {
                this.MateriaActual.State = Materia.States.Deleted;
            }
            if (this.Modo == ModoForm.Modificacion)
            {
                this.MateriaActual.State = Materia.States.Modified;
            }
            if (this.Modo == ModoForm.Consulta)
            {
                this.MateriaActual.State = Materia.States.Unmodified;
            }

        }

        public override void GuardarCambios()
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.MapearADatos();
                MateriaLogic ml = new MateriaLogic();
                ml.Save(this.MateriaActual);
            }
            else if (this.Modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                MateriaLogic ml = new MateriaLogic();
                ml.Save(this.MateriaActual);
            }
            else if (this.Modo == ModoForm.Baja)
            {
                this.MapearADatos();
                MateriaLogic ml = new MateriaLogic();
                ml.Save(this.MateriaActual);
            }
        }



        public override bool Validar()
        {
            if (this.txtHsSemanales.Text != "" &&
           this.txtIDPlan.Text != "" &&
           this.txtHsTotales.Text != "" &&
           this.txtDescripcion.Text != "")
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
