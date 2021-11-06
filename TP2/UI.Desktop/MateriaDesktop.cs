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
                MessageBox.Show("creada materia");
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

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
