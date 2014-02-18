using System;
using System.Web.UI.WebControls;
using Business;

namespace SIISAConc.webControls.pertinencia
{
    public partial class ctrPertinencia : System.Web.UI.UserControl
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
            B_PertinenciaAtencion oBPertinenciaAtencion = new B_PertinenciaAtencion();
            ddlPertinencia.DataSource = oBPertinenciaAtencion.getPertinenciaAtencion();
            ddlPertinencia.DataTextField = "pertinenciaAtencion";
            ddlPertinencia.DataValueField = "idPertinenciaAtencion";
            ddlPertinencia.DataBind();
        }

        protected void ddlPertinencia_DataBound(object sender, EventArgs e)
        {
            ddlPertinencia.Items.Insert(0, new ListItem(".::Seleccione::.", "0"));
        }
    }
}