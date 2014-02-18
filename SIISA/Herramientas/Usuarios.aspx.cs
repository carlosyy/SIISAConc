using System;
using SIISAConc.webControls.usuarios;

namespace SIISAConc.Herramientas
{
    public partial class Usuarios : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
					ctrListUsuarios1.RepeaterCommand += new webControls.ctrListUsuarios.RepeaterCommandEventHandler(ctrListUsuarios_RepeaterCommand);
					ctrAddUsuario.ImageClick += new webControls.ctrAddUsuario.ImageClickEventHandler(ctrAddUsuario_ImageClick);

            if (!IsPostBack)
            {
                
            }            
        }
				private void ctrListUsuarios_RepeaterCommand(webControls.ctrListUsuarios.RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                pnlDetalle.Visible = true;
                pnlLista.Visible = false;

                if (Session["idPerfil"] != null)
                {
                    ctrAddUsuario.editarUsuario(e.idUser, Int32.Parse(Session["idPerfil"].ToString()));
                }
            }
            else if (e.CommandName == "nuevo")
            {
                pnlDetalle.Visible = true;
                pnlLista.Visible = false;
                ctrAddUsuario.nuevoUsuario();
            }
        }

				private void ctrAddUsuario_ImageClick(webControls.ctrAddUsuario.ImageClickEventArgs e)
        {
            if (e.CommandName == "cancelar")
            {
                pnlDetalle.Visible = false;
                pnlLista.Visible = true;
            }
        }
    }
}