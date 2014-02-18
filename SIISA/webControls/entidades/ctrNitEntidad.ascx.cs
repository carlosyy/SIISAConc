using System;
using Business;

namespace SIISAConc.webControls.entidades
{
    public partial class ctrNitEntidad : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenaDdls();
            }
        }

        private void llenaDdls()
        {
            B_Entidad oEntidad = new B_Entidad();
            ddlNitEntidad.DataSource = oEntidad.getNits();
            ddlNitEntidad.DataTextField = "nit";
            ddlNitEntidad.DataValueField = "nit";
            ddlNitEntidad.DataBind();
        }
    }
}