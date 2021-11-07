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
            CursoLogic ul = new CursoLogic();
            List<Curso> cursos = ul.GetAll();
            ReportDataSource rds = new ReportDataSource("DataSetCursos", cursos);
            //this.RvCursos.LocalReport.ReportEmbeddedResource = "UI.Desktop.ReportCursosViewer.rdlc";
            //this.RvCursos.LocalReport.DataSources.Clear();
            this.ReportViewer1.LocalReport.DataSources.Add(rds);
            //ReportViewer1.DataBind();
            ReportViewer1.LocalReport.Refresh();
        }
    }
}