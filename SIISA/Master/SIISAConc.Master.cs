using Business;
using Entities;
using System;

namespace SIISAConc.Master
{
    public partial class SIISAConc : System.Web.UI.MasterPage
    {
        private static vars vars = vars.GetInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["idPerfil"] == null)
                {                    
                    pnlMenu.Visible = false;                    
                    pnlUsuarioLogueado.Visible = false;
                    Session.Timeout = 15;
                }
                else
                {
                    pnlMenu.Visible = true;
                    pnlUsuarioLogueado.Visible = true;                    
                }
                llenarEntidadMeses();
                
            }
            if (Request.Params["__EVENTTARGET"] == "cerrar")
            {
                Session.RemoveAll();
                Response.Redirect("/default.aspx");
            }            
        }

        private void llenarEntidadMeses()
        {
            vars vars = vars.GetInstance();
            if (vars.meses == null)
            {
                B_Meses oMeses = new B_Meses();
                vars.meses = oMeses.GetMeses();                
            }
            llenarDdlMeses(vars.meses);
        }

        private void llenarDdlMeses(Meses meses)
        {
            ddlMesRad.DataSource = meses;
            ddlMesRad.DataTextField = "nMes";
            ddlMesRad.DataValueField = "meses";
            ddlMesRad.DataBind();
            if (Session["mesRad"] == null)
                Session["mesRad"] = ddlMesRad.SelectedValue;
            else
                ddlMesRad.SelectedValue = Session["mesRad"].ToString();        }
        

        protected void botonCerrar_Click(object sender, EventArgs e)
        {            
            Session.RemoveAll();
            Response.Redirect("/default.aspx");
        }

        protected void ddlMesRad_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["mesRad"] = ddlMesRad.SelectedValue;            
        }
    }
}