using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = ((UsuarioPersona)HttpContext.Current.Session["current_user"]);
            if (user != null)
            {
                LblNombre.Text = user.Nombre;
                LblApellido.Text = user.Apellido;
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}