using System;
using System.Web.UI.WebControls;
using Business;

namespace SIISAConc.webControls.inoportunidad
{
    public partial class ctrInoportunidad : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarDdls();
            }
        }

        private void llenarDdls()
        {
            B_InoportunidadAtencion oBInoportunidadAtencion = new B_InoportunidadAtencion();
            ddlInoportunidad.DataSource = oBInoportunidadAtencion.getInoportunidadAtencion();
            ddlInoportunidad.DataTextField = "inoportunidadAtencion";
            ddlInoportunidad.DataValueField = "idInoportunidadAtencion";
            ddlInoportunidad.DataBind();
        }

        protected void ddlInoportunidad_DataBound(object sender, EventArgs e)
        {
            ddlInoportunidad.Items.Insert(0, new ListItem(".::Seleccione::.", "0"));
        }
    }
}