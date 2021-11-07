using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class CursoDesktop : ApplicationForm
    {
        public CursoDesktop()
        {
            InitializeComponent();
        }

        private void CursoDesktop_Load(object sender, EventArgs e)
        {

        }

        private Curso _CursoActual;
        public Curso CursoActual { get => _CursoActual; set => _CursoActual = value; }

        public CursoDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public CursoDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            Business.Logic.CursoLogic curso = new Business.Logic.CursoLogic();
            CursoActual = curso.GetOne(ID);
            MapearDeDatos();
            MapearADatos();
        }

        public override void MapearDeDatos()
        {
            this.txtIdMateria.Text = this.CursoActual.IDMateria.ToString();
            this.txtIdCurso.Text = this.CursoActual.ID.ToString();
            this.txtIdComision.Text = this.CursoActual.IDComision.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            this.txtAnioCalendario.Text = this.CursoActual.AnioCalendario.ToString();
        }

        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.btnAceptar.Text = "Guardar";
                Curso newCurso = new Curso();
                CursoActual = newCurso;
                MessageBox.Show("creado Curso");
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
                this.CursoActual.ID = Convert.ToInt32(this.txtIdCurso.Text);
            }
            this.CursoActual.ID = Convert.ToInt32(this.txtIdCurso.Text);
            this.CursoActual.IDComision = Convert.ToInt32(this.txtIdComision.Text);
            this.CursoActual.IDMateria = Convert.ToInt32(this.txtIdMateria.Text);
            this.CursoActual.Cupo = Convert.ToInt32(this.txtCupo.Text);
            this.CursoActual.AnioCalendario = Convert.ToInt32(this.txtAnioCalendario.Text);
            if (this.Modo == ModoForm.Alta)
            {
                this.CursoActual.State = Curso.States.New;
            }
            if (this.Modo == ModoForm.Baja)
            {
                this.CursoActual.State = Curso.States.Deleted;
            }
            if (this.Modo == ModoForm.Modificacion)
            {
                this.CursoActual.State = Curso.States.Modified;
            }
            if (this.Modo == ModoForm.Consulta)
            {
                this.CursoActual.State = Curso.States.Unmodified;
            }

        }

        public override void GuardarCambios()
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.MapearADatos();
                CursoLogic cl = new CursoLogic();
                cl.Save(this.CursoActual);
            }
            else if (this.Modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                CursoLogic cl = new CursoLogic();
                cl.Save(this.CursoActual);
            }
            else if (this.Modo == ModoForm.Baja)
            {
                this.MapearADatos();
                CursoLogic cl = new CursoLogic();
                cl.Save(this.CursoActual);
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

        public override bool Validar()
        {
            if (this.txtIdCurso.Text != "" && this.txtIdComision.Text != "" && this.txtIdMateria.Text != "" && this.txtCupo.Text != ""
                 && this.txtAnioCalendario.Text != "")
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
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
