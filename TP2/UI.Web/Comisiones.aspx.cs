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
    public partial class Comisiones : System.Web.UI.Page
    {
        private ComisionLogic _logic;
        private Comision _entity;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        private ComisionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new ComisionLogic();
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

        public Comision Entity
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
            this.idplanTextBox.Text = this.Entity.IdPlan.ToString();
            this.anioTextBox.Text = this.Entity.AñoEspecialidad.ToString();
            this.descTextBox.Text = this.Entity.Descripcion;            
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

        private void LoadEntity(Comision comision)
        {
            comision.IdPlan = int.Parse(this.idplanTextBox.Text);
            comision.AñoEspecialidad = int.Parse(this.anioTextBox.Text);
            comision.Descripcion = this.descTextBox.Text;
        }

        private void SaveEntity(Comision usuario)
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
                    this.Entity = new Comision();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Comision();
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
            this.idplanTextBox.Enabled = enable;
            this.anioTextBox.Enabled = enable;
            this.descTextBox.Enabled = enable;
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
            this.idplanTextBox.Text = String.Empty;
            this.anioTextBox.Text = String.Empty;
            this.descTextBox.Text = String.Empty;
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