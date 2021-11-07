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
    public partial class WebForm2 : System.Web.UI.Page
    {
        private PersonasLogic _logic;
        private Personas _entity;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        private PersonasLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PersonasLogic();
                }
                return _logic;
            }
        }

        private void LoadGrid()
        {
            this.ObjectDataSource1.DataBind();
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

        public Personas Entity
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
            this.nombreTextBox.Text = this.Entity.Nombre;
            this.apellidoTextBox.Text = this.Entity.Apellido;
            this.emailTextBox.Text = this.Entity.Email;
            this.TelefonoTextBox.Text = this.Entity.Telefono;
            this.DireccionTextBox.Text = this.Entity.Direccion;
            this.idPlanTextBox.Text = this.Entity.IDPlan.ToString();
            this.FechadeNacTextBox.Text = this.Entity.FechaNacimiento.ToString();
            this.LegajoTextBox.Text = this.Entity.Legajo.ToString();
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

        private void LoadEntity(Personas alumno)
        {
            alumno.Nombre = this.nombreTextBox.Text;
            alumno.Apellido = this.apellidoTextBox.Text;
            alumno.Email = this.emailTextBox.Text;
            alumno.Telefono = this.TelefonoTextBox.Text;
            alumno.Direccion = this.DireccionTextBox.Text;
            alumno.IDPlan = int.Parse(this.idPlanTextBox.Text);
            alumno.Legajo = int.Parse(this.LegajoTextBox.Text);
            alumno.FechaNacimiento = DateTime.Parse(this.FechadeNacTextBox.Text);
            alumno.TipoPersona = (Personas.TiposPersonas)int.Parse(this.TipoPersonaTextBox.Text);
        }

        private void SaveEntity(Personas usuario)
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
                    this.Entity = new Personas();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Personas();
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
            this.nombreTextBox.Enabled = enable;
            this.apellidoTextBox.Enabled = enable;
            this.emailTextBox.Enabled = enable;
            this.TelefonoTextBox.Enabled = enable;
            this.DireccionTextBox.Enabled = enable;
            this.idPlanTextBox.Enabled = enable;
            LegajoTextBox.Enabled = enable;
            this.FechadeNacTextBox.Enabled = enable;
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
            this.nombreTextBox.Text = String.Empty;
            this.apellidoTextBox.Text = String.Empty;
            this.emailTextBox.Text = String.Empty;
            this.TelefonoTextBox.Text = String.Empty;
            this.DireccionTextBox.Text = String.Empty;
            this.idPlanTextBox.Text = String.Empty;
            this.FechadeNacTextBox.Text = String.Empty;
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