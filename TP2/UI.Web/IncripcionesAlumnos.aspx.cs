using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public partial class InscricionesAlumnos : System.Web.UI.Page
    {
        private AlumnoInscripcionLogic _logic;
        private AlumnoInscripcion _entity;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        private AlumnoInscripcionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new AlumnoInscripcionLogic();
                }
                return _logic;
            }
        }

        private void LoadGrid()
        {
            this.gridView.DataBind();
        }

        public enum FormModes
        {
            Alta,
            Baja,
            Moficacion
        }

        public FormModes FormMode
        {
            get
            {
                return (FormModes)this.ViewState["FormMode"];
            }
            set
            {
                this.ViewState["FormMode"] = value;
            }
        }

        public AlumnoInscripcion Entity
        {
            get
            {
                return _entity;
            }
            set
            {
                _entity = value;
            }
        }

        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.idAlumnoTextBox.Text = this.Entity.IDAlumno.ToString();
            this.idCursoTextBox.Text = this.Entity.IDCurso.ToString();
            this.CondicionTextBox.Text = this.Entity.Condicion.ToString();
            this.NotaTextBox.Text = this.Entity.Nota.ToString();
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.EnableForm(true);
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Moficacion;
                this.LoadForm(this.SelectedID);
            }
        }

        private void LoadEntity(AlumnoInscripcion comision)
        {
            comision.IDAlumno = int.Parse(this.idAlumnoTextBox.Text);
            comision.IDCurso = int.Parse(this.idCursoTextBox.Text);
            comision.Condicion = this.CondicionTextBox.Text;
            comision.Nota = int.Parse(this.NotaTextBox.Text);

        }

        private void SaveEntity(AlumnoInscripcion usuario)
        {
            this.Logic.Save(usuario);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Moficacion:
                    this.Entity = new AlumnoInscripcion();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new AlumnoInscripcion();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                default:
                    break;
            }
            this.formPanel.Visible = false;
        }

        protected void gridView_SelectedIndexChanged1(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void EnableForm(bool enable)
        {
            this.idAlumnoTextBox.Enabled = enable;
            this.idCursoTextBox.Enabled = enable;
            this.CondicionTextBox.Enabled = enable;
            this.NotaTextBox.Enabled = enable;
        }

        private void EnableFormNota()
        {
            this.idAlumnoTextBox.Enabled = false;
            this.idCursoTextBox.Enabled = false;
            this.CondicionTextBox.Enabled = false;
            this.NotaTextBox.Enabled = true;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        private void ClearForm()
        {
            this.idAlumnoTextBox.Text = String.Empty;
            this.idCursoTextBox.Text = String.Empty;
            this.CondicionTextBox.Text = String.Empty;
            this.NotaTextBox.Text = String.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.LoadGrid();
            this.formPanel.Visible = false;

        }

        protected void TipoPersonaTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void NotaLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.EnableFormNota();
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Moficacion;
                this.LoadForm(this.SelectedID);
            }
        }
    }
}