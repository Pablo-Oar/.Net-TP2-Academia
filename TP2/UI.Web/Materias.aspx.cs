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
    public partial class Materias : System.Web.UI.Page
    {
        private MateriaLogic _logic;
        private Materia _entity;
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = ((UsuarioPersona)HttpContext.Current.Session["current_user"]);
            if (user == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                LoadGrid();
            }
            if (user.TipoPersona == UsuarioPersona.TiposPersonas.Alumno)
            {
                Response.Redirect("Home.aspx");
            }
            if (user.TipoPersona == UsuarioPersona.TiposPersonas.Docente)
            {
                Response.Redirect("Home.aspx");
            }
        }

        private MateriaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new MateriaLogic();
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

        public Materia Entity
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
            this.idPlanTextBox.Text = this.Entity.IDPlan.ToString();
            this.HsSemTextBox.Text = this.Entity.HSSemanales.ToString();
            this.DescripcionTextBox.Text = this.Entity.Descripcion.ToString();
            this.HsTotTextBox.Text = this.Entity.HSTotales.ToString();
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

        private void LoadEntity(Materia comision)
        {
            comision.IDPlan = int.Parse(this.idPlanTextBox.Text);
            comision.HSSemanales = int.Parse(this.HsSemTextBox.Text);
            comision.Descripcion = this.DescripcionTextBox.Text;
            comision.HSTotales = int.Parse(this.HsTotTextBox.Text);

        }

        private void SaveEntity(Materia usuario)
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
                    this.Entity = new Materia();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Materia();
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
            this.idPlanTextBox.Enabled = enable;
            this.HsSemTextBox.Enabled = enable;
            this.DescripcionTextBox.Enabled = enable;
            this.HsTotTextBox.Enabled = enable;
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
            this.idPlanTextBox.Text = String.Empty;
            this.HsSemTextBox.Text = String.Empty;
            this.DescripcionTextBox.Text = String.Empty;
            this.HsTotTextBox.Text = String.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.LoadGrid();
            this.formPanel.Visible = false;

        }

        protected void TipoPersonaTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}