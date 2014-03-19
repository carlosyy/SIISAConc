using Business;
using Entities;
using System;

namespace SIISAConc.Master
{
    public partial class SIISAConc : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["idPerfil"] == null)
                {
                    pnlMenu.Visible = false;
                    pnlUsuarioLogueado.Visible = false;
                    Session.Timeout = 60;
                }
                else
                {
                    pnlMenu.Visible = true;
                    pnlUsuarioLogueado.Visible = true;
                }


            }
            if (Request.Params["__EVENTTARGET"] == "cerrar")
            {
                Session.RemoveAll();
                Response.Redirect("/default.aspx");
            }
        }


        protected void botonCerrar_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("/default.aspx");
        }
    }

}