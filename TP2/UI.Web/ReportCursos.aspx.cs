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
    public partial class ReportCursos : System.Web.UI.Page
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
            CursoLogic ul = new CursoLogic();
            List<Curso> cursos = ul.GetAll();
            ReportDataSource rds = new ReportDataSource("DataSetCursos", cursos);

            this.ReportViewer1.LocalReport.DataSources.Add(rds);
            if (!IsPostBack)
            {
                this.ReportViewer1.LocalReport.Refresh();
            }
        }
    }
}