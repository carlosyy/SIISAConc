using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace SIISAConc.webControls.noCalidad
{
    public partial class ctrNoCalidad : System.Web.UI.UserControl
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
            B_NoCalidadAtencion oBNoCalidadAtencion = new B_NoCalidadAtencion();
            ddlNoCalidad.DataSource = oBNoCalidadAtencion.getNoCalidadAtencion();
            ddlNoCalidad.DataTextField = "noCalidadAtencion";
            ddlNoCalidad.DataValueField = "idNoCalidadAtencion";
            ddlNoCalidad.DataBind();
        }

        protected void ddlNoCalidad_DataBound(object sender, EventArgs e)
        {
            ddlNoCalidad.Items.Insert(0, new ListItem(".::Seleccione::.", "0"));
        }
    }
}