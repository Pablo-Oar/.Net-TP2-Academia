using Business.Entities;
using Business.Logic;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class ReportPlanes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = ((UsuarioPersona)HttpContext.Current.Session["current_user"]);
            if (user == null)
            {
                Response.Redirect("Login.aspx");
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

 
        protected void Button1_Click1(object sender, EventArgs e)
        {
            PlanLogic ul = new PlanLogic();
            var cursos = ul.GetAll();
            ReportDataSource rds = new ReportDataSource("DSPlanes", cursos);            

            this.ReportViewer1.LocalReport.ReportEmbeddedResource = "UI.Web.ReportPlanes.rdlc";
            this.ReportViewer1.LocalReport.DataSources.Add(rds);
            this.ReportViewer1.LocalReport.Refresh();
            this.ReportViewer1.DataBind();
        }
    }
}