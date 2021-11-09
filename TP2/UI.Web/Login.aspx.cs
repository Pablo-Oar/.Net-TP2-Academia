using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var us = ((UsuarioPersona)HttpContext.Current.Session["current_user"]);
            if (us != null)
            {
                Session["current_user"] = null;
                Response.Redirect("Login.aspx");
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
           
                UsuarioLogic ul = new UsuarioLogic();
                UsuarioPersona user = ul.LogIn(UsuarioTextBox.Text, ClaveTextBox.Text);
                if (user.Nombre != null && user.Nombre != "")
                {
                    Session["current_user"] = user;
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    FailLoginLabel.Visible = true;
                }
         
          
        }
    }
}