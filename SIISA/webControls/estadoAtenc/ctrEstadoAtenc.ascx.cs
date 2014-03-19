using System;
using System.Web.UI.WebControls;
using Business;

namespace SIISA.Controls.estadoAtenc
{
    public partial class ctrEstadoAtenc : System.Web.UI.UserControl
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
            B_EstadoAtenc bEstadoAtenc = new B_EstadoAtenc();
            ddlEstadoAtenc.DataSource = bEstadoAtenc.getEstadoAtenc();
            ddlEstadoAtenc.DataTextField = "estadoAtenc";
            ddlEstadoAtenc.DataValueField = "idEstadoAtenc";
            ddlEstadoAtenc.DataBind();
        }
    }
}