using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace SIISAConc.webControls.eventosAdversos
{
    public partial class ctrEventosAdversos : System.Web.UI.UserControl
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
            B_EventosAdversosAtencion oBEventosAdversosAtencion = new B_EventosAdversosAtencion();
            ddlEventosAdversos.DataSource = oBEventosAdversosAtencion.getEventosAdversosAtencion();
            ddlEventosAdversos.DataTextField = "eventosAdversosAtencion";
            ddlEventosAdversos.DataValueField = "idEventosAdversosAtencion";
            ddlEventosAdversos.DataBind();
        }

        protected void ddlEventosAdversos_DataBound(object sender, EventArgs e)
        {
            ddlEventosAdversos.Items.Insert(0, new ListItem(".::Seleccione::.", "0"));
        }
        
    }
}