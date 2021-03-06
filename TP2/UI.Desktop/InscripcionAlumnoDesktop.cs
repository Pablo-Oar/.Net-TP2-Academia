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

        private AlumnoInscripcion _InscripcionAlumnoActual;
        public AlumnoInscripcion InscripcionAlumnoActual { get => _InscripcionAlumnoActual; set => _InscripcionAlumnoActual = value; }

        public InscripcionAlumnoDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public InscripcionAlumnoDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            Business.Logic.AlumnoInscripcionLogic aluinscrip = new Business.Logic.AlumnoInscripcionLogic();
            InscripcionAlumnoActual = aluinscrip.GetOne(ID);
            MapearDeDatos();
            MapearADatos();
        }
        public override void MapearDeDatos()
        {

            this.txtIdAlumno.Text = this.InscripcionAlumnoActual.IDAlumno.ToString();
            this.txtIdCurso.Text = this.InscripcionAlumnoActual.IDCurso.ToString();
            this.txtCondicion.Text = this.InscripcionAlumnoActual.Condicion;
            this.cmbNota.SelectedIndex = this.InscripcionAlumnoActual.Nota;
            this.txtIdCurso.Enabled = true;
            if (this.Modo == ModoForm.Modificacion)
            {
                this.txtIdCurso.Enabled = false;
            }        
            if (this.Modo == ModoForm.Baja)
            {
            this.txtIdAlumno.Enabled=false;
            this.txtIdCurso.Enabled = false;
            this.txtCondicion.Enabled = false;
            this.cmbNota.Enabled = false;
            }
        }

        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.btnAceptar.Text = "Guardar";
                AlumnoInscripcion newAluInscripcion = new AlumnoInscripcion();
                InscripcionAlumnoActual = newAluInscripcion;

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
            this.InscripcionAlumnoActual.IDAlumno = Convert.ToInt32(this.txtIdAlumno.Text);
            this.InscripcionAlumnoActual.IDCurso = Convert.ToInt32(this.txtIdCurso.Text);
            this.InscripcionAlumnoActual.Condicion = this.txtCondicion.Text;
            this.InscripcionAlumnoActual.Nota = this.cmbNota.SelectedIndex;
            if (this.Modo == ModoForm.Alta)
            {
                this.InscripcionAlumnoActual.State = AlumnoInscripcion.States.New;
            }
            if (this.Modo == ModoForm.Baja)
            {
                this.InscripcionAlumnoActual.State = AlumnoInscripcion.States.Deleted;
            }
            if (this.Modo == ModoForm.Modificacion)
            {
                this.InscripcionAlumnoActual.State = AlumnoInscripcion.States.Modified;
            }
            if (this.Modo == ModoForm.Consulta)
            {
                this.InscripcionAlumnoActual.State = AlumnoInscripcion.States.Unmodified;
            }

        }

        public override void GuardarCambios()
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.MapearADatos();
                CursoLogic cl = new CursoLogic();
                CursoLogic cl2 = new CursoLogic();
                Curso cur = cl.GetOne(InscripcionAlumnoActual.IDCurso);
                if (cur.Cupo > 0)
                {   
                    cur.State = BusinessEntity.States.Modified;
                    cur.Cupo = cur.Cupo - 1;
                    cl2.Save(cur);
                    AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
                    ail.Save(this.InscripcionAlumnoActual);
                }
                else
                {
                    MessageBox.Show("No hay cupo en el curso");
                }
            }
            else if (this.Modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
                ail.Save(this.InscripcionAlumnoActual);
            }
            else if (this.Modo == ModoForm.Baja)
            {
                CursoLogic cl = new CursoLogic();
                CursoLogic cl2 = new CursoLogic();
                Curso cur = cl.GetOne(InscripcionAlumnoActual.IDCurso);
                this.MapearADatos();
                cur.Cupo = cur.Cupo + 1;
                cur.State = BusinessEntity.States.Modified;
                cl2.Save(cur);
                AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
                ail.Save(this.InscripcionAlumnoActual);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (this.txtIdAlumno.Text != "" && this.txtIdCurso.Text != "" && this.txtCondicion.Text != "" && this.cmbNota.Text != "")
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

    }
}
