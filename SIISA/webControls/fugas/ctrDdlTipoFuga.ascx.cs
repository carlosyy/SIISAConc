using System;
using Business;

namespace SIISAConc.webControls.fugas
{
    public partial class ctrDdlTipoFuga : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarDdl();
            }
        }

        private void llenarDdl()
        {
            B_TipoFuga oB_TipoFuga = new B_TipoFuga();
            ddlTipoFuga.DataSource = oB_TipoFuga.getTipoFuga();
            ddlTipoFuga.DataValueField = "idTipoFuga";
            ddlTipoFuga.DataTextField = "tipoFuga";
            ddlTipoFuga.DataBind();
        }
    }
}