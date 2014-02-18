using Business;
using System;
using System.Web.UI.WebControls;

namespace SIISAConc.webControls.areasAtencion
{
    public partial class ctrAreasAtencion : System.Web.UI.UserControl
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
            B_AreasAtencion oBAreasAtencion = new B_AreasAtencion();
            ddlAreaAtencion.DataSource = oBAreasAtencion.getAreasAtencion();
            ddlAreaAtencion.DataTextField = "areasAtencion";
            ddlAreaAtencion.DataValueField = "idAreasAtencion";
            ddlAreaAtencion.DataBind();
        }

        protected void ddlAreaAtencion_DataBound(object sender, EventArgs e)
        {
            ddlAreaAtencion.Items.Insert(0, new ListItem(".::Seleccione::.", "0"));
        }
    }
}